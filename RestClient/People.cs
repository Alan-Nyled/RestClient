using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestClient
{

    public class People
    {
        public string? name { get; set; }
        public string? height { get; set; }
        public string? homeworld { get; set; }
        public string? climate { get; set; }

    }


    public class Caller
    {
        public static async Task<Stream> GetData(string url)
        {
            HttpClient client = new();
            return await client.GetStreamAsync(url);
        }
    }

}
