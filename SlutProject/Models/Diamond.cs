using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SlutProject.Models
{
    public class Diamond
    {
        public int DiamondId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string ImageName { get; set; }
        public bool OnSale  { get; set; }
        public bool InStock { get; set; }
        [NotMapped]
        public string ImageSrc { get; set; }
        
    }
}
