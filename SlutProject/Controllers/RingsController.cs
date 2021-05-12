using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using SlutProject.Models;
using Microsoft.AspNetCore.Hosting;

namespace SlutProject.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class RingsController : ControllerBase
    {
        private readonly IDiamondRepository _diamondRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public RingsController(IDiamondRepository diamondRepository, IWebHostEnvironment webHostEnvironment)
        {
            _diamondRepository = diamondRepository;
            _webHostEnvironment = webHostEnvironment;
        }

        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Diamond>>> Get(bool onSale, bool inStock, bool search, string searcValue)
        {

            var query =  _diamondRepository.AllDiamonds;
            
            if (onSale)
            {
                query = query.Where(d => d.OnSale == onSale);
            }
            if (inStock)
            {
                query = query.Where(d => d.InStock == inStock);
            }
            if (search)
            {
                query = query.Where(d => d.Name.StartsWith(searcValue));
            }

            return await query.Select(d => new Diamond
                {
                    DiamondId = d.DiamondId,
                    ImageSrc = String.Format("{0}://{1}{2}/images/{3}", Request.Scheme, Request.Host, Request.PathBase, d.ImageName),
                    Name = d.Name,
                    Price = d.Price,
                    Description = d.Description
                }).ToListAsync();
        }

    }
}
