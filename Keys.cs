using Newtonsoft.Json.Linq;
using System.IO;

public class Keys 
{
    public string BotToken
    {
        get 
        {
            StreamReader file = File.OpenText("./keys.json");
            string json = file.ReadToEnd();
            return JToken.Parse(json).SelectToken("BotToken").Value<string>();
        }
    }
}