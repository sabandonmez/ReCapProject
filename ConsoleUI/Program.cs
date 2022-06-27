using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUI
{
    public class Program
    {
        static void Main(string[] args)
        {

            CarManager carManager = new CarManager(new EfCarDal());
            var result = carManager.GetAll();
            if (result.Succes)
            {
                foreach (var car in result.Data)
                {
                    Console.WriteLine(car.BrandModel);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }


        }
    }
}

