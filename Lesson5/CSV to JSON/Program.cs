namespace CSV_to_JSON
{
    using CsvHelper;
    using System.Formats.Asn1;
    using System.Globalization;
    using System.Text.Json;

    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }
        public bool IsActive { get; set; }
    }

    public class Program
    {

        public static async Task Main()
        {
            var inputPath = Path.Combine(AppContext.BaseDirectory, "../../../data.csv");

            var outputPath = Path.Combine(AppContext.BaseDirectory, "../../../output.json");

            var people = await ReadCsvAsync(inputPath);


            var filtered = people
                .Where(p => p.IsActive)
                .OrderByDescending(p => p.DateOfBirth)
                .ToList();

            await WriteJsonAsync(outputPath, filtered);


            var options = new JsonSerializerOptions { WriteIndented = true };
            var jsonString = JsonSerializer.Serialize(filtered, options);

     
            await File.WriteAllTextAsync(outputPath, jsonString);


            Console.WriteLine("JSON faylı created:");
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine(jsonString);
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine($"File: {Path.GetFullPath(outputPath)}");

        }


        private static async Task<List<Person>> ReadCsvAsync(string path)
        {
            using var reader = new StreamReader(path);
            using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);

            var records = new List<Person>();

            await foreach (var record in csv.GetRecordsAsync<Person>())
            {
                records.Add(record);
            }

            return records;
        }


        private static async Task WriteJsonAsync(string path, List<Person> people)
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            await using var stream = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None);
        }
    }

}
