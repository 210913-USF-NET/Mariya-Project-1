using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models;
using StoreBL;

namespace WebUI.Models
    {
    public class HomePages
        {
        public List<string> Genre { get; set; }
        public List<Product> Products { get; set; } = new List<Product>();
        
        
        }
    }
