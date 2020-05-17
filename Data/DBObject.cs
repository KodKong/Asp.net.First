using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Shop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Data
{
    public class DBObject
    {
        
        public static void  Initial (AppDBContent content)
        {
            
            

            if (!content.Category.Any())
                content.Category.AddRange(Categories.Select(c => c.Value));

            if (!content.Car.Any())
            {
                content.AddRange(
                    new Car
                    {
                        Name = "Tesla Model S",
                        ShortDesc = "бесшумный и быстрый автомобиль",
                        LongDesc = "идеально подходит для заднеприводных водителей",
                        Img = "/img/TeslaModelS.jpg",
                        Price = 45000,
                        IsFavourite = false,
                        Available = true,
                        Category = Categories["Электромобили"]
                    },
                    new Car
                    {
                        Name = "BMW X6",
                        ShortDesc = "быстрый, статусный автомобиль",
                        LongDesc = "лучшее, что может быть на рынке",
                        Img = "/img/BMWX6.jpg",
                        Price = 60000,
                        IsFavourite = true,
                        Available = true,
                        Category = Categories["Классические автомобили"]
                    },
                    new Car
                    {
                        Name = "Ford Fokus",
                        ShortDesc = "похожа на Golf",
                        LongDesc = "вообще без понятия какая она",
                        Img = "/img/FordFokus.jpg",
                        Price = 20000,
                        IsFavourite = true,
                        Available = true,
                        Category = Categories["Классические автомобили"]
                    },
                    new Car
                    {
                        Name = "Mazda 6",
                        ShortDesc = "та самая из NFS",
                        LongDesc = "первая машина в NFS нормальных пацанов",
                        Img = "/img/Mazda6.jpg",
                        Price = 45000,
                        IsFavourite = true,
                        Available = true,
                        Category = Categories["Классические автомобили"]
                    });
            }
            content.SaveChanges(); 
        }
        private static Dictionary<string, Category> category; 
        public static Dictionary<string, Category> Categories
        {
            get
            {
                if (category == null)
                {
                    var list = new Category[]
                    {
                        new Category {CategoryName = "Электромобили", Desc = "Современный вид транспорта"},
                     new Category {CategoryName = "Классические автомобили", Desc = "Машины с двигателем внутреннего сгорания"}
                    };
                    category = new Dictionary<string, Category>(); 
                    foreach (Category el in list)
                    {
                        category.Add(el.CategoryName, el); 
                    }
                }
                return category; 
            }
        }
    }
}
