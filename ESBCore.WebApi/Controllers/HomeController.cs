using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace ESBCore.WebApi.Controllers
{
    public class HomeController : AbpController
  {
        public IActionResult Index()
        {
             return Redirect("/swagger");
        }
    }
}