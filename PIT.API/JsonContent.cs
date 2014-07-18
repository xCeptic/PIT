using System.Net.Http;
using System.Text;

namespace PIT.API
{
    public class JsonContent : StringContent
    {
        public JsonContent(string content) : base(content, Encoding.UTF8, "application/json")
        {
        }
    }
}