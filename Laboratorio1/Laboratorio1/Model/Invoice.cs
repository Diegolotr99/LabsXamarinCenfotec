using System;
using System.Collections.Generic;
using System.Text;

namespace Laboratorio1.Model
{
    public class Invoice
    {

        public Invoice() {


        }

        public int ID { get; set; }
        public string Description { get; set; }
        public double Amount { get; set; }
        public string Type { get; set; }
    }
}
