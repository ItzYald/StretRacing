using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreetRacing.Models
{
    internal class Transmission
    {
        public int quantity;
        public int number;

        public List<float> ratios;

        public Transmission(int quantity)
        {
            this.quantity = quantity;

            if (quantity == 5)
            {
                ratios = new List<float>() { 3.8f, 2.2f, 1.3f, 0.9f, 0.5f };
            }
            else if (quantity == 6)
            {
                ratios = new List<float>() { 3.8f, 2.5f, 1.7f, 1.2f, 0.7f, 0.4f };
            }

            number = 0;
            
        }

    }
}
