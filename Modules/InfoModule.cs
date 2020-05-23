using Discord.Commands;
using System.Threading.Tasks;

public class InfoModule : ModuleBase<SocketCommandContext>
{
    [Command("say")]
	[Summary("Echoes a message.")]
	public Task SayAsync([Remainder] [Summary("The text to echo")] string echo)
		=> ReplyAsync(echo);
}