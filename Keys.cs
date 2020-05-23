using Newtonsoft.Json.Linq;
using System.IO;

public class Keys 
{
    public string BotToken
    {
        get 
        {
            string json = File.ReadAllText("./Private/keys.json");
            return JToken.Parse(json).SelectToken("BotToken").Value<string>();
        }
    }
}