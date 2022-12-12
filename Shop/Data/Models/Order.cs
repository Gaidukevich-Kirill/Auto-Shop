using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Shop.Data.Models
{
	public class Order
	{
		[BindNever]
		public int Id { get; set; }

		[Display(Name = "Имя:")]
		[StringLength(35)]
		[Required(ErrorMessage = "Длина имени не менее 2 символов")]
		public string Name { get; set; }

		[Display(Name = "Фамилия:")]
		[StringLength(35)]
		[Required(ErrorMessage = "Длина фамилии не менее 2 символов")]
		public string SecondName { get; set; }

		[Display(Name = "Адрес:")]
		[StringLength(35)]
		[Required(ErrorMessage = "Длина адреса не менее 5 символов")]
		public string Adress { get; set; }

		[Display(Name = "Телефон:")]
		[StringLength(35)]
		[DataType(DataType.PhoneNumber)]
		[Required(ErrorMessage = "Длина телефона не менее 5 символов")]
		public string Phone { get; set; }

		[Display(Name = "Email:")]
		[StringLength(35)]
		[DataType(DataType.EmailAddress)]
		[Required(ErrorMessage = "Длина Email не менее 5 символов")]
		public string Email { get; set; }

		[BindNever]
		[ScaffoldColumn(false)]
		public DateTime OrderTime { get; set; }

		public List <OrderDetail> OrderDetails { get; set; }
	}
}
