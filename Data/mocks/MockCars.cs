using Shop.Data.Interfaces;
using Shop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Data.mocks
{
    public class MockCars : IAllCars
    {
        private readonly ICarsCategory _CategoryCars = new MockCategory();  
        public IEnumerable<Car> Cars { 
            get
            {
                return new List<Car>
                {
                    new Car {Name = "Tesla Model S", 
                        ShortDesc = "бесшумный и быстрый автомобиль", 
                        LongDesc = "идеально подходит для заднеприводных водителей", 
                        Img = "/img/TeslaModelS.jpg",
                        Price = 45000, 
                        IsFavourite = false, 
                        Available = true, 
                        Category = _CategoryCars.AllCategorys.First()},
                    new Car {Name = "BMW X6",
                        ShortDesc = "быстрый, статусный автомобиль",
                        LongDesc = "лучшее, что может быть на рынке",
                        Img = "/img/BMWX6.jpg",
                        Price = 60000,
                        IsFavourite = true,
                        Available = true,
                        Category = _CategoryCars.AllCategorys.Last()},
                    new Car {Name = "Ford Focus",
                        ShortDesc = "похожа на Golf",
                        LongDesc = "вообще без понятия какая она",
                        Img = "/img/FordFokus.jpg",
                        Price = 20000,
                        IsFavourite = false,
                        Available = true,
                        Category = _CategoryCars.AllCategorys.Last()},
                    new Car {Name = "Mazda 6",
                        ShortDesc = "та самая из NFS",
                        LongDesc = "первая машина в NFS нормальных пацанов",
                        Img = "/img/Mazda6.jpg",
                        Price = 45000,
                        IsFavourite = true,
                        Available = true,
                        Category = _CategoryCars.AllCategorys.First()},
                }; 
            }
        }
        public IEnumerable<Car> GetFavorCars { get; set; }

        public Car GetObjectCar(int carId)
        {
            throw new NotImplementedException();
        }
    }
}
