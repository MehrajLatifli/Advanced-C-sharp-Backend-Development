using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace C_sharp_12_features
{
    [InlineArray(4)]
    public struct Buffer
    {
        private int _element0; 
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            #region Collection Expressions

            // without  Collection Expressions

            int[] numbers = new int[] { 1, 2, 3, 4 };
            List<string> names = new List<string> { "Alice", "Bob", "Charlie" };

            Console.WriteLine(string.Join(", ", numbers));
            Console.WriteLine(string.Join(", ", names));



            //Collection Expressions

            int[] numbers2 = [4, 5, 6, 7];
            List<string> names2 = ["Kate", "Hansel", "John"];

            Console.WriteLine(string.Join(", ", numbers2));
            Console.WriteLine(string.Join(", ", names2));

            #endregion


            #region InlineArray

            //InlineArray

            Buffer b_numbers = new Buffer();

            b_numbers[0] = 10;
            b_numbers[1] = 20;
            b_numbers[2] = 30;
            b_numbers[3] = 40;

            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine(numbers[i]);
            }

            #endregion


            Console.ReadKey(true);
        }


    }
}
