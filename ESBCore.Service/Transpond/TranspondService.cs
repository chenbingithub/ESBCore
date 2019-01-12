using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Text;
using Abp.Application.Services;

namespace ESBCore.Service
{
   public class TranspondService : ApplicationService, ITranspondService
  {
    public T Get<T>(string url)
    {
      using (HttpClient client = new HttpClient())
      {
        HttpResponseMessage response = client.GetAsync(url).Result;
        var str = response.Content.ReadAsStringAsync().Result;
        return ParseJson<T>(str);
      }
    }

    public string Get(string url)
    {
      using (HttpClient client = new HttpClient())
      {
        HttpResponseMessage response = client.GetAsync(url).Result;
        var str = response.Content.ReadAsStringAsync().Result;
        return str;
      }
    }

    public string Post(string url, HttpContent content)
    {
      HttpClientHandler httpHandler = new HttpClientHandler();
      httpHandler.UseDefaultCredentials = true;
      using (HttpClient client = new HttpClient(httpHandler))
      {
        var response = client.PostAsync(url, content).Result;
        var re = response.Content.ReadAsStringAsync().Result;
        return re;
      }
    }

    public T Post<T>(string url, HttpContent content)
    {
      using (HttpClient client = new HttpClient())
      {
        HttpResponseMessage response = client.PostAsync(url, content).Result;
        var str = response.Content.ReadAsStringAsync().Result;
        return ParseJson<T>(str);
      }
    }

    private T ParseJson<T>(string jsonStr)
    {
      T obj = Activator.CreateInstance<T>();
      using (System.IO.MemoryStream ms =
      new System.IO.MemoryStream(System.Text.Encoding.UTF8.GetBytes(jsonStr)))
      {
        DataContractJsonSerializer serializer =
        new DataContractJsonSerializer(typeof(T));
        var tobject = (T)serializer.ReadObject(ms);
        return tobject;// (T)serializer.ReadObject(ms);
      }
    }

  }
}
