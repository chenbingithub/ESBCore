using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace ESBCore.Service
{
   public interface ITranspondService
  {
      T Get<T>(string url);

      T Post<T>(string url, HttpContent content);

      string Get(string url);

      string Post(string url, HttpContent content);
  }
}
