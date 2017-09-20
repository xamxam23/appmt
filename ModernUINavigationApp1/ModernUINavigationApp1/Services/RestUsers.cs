using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer
{
    public class GetUsersResponse : BaseResult
    {
        public List<User> data { get; set; }
    }
    public class User
    {
        public int id { get; set; }
        public string name { get; set; }
        public string user { get; set; }
        public string cv { get; set; }       
    }
    public class RestUsers
    {
        public static BaseResult login(string user, string pass)
        {
            try
            {
                Dictionary<string, string> data = new Dictionary<string, string>();
                data["user"] = user;
                data["pass"] = pass;
                return RestClient.post<BaseResult>("login", data);
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
                return RestClient.post<BaseResult>("register", data);
            }
            catch (JsonException e)
            {
                Console.WriteLine(e);
            }
            return null;
        }

        public static BaseResult getUsers()
        {
            try
            {
                Dictionary<string, string> data = new Dictionary<string, string>();
                return RestClient.post<GetUsersResponse>("getusers", data);
            }
            catch (JsonException e)
            {
                Console.WriteLine(e);
            }
            return null;
        }

        public static BaseResult updateCV(string user, string cv)
        {
            try
            {
                Dictionary<string, string> data = new Dictionary<string, string>();
                data["user"] = user;
                data["cv"] = cv;
                return RestClient.post<BaseResult>("updatecv", data);
            }
            catch (JsonException e)
            {
                Console.WriteLine(e);
            }
            return null;
        }
    }
}
