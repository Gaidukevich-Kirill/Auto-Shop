using Microsoft.IdentityModel.Tokens;
using Shop.Data.Repository;
using Shop.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Shop.ViewModels;
using System.Linq;
using Shop.Data.Interfaces;

namespace Shop.Controllers
{
    public class ShopCartController : Controller
    {
        private readonly IAllCars _carRepository;
        private readonly ShopCart _shopCart;

        public ShopCartController(IAllCars carRepository, ShopCart shopCart)
        {
            _carRepository = carRepository;
            _shopCart = shopCart;
        }

        public ViewResult Index()
        {
            var items = _shopCart.GetShopItems();
            _shopCart.ListShopItems = items;

            var obj = new ShopCartViewModel
            {
                ShopCart = _shopCart,
            };

            return View(obj);
        }

        public RedirectToActionResult AddToCart(int id)
        {
            var item = _carRepository.Cars.FirstOrDefault(i => i.Id == id);

            if (item != null)
            {
                _shopCart.AddToCart(item);
            }

            return RedirectToAction("Index");
        }
    }
}
