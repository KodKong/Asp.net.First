using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Data.Models
{
    public class Car
    {
        public int Id { set; get; } // индификатор 

        public string Name { set; get; } // имя

        public string ShortDesc { set; get; } //  небольшое описание

        public string LongDesc { set; get; } // длинное описание 

        public string Img { set; get; } // URL адрес для картинки

        public ushort Price { set; get; } // цена 

        public bool IsFavourite { set; get; } // если тру отображается товар, если фолс - нет 

        public bool Available { set; get; } // наличие 

        public int CategoryId { set; get; } // прикрепление к категории 

        public virtual Category Category { set; get; } // создаем объект со всеми значениями из класса Category
    }
}
