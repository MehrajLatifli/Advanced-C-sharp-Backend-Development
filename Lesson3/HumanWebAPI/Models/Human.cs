namespace HumanWebAPI.Models
{
    public class Human
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }  

    }

    public class CreateHumanDTO
    {
        public string Name { get; set; }
        public int Age { get; set; }

    }

    public class UpdateHumanDTO
    {
        public string Name { get; set; }
        public int Age { get; set; }

    }
}
