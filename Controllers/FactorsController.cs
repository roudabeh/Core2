using Microsoft.AspNetCore.Mvc;
using Tamrin.APIModels;
using Tamrin.Database;
using Tamrin.Database.Models;

namespace Tamrin.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class FactorsController : ControllerBase
    {
        private readonly TamrinDBContext db;

        public FactorsController(TamrinDBContext tamrinDBContext)
        {
            db = tamrinDBContext;
        }

        [HttpGet]
        public IEnumerable<FactorAPIModel> GetAll()
        {
            return db.Factors.Select(f => new FactorAPIModel
            {
                ContactId = f.ContactId,
                Id = f.Id,
                FactorDetails = f.FactorDetails.Select(fd => new FactorDetailAPIModel
                {
                    Item = fd.Item,
                    Price = fd.Price,
                    Value = fd.Value,
                    Id = fd.Id,
                    FactorId = fd.FactorId
                }).ToList(),
                Title = f.Title
            }).ToList();
        }
        [HttpPost]
        public bool Add(FactorAPIModel factor)
        {
            db.Factors.Add(new Factor
            {
                ContactId = factor.ContactId,
                FactorDetails = factor.FactorDetails.Select(fd => new FactorDetail
                {
                    Item = fd.Item,
                    Price = fd.Price,
                    Value = fd.Value
                }).ToList(),
                Title = factor.Title
            });

            db.SaveChanges();
            return true;
        }
    }
}
