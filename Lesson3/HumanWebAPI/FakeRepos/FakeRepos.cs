using HumanWebAPI.Models;
using System.Reflection;

namespace HumanWebAPI.FakeRepos
{
    public class FakeRepos
    {
        static public List<Models.Human> Humans = new List<Models.Human>
        {
            new Human {Id = 1, Name = "Name_1", Age=18 },
            new Human {Id = 2, Name = "Name_2", Age=20 },
            new Human {Id = 3, Name = "Name_3", Age=28 },
            new Human {Id = 4, Name = "Name_4", Age=35 },
            new Human {Id = 5, Name = "Name_5", Age=25 },
            new Human {Id = 6, Name = "Name_6", Age=21 },
            new Human {Id = 7, Name = "Name_7", Age=36 },
            new Human {Id = 8, Name = "Name_8", Age=50 },

        };
    }
}
