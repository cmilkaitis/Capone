using System;
using System.Threading.Tasks;
using Discord;
using Discord.WebSocket;
using Discord.Commands;
using Microsoft.Extensions.DependencyInjection;

namespace capone
{
    public class Program
    {
        private DiscordSocketClient _client;
        private readonly string DiscordToken = "NzEzODExMjQ5NjI4MDUzNTQ0.XslsrA.QMTRSzsRJOxO0Tkbjl1Nt5Vd0Kk";

        public static void Main(string[] args)
            => new Program().MainAsync().GetAwaiter().GetResult();

        public async Task MainAsync()
        {
            _client = new DiscordSocketClient();
            _client.Log += Log;
            
            var services = ConfigureServices();
            await services.GetRequiredService<CommandHandler>().InstallCommandsAsync(services);

            await _client.LoginAsync(TokenType.Bot, DiscordToken);
            await _client.StartAsync();
            
            await Task.Delay(-1);
        }

         private IServiceProvider ConfigureServices()
        {
            return new ServiceCollection()
                .AddSingleton(_client)
                .AddSingleton<CommandService>()
                .AddSingleton<CommandHandler>()
                .BuildServiceProvider();
        }

        private Task Log(LogMessage msg)
        {
            Console.WriteLine(msg.ToString());
            return Task.CompletedTask;
        }
    }
}
