using Shop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Data.Interfaces
{
    public interface IAllCars
    {
        IEnumerable <Car> Cars { get;  } //получать и устанавливать все данные 

        IEnumerable<Car> GetFavorCars { get;  } // получать и устанавливать избранные товары

        Car GetObjectCar(int carId); 
    }
}
