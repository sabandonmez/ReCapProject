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

            //CarManager carManager = new CarManager(new EfCarDal());
            //foreach (var car in carManager.GetCarsByBrandId(1))
            //{
            //    Console.WriteLine(car.BrandModel + " " + car.Description+" "+car.ModelYear+" "+car.DailyPrice + " " + car.ModelYear);
            //}

            //CarManager carManager = new CarManager(new EfCarDal());
            //foreach (var car in carManager.GetCarsByColorId(2))
            //{
            //    Console.WriteLine("ColorId: " + car.ColorId + " = " + car.BrandModel);
            //}


            CarManager carManager = new CarManager(new EfCarDal());
            carManager.Add(new Car { CarId = 7, BrandId = 1, ColorId = 4, BrandModel = "a", DailyPrice = 130000, ModelYear = "1995", Description = "Sedan" });
            foreach (var car in carManager.GetCarsByCarId(7))
            {
                Console.WriteLine(car.BrandModel +" Eklendi");
            }



        }
    }
}

