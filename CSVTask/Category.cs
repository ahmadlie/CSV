using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSVTask
{
    public class Category
    {
        public CategoryType CategoryType { get; set; }
    }

    public enum CategoryType
    {
        Beverage,
        SoftDrink
    }
}
