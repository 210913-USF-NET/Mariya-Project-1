using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models;

namespace WebUI.Models
    {
    public class ProductVM
        {
        public List<string> Genres { get; set; }
        public List<Product> Products { get; set; }
        }
    }
