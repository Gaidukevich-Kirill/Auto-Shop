using Shop.Data.Models;
using System.Collections.Generic;

namespace Shop.Data.Interfaces
{
    public interface IAllCars
    {
        IEnumerable<Car> Cars { get; }

        IEnumerable<Car> GetFavouriteCars  { get; }

        Car GetObjectCar(int carId);
    }
}
