using ParkingSystem_Application.Web.API.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using System.Web.Mvc;

namespace ParkingSystem_Application.Web.API.Controllers
{
    public class SearchController : ApiController
    {
        public IEnumerable<User> Get()
        {
            using(ChiragSpicesEntities _chiragSpicesEntities  = new ChiragSpicesEntities())
            {
                return _chiragSpicesEntities.Users.ToList();
            }
        }
    }
}
