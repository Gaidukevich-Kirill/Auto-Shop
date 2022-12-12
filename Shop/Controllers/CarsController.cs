using Microsoft.AspNetCore.Mvc;
using Shop.Data.Interfaces;
using Shop.Data.Models;
using Shop.ViewModels;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Shop.Controllers
{
    public class CarsController : Controller
    {
        private readonly IAllCars _allCars;
        private readonly ICarsCategory _allCategories;

        public CarsController(IAllCars allCars, ICarsCategory carsCategory)
        {
            _allCars = allCars;
            _allCategories = carsCategory;
        }

        [Route("Cars/List")]
        [Route("Cars/List/{categoryParam}")]
        public ViewResult List(string categoryParam)
        {
            string category = categoryParam;
            IEnumerable<Car> cars;
            string currentCategory = "";

            if (string.IsNullOrEmpty(categoryParam))
            {
                cars = _allCars.Cars.OrderBy(index => index.Id);
            }
            else
            {
                if (string.Equals("electro", category, StringComparison.OrdinalIgnoreCase))
                {
                    cars = _allCars.Cars.Where(index => index.Category.CategoryName.
                    Equals("Электромобиль")).
                    OrderBy(index => index.Id);

                    currentCategory = "Электромобили";
				}
                else
                {
					cars = _allCars.Cars.Where(index => index.Category.CategoryName.
					Equals("Автомобиль")).
					OrderBy(index => index.Id);

                    currentCategory = "Автомобили";
				}
            }

            ViewBag.Title = "Автомобили";
            var carObject = new CarsListViewModel
            {
                allCars = cars,
                currentCategory = currentCategory,
            };

            return View(carObject);
        }
    }
}
