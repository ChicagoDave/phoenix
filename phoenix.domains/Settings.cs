using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Json;
//using Newtonsoft.Json;
using System.Runtime.CompilerServices;

namespace phoenix.domains
{
    public class Settings
    {
        public static Neo4jSettings Neo4jSettings { get; set; }

        public static void Load()
        {
            Neo4jSettings.Load();
        }

    }

    public class Neo4jSettings
    {

        public static void Load()
        {
            var pathWithEnv = @"%USERPROFILE%\.neo4j\neo4j-credentials.json";
            var filePath = Environment.ExpandEnvironmentVariables(pathWithEnv);

            string contents = File.ReadAllText(filePath);
            var settings = JsonSerializer.Deserialize<Neo4jSettings>(contents);

            Settings.Neo4jSettings = new Neo4jSettings();
            Settings.Neo4jSettings.neo4jURI = settings.neo4jURI;
            Settings.Neo4jSettings.neo4jUser = settings.neo4jUser;
            Settings.Neo4jSettings.neo4jPassword = settings.neo4jPassword;
        }

        public string neo4jURI { get; set; }
        public string neo4jUser { get; set; }
        public string neo4jPassword { get; set; }

    }
}
