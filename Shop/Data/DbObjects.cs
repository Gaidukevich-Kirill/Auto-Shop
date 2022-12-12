using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Shop.Data.Interfaces;
using Shop.Data.Models;
using Shop.Migrations;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;

namespace Shop.Data
{
    public class DbObjects
    {
        public static void Initial (AppDBContent content)
        {
            if (!content.Category.Any())
            {
                content.Category.AddRange(Categories.Select(c => c.Value));
            }

            if (!content.Car.Any())
            {
                content.AddRange(
                    new Car()
                    {
                        Name = "Mazda Miata",
                        ShortDescription = "1997 г., механика, 1.6 л, бензин, 200 000 км",
                        LongDescription = "",
                        Img = "/img/MazdaMiata.jpg",
                        Price = 17000,
                        IsFavorite = true,
                        Avaliable = true,
                        Category = Categories["Автомобиль"]
                    },

                    new Car()
                    {
                        Name = "Lada Niva Travel",
                        ShortDescription = "2022 г., механика, 1.7 л, бензин, 976 км",
                        LongDescription = "",
                        Img = "/img/LadaNiva.jpg",
                        Price = 21000,
                        IsFavorite = false,
                        Avaliable = true,
                        Category = Categories["Автомобиль"]
                    },

                    new Car()
                    {
                        Name = "BMW F44",
                        ShortDescription = "2020 г., автомат, 2.0 л, бензин, 22 865 км",
                        LongDescription = "",
                        Img = "/img/BMWF44.jpg",
                        Price = 38000,
                        IsFavorite = false,
                        Avaliable = true,
                        Category = Categories["Автомобиль"]
                    },

                    new Car()
                    {
                        Name = "Tesla Model S",
                        ShortDescription = "Быстрый и экологичный",
                        LongDescription = "",
                        Img = "/img/Tesla.jpg",
                        Price = 45000,
                        IsFavorite = false,
                        Avaliable = true,
                        Category = Categories["Электромобиль"]
                    },

                    new Car()
                    {
                        Name = "Mercedes-Benz CLA",
                        ShortDescription = "Спортивный",
                        LongDescription = "",
                        Img = "/img/Mercedes.jpg",
                        Price = 25000,
                        IsFavorite = true,
                        Avaliable = true,
                        Category = Categories["Автомобиль"]
                    });
            }

            content.SaveChanges();
        }

        private static Dictionary<string, Category> _category;

        public static Dictionary<string, Category> Categories
        {
            get
            {
                if( _category == null)
                {
                    var list = new Category[]
                    {
                        new Category { CategoryName = "Электромобиль", Description = "Автомобиль с электродвигателем" },
                        new Category { CategoryName = "Автомобиль", Description = "Автомобили с бензиновым двигателем"}
                    };

                    _category = new Dictionary<string, Category>();
                    foreach (var element in list)
                    {
                        _category.Add(element.CategoryName, element);
                    }
                }

                return _category;
            }
        }
    }
}
