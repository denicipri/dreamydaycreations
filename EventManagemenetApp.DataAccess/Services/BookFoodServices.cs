using EventManagemenetApp.DataAccess.Interface;
using EventManagemenetApp.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagemenetApp.DataAccess.Services
{
    public class BookFoodServices : IBookFood
    {
        private EventContext _context;

        public BookFoodServices(EventContext context)
        {
            _context = context;
        }

        public int BookFood(BookingFood Food)
        {
            _context.BookingFood.Add(Food);
            return _context.SaveChanges();
        }

        public IEnumerable<Food> FoodList(Food Food)
        {

            if (Food != null)
            {
                var FoodList = (from tempfood in _context.Food
                                where tempfood.FoodType == Food.FoodType && tempfood.MealType == Food.MealType && tempfood.DishType == Food.DishType
                                select tempfood).ToList();
                return FoodList;
            }
            else
            {
                return Enumerable.Empty<Food>();
            }

        }
    }
}
