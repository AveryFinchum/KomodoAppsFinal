using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoCafeMenuConsole
{

    public class MenuItem
    {

        //public MenuItem() { } //no need for a default onstructor here
        public MenuItem(int number, string name, string description, string ingredients, decimal price) 
        {
            Number = number;
            Name = name;
            Description = description;
            Ingredients = ingredients;
            Price = price;
        }

        //Required fields
        public int Number { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Ingredients { get; set; }
        public decimal Price
        { // decimals since were dealing with money
            get
            {
                return decimal.Round(Price, 2, MidpointRounding.AwayFromZero); //always give back answers in 2 decimal places since were dealing with money
            }
            set { } // keep all accuracy the user puts in(useful for future functionality by generating grand totals/economy of scale calculations)
        }

    }
}
