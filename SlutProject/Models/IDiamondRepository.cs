using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SlutProject.Models
{
    public interface IDiamondRepository
    {
        IQueryable<Diamond> AllDiamonds{ get; }
        IEnumerable<Diamond> OnSale { get; }
        Diamond GetDiamondByID(int diamondID);
    }
}
