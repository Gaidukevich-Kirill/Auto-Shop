using Shop.Data.Interfaces;
using Shop.Data.Models;
using System.Collections.Generic;
using System.Linq;

namespace Shop.Data.Mocks
{
    public class MockCars : IAllCars
    {
        private readonly ICarsCategory _carCategory = new MockCategory();

        public IEnumerable<Car> Cars 
        {
            get
            {
                return new List<Car>()
                {
                    new Car()
                    {
                        Name = "Mazda Miata",
                        ShortDescription = "1997 г., механика, 1.6 л, бензин, 200 000 км",
                        LongDescription = "",
                        Img = "/img/MazdaMiata.jpg",
                        Price = 17000,
                        IsFavorite = true,
                        Avaliable = true,
                        Category = _carCategory.AllCategories.Last()
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
                        Category = _carCategory.AllCategories.Last()
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
                        Category = _carCategory.AllCategories.Last()
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
                        Category = _carCategory.AllCategories.First()
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
                        Category = _carCategory.AllCategories.Last()
                    }
                };
            }
        }

        public IEnumerable<Car> GetFavouriteCars { get; set; }

        public Car GetObjectCar(int carId)
        {
            throw new System.NotImplementedException();
        }
    }
}
