using System;
using System.Collections.Generic;
using System.Text;

namespace FreakyFashionTerminal.Models
{
    class Order
    {
        public int Id { get; set; }
        public DateTime DateTime { get; set; } = new DateTime();
        public int UserId { get; set; }
        
        public float Totalt { get; set; }
    }
}
