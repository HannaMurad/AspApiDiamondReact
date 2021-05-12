using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SlutProject.Models
{
    public class DiamondRepository : IDiamondRepository
    {
        private readonly AppDbContext _appDbContext;

        public DiamondRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public  IQueryable<Diamond>  AllDiamonds =>  _appDbContext.Diamonds;

        public IEnumerable<Diamond> OnSale => _appDbContext.Diamonds.Where(p => p.OnSale);

        public Diamond GetDiamondByID(int diamondID)
        {
            return _appDbContext.Diamonds.FirstOrDefault(p => p.DiamondId == diamondID);
        }
    }
}
