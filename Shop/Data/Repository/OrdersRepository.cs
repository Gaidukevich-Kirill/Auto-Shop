using Shop.Data.Interfaces;
using Shop.Data.Models;
using System;

namespace Shop.Data.Repository
{
	public class OrdersRepository : IAllOrders
	{
		private readonly AppDBContent _appDbContent;
		private readonly ShopCart _shopCart;

		public OrdersRepository(AppDBContent appDbContent, ShopCart shopCart)
		{
			_appDbContent = appDbContent;
			_shopCart = shopCart;
		}

		public void CreateOrder(Order order)
		{
			order.OrderTime = DateTime.Now;
			_appDbContent.Order.Add(order);
			_appDbContent.SaveChanges();

			var items = _shopCart.ListShopItems;

			foreach (var element in items)
			{
				var orderDetail = new OrderDetail()
				{
					CarId = element.Car.Id,
					OrderId = order.Id,
					Price = element.Car.Price
				};

				_appDbContent.OrderDetail.Add(orderDetail);
			}

			_appDbContent.SaveChanges();
		}
	}
}
