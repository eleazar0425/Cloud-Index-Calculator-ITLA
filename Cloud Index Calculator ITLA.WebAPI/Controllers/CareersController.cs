using Cloud_Index_Calculator_ITLA.Data;
using Cloud_Index_Calculator_ITLA.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;

namespace Cloud_Index_Calculator_ITLA.WebAPI.Controllers
{
    public class CareersController : ApiController
    {

        private IndexCalculatorContext db = new IndexCalculatorContext();
        
        public IQueryable<Career> GetCareers()
        {
            return db.Careers.Include(e => e.Subjets);
        }
    }
}
