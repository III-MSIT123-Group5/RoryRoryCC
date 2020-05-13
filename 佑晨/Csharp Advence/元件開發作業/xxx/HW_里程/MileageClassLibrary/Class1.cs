using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MileageClassLibrary
{
    public abstract  class MileageClass
    {
        public decimal MileByGallon { get; set; }
        public decimal TotalFuel { get; set; }

        public abstract decimal Mileage();

    }

    public class CarMileage : MileageClass
    {
        public CarMileage(decimal MileByGallon , decimal TotalFuel)
        {
            this.MileByGallon = MileByGallon;
            this.TotalFuel = TotalFuel;
        }

        public override decimal Mileage()
        {
            return this.MileByGallon * this.TotalFuel;
        }
    }
}
