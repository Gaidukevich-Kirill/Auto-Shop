using Shop.Data.Interfaces;
using Shop.Data.Models;
using System.Collections.Generic;

namespace Shop.Data.Mocks
{
    public class MockCategory : ICarsCategory
    {
        public IEnumerable<Category> AllCategories
        {
            get 
            {
                return new List<Category>
                {
                    new Category { CategoryName = "Электромобиль", Description = "Автомобиль с электродвигателем" },
                    new Category { CategoryName = "Автомобиль", Description = "Автомобили с бензиновым двигателем"}
                };
            }
        }
    }
}
