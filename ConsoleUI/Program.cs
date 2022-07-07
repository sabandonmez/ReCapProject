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
            //UserManager userManager = new UserManager(new EfUserDal());
            //CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            //RentalManager rentalManager = new RentalManager(new EfRentalDal());

            //User user1 = new User { FirstName="Ali",LastName="Yemen",Email="aliyemen@gmail.com",Password="abcd123"};
            //userManager.Add(user1);

            //Customer customer1 = new Customer { UserId=user1.UserId,CompanyName="ABCD"};
            //customerManager.Add(customer1);

            //Rental rental1=new Rental {RentalId=3, CarId=5,CustomerId=customer1.CustomerId,RentDate=DateTime.Now};
            //rentalManager.Add(rental1);

            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            var result = rentalManager.GetAll();
            if (result.Success)
            {
                foreach (var rental in result.Data)
                {
                    Console.WriteLine("Kiralama Tarihi:" + rental.RentDate);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }

        private static void RentalDetails()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            var result = rentalManager.GetAll();
            if (result.Success)
            {
                foreach (var rental in result.Data)
                {
                    Console.WriteLine("Kiralama Tarihi:" + rental.RentDate);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }

        private static void ResultMethot_2_Color()
        {
            //ColorManager colorManager = new ColorManager(new EfColorDal());
            //var result = colorManager.GetAll();
            //if (result.Succes)
            //{
            //    foreach (var color in result.Data)
            //    {
            //        Console.WriteLine(color.ColorName);
            //    }
            //}
            //else
            //{
            //    Console.WriteLine(result.Message);
            //}
        }

        private static void ResultMethot_1()
        {
            //CarManager carManager = new CarManager(new EfCarDal());
            //var result = carManager.GetAll();
            //if (result.Succes)
            //{
            //    foreach (var car in result.Data)
            //    {
            //        Console.WriteLine(car.BrandModel);
            //    }
            //}
            //else
            //{
            //    Console.WriteLine(result.Message);
            //}
        }
    }
}

