using Aq.ExpressionJsonSerializer;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public static class JsonNetAdapter
    {
        private static readonly JsonSerializerSettings _settings;

        static JsonNetAdapter()
        {
            var defaultSettings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Objects };
            defaultSettings.Converters.Add(new ExpressionJsonConverter(Assembly.GetAssembly(typeof(User))));
            _settings = defaultSettings;
        }

        public static string Serialize<T>(T obj) => JsonConvert.SerializeObject(obj, _settings);

        public static T Deserialize<T>(string json) => JsonConvert.DeserializeObject<T>(json, _settings);

    }
}
