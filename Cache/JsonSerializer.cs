using System.Text;
using Newtonsoft.Json;

namespace Cache
{
    public class JsonSerializer : Microsoft.Web.Redis.ISerializer
    {
        private static readonly JsonSerializerSettings Settings = new JsonSerializerSettings() { TypeNameHandling = TypeNameHandling.All };

        public byte[] Serialize(object data)
        {
            return Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(data, Settings));
        }

        public object Deserialize(byte[] data)
        {
            return data == null ? null : JsonConvert.DeserializeObject(Encoding.UTF8.GetString(data), Settings);
        }
    }
}
