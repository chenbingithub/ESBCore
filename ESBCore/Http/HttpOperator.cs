using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace ESB.Common.Http
{
    public class HttpOperator : IHttpOperator
    {


        public T Post<T>(IHttpConnection conn, object content)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = client.PostAsJsonAsync(conn.ConnectionUrl, content).Result;
                    response.EnsureSuccessStatusCode();
                    return response.Content.ReadAsAsync<T>().Result;
                }
                catch
                {
                    return default(T);
                }
            }
        }

        public T Put<T>(IHttpConnection conn, object content)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = client.PutAsJsonAsync(conn.ConnectionUrl, content).Result;
                    response.EnsureSuccessStatusCode();
                    return response.Content.ReadAsAsync<T>().Result;
                }
                catch
                {
                    return default(T);
                }
            }
        }

        public T Delete<T>(IHttpConnection conn)
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = client.DeleteAsync(conn.ConnectionUrl).Result;
                try
                {
                    response.EnsureSuccessStatusCode();
                    return response.Content.ReadAsAsync<T>().Result;
                }
                catch
                {
                    return default(T);
                }
            }
        }

        public T Get<T>(IHttpConnection conn)
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = client.GetAsync(conn.ConnectionUrl).Result;
                try
                {
                    response.EnsureSuccessStatusCode();
                    return response.Content.ReadAsAsync<T>().Result;

                }
                catch
                {
                    return default(T);
                }

            }
        }

        public void TryPost(IHttpConnection conn, object content)
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = client.PostAsJsonAsync(conn.ConnectionUrl, content).Result;
                response.EnsureSuccessStatusCode();
            }
        }

        public void TryGet(IHttpConnection conn)
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = client.GetAsync(conn.ConnectionUrl).Result;
                response.EnsureSuccessStatusCode();
            }
        }
    }
}
