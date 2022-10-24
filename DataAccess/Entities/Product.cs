using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics.CodeAnalysis;

namespace DataAccess.Entities
{
    public class Product : Entity
    {
        public string Name { get; set; }
        public int Amount { get; set; }
        public double Price { get; set; }

    }
}

