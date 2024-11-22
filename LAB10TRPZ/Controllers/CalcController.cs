using LAB10TRPZ.Models;
using Microsoft.AspNetCore.Mvc;

namespace LAB10TRPZ.Controllers
{
    public class CalcController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string array1, string array2)
        {
            string result;

            try
            {
                // Перетворення введених даних у масиви
                int[] parsedArray1 = array1?.Split(',').Select(int.Parse).ToArray() ?? new int[0];
                int[] parsedArray2 = array2?.Split(',').Select(int.Parse).ToArray() ?? new int[0];

                // Обчислення сум
                int sum1 = parsedArray1.Sum();
                int sum2 = parsedArray2.Sum();

                if (sum1 > sum2)
                {
                    result = $"Сума елементів першого масиву ({sum1}) більша, ніж другого масиву ({sum2}).";
                }
                else if (sum1 < sum2)
                {
                    result = $"Сума елементів другого масиву ({sum2}) більша, ніж першого масиву ({sum1}).";
                }
                else
                {
                    result = $"Сума елементів обох масивів однакова ({sum1}).";
                }
            }
            catch (Exception e)
            {
                result = "Виникла помилка: " + e.Message;
            }

            ViewBag.Result = result;
            return View();
        }

    }
}
