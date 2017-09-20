using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer
{
    public class RestRegister
    {
        public static BaseResult login(string user, string pass)
        {
            try
            {
                Dictionary<string, string> data = new Dictionary<string, string>();
                data["user"] = user;
                data["pass"] = pass;
                return post<BaseResult>("login", data);
            }
            catch (JsonException e)
            {
                Console.WriteLine(e);
            }
            return null;
        }

        public static BaseResult register(string name, string user, string pass)
        {
            try
            {
                Dictionary<string, string> data = new Dictionary<string, string>();
                data["name"] = name;
                data["user"] = user;
                data["pass"] = pass;
                return post<BaseResult>("register", data);
            }
            catch (JsonException e)
            {
                Console.WriteLine(e);
            }
            return null;
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
