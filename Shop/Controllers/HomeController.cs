using Microsoft.AspNetCore.Mvc;
using Shop.Data.Interfaces;
using Shop.ViewModels;

namespace Shop.Controllers
{
    public class HomeController : Controller
    {
        private IAllCars _carRepository;

        public HomeController(IAllCars carRepository)
        {
            _carRepository = carRepository;
        }

        public ViewResult Index()
        {
            var homeCars = new HomeViewModel
            {
                FavouriteCars = _carRepository.GetFavouriteCars
            };

            return View(homeCars);
        }
    }
}
