using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : ICarDal
    {
        public void Add(Car entity)
        {
            //usinge gelen  nesneler using bitince bellekten atılır çünkü context nesnesi biraz maliyetli
            //Direkt NorthwindContext contex=new NorthwindContext() yazsaakta olur ama using daha tasarruflu bir yapı sunuyor

            //Bu Usinge IDısposable pattern implementation of c# denir. Bellek hızlıca temizlenir.
            using (ReCapDBContext context = new ReCapDBContext())
            {
                var addedEntity=context.Entry(entity);// Veri kaynağıyla entity 'i ilişkilendirir.
                addedEntity.State = EntityState.Added; // Eklenecek nesne olduğunu söyledik
                context.SaveChanges();// Ekle.İşlemleri yürürlüğe sokar.
            }
        }

        public void Delete(Car entity)
        {
            using (ReCapDBContext context = new ReCapDBContext())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State=EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            using (ReCapDBContext context = new ReCapDBContext())
            {
                return context.Set<Car>().SingleOrDefault(filter);
            }
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            using (ReCapDBContext context =new ReCapDBContext())
            {
                return filter == null ? context.Set<Car>().ToList() : context.Set<Car>().Where(filter).ToList();
            }
        }

        public void Update(Car entity)
        {
            using (ReCapDBContext context = new ReCapDBContext())
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
