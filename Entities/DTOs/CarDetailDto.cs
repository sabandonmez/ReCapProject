using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class CarDetailDto:IDto
    //Buraya IEntity yazmıyoruz çünkü bunlar DB tablosu değil onların join gibi
    //işlemlerinin yapıldığı mutfak.
    //Fakat IDto da evrensel bir koddur o yüzden Core yazacağız.
    {

        public string BrandName { get; set; }
        public string BrandModel  { get; set; }
        public string ColorName { get; set; }
        public string Description { get; set; }

        public int DailyPrice { get; set; }




    }
}
