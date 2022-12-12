using Microsoft.EntityFrameworkCore;
using Shop.Data.Interfaces;
using Shop.Data.Models;
using System.Collections.Generic;
using System.Linq;

namespace Shop.Data.Repository
{
    public class CarRepository : IAllCars
    {
        private readonly AppDBContent _appDBContent;

        public CarRepository(AppDBContent appDBContent)
        {
            _appDBContent = appDBContent;
        }

        public IEnumerable<Car> Cars => _appDBContent.Car.Include(c => c.Category);

        public IEnumerable<Car> GetFavouriteCars => _appDBContent.Car.Where(p => p.IsFavorite).Include(c => c.Category);

        public Car GetObjectCar(int carId) => _appDBContent.Car.FirstOrDefault(p => p.Id == carId);
    }
}
