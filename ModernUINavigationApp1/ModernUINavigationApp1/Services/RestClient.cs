using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Net;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ServiceLayer
{
    public class BaseResult
    {
        public bool ok;
        public string message;

        public override string ToString()
        {
            return message;
        }
    }
 
    public class RestClient
    {
        public static readonly string SERVER_URL = "http://localhost:88/hack";
        public static string post(string cmd)
        {
            try
            {
                using (var client = new WebClient())
                {
                    var values = new NameValueCollection();
                    values["cmd"] = cmd;
                    var r = client.UploadValues(SERVER_URL + "/server.php", values);
                    var rs = Encoding.Default.GetString(r);
                    return rs;
                }
            }
            catch (Exception e) { Console.WriteLine(e.Message); }
            return null;
        }

        public static string post(string cmd, Dictionary<string, string> map)
        {
            var rs = "";
            try
            {
                using (var client = new WebClient())
                {
                    var values = new NameValueCollection();
                    values["cmd"] = cmd;
                    foreach (string key in map.Keys)
                        values[key] = map[key];
                    var r = client.UploadValues(SERVER_URL + "/server.php", values);
                    rs = Encoding.Default.GetString(r);
                }
            }
            catch (Exception e) { Console.WriteLine(e.Message); }
            Console.WriteLine(rs);
            return rs;
        }

        public static T post<T>(string cmd, Dictionary<string, string> data)
        {
            try
            {
                string rs = RestClient.post(cmd, data);
                Console.WriteLine(rs);
                T r = JsonConvert.DeserializeObject<T>(rs);
                Console.WriteLine(r);
                return r;
            }
            catch (JsonException e)
            {
                Console.WriteLine(e);
            }
            return default(T);
        }
    }
}
