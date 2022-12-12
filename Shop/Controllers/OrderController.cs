using Microsoft.AspNetCore.Mvc;
using Shop.Data;
using Shop.Data.Interfaces;
using Shop.Data.Models;
using System;

namespace Shop.Controllers
{
	public class OrderController : Controller
	{
		private readonly IAllOrders _allOrders;
		private readonly ShopCart _shopCart;

		public OrderController(IAllOrders allOrders, ShopCart shopCart)
		{
			_allOrders = allOrders;
			_shopCart = shopCart;
		}

		public IActionResult Checkout()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Checkout(Order order)
		{
			_shopCart.ListShopItems = _shopCart.GetShopItems();

			if (_shopCart.ListShopItems.Count == 0)
			{
				ModelState.AddModelError("", "Товар отсутствует");
			}

			if (ModelState.IsValid)
			{
				_allOrders.CreateOrder(order);
				return RedirectToAction("Complete");
			}

			return View(order);
		}

		public IActionResult Complete()
		{
			ViewBag.Message = "Заказ обработан";

			return View();
		}
	}
}
