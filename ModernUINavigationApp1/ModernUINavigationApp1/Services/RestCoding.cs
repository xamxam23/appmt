using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer
{

    public class CodingResult : BaseResult
    {
    }
    public class RestCoding
    {
        public static CodingResult scoreCode(string lang, string source)
        {
            try
            {   
                Dictionary<string, string> data = new Dictionary<string, string>();
                data["source"] = source;
                data["language"] = lang;
                string rs = RestClient.post("code", data);
                Console.WriteLine(rs);
                CodingResult r = JsonConvert.DeserializeObject<CodingResult>(rs);
                Console.WriteLine(r);
                return r;
            }
            catch (JsonException e)
            {
                Console.WriteLine(e);
            }
            return null;
        }
    }
}
