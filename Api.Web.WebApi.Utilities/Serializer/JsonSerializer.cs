using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Web.WebApi.Utilities.Serializer
{
    public  class JsonSerializer
    {
        public static T Deserialize<T>(string SerializedString)
        {
            T o = JsonConvert.DeserializeObject<T>(SerializedString);
            return o;
        }
        public static string Serialize<T>(T ObjectToSerialize)
        {
            //var serializer = new DataContractJsonSerializer(typeof(T));
            //var _MemoryStream = new MemoryStream();
            //serializer.WriteObject(_MemoryStream, ObjectToSerialize);
            //var JsonTradeItem = Encoding.UTF8.GetString(_MemoryStream.ToArray());
            //return JsonTradeItem;
            return JsonConvert.SerializeObject(ObjectToSerialize, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
        }
    }
}
