using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Abp.AspNetCore.Mvc.Controllers;
using ESB.Common.Http;
using ESBCore.Service;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ESBCore.WebApi.Controllers
{
    public class HomeController : AbpController
    {
      private ITranspondService _transpondService;

      public HomeController( ITranspondService transpondService)
      {
        _transpondService = transpondService;
      }

      public IActionResult Index()
        {
             return Redirect("/swagger");
        }

    public IActionResult Transpond(string aisleurl, dynamic data)
    {
      Logger.Info("进入转发方法" + aisleurl);
      string sourceurl = data.sourceurl;
      var stringJson = JsonConvert.SerializeObject(data);
      HttpContent httpContent = new StringContent(stringJson);
      httpContent.Headers.ContentType = new MediaTypeHeaderValue("");
      var transfer = _transpondService.Post("", httpContent);
      var returndata = JsonConvert.DeserializeObject(transfer);

      return Json(returndata);
     
    }
  }
}