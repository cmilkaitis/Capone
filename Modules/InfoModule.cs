using Discord.Commands;
using System.Threading.Tasks;
using System.Timers;
using System;

public class InfoModule : ModuleBase<SocketCommandContext>
{
    [Command("say")]
	[Summary("Echoes a message.")]
	public Task SayAsync([Remainder] [Summary("The text to echo")] string echo)
		=> ReplyAsync(echo);

	[Command("start")]
	[Summary("Starts the timer.")]
	public async Task StartAsync() {

		TimeSpan t = TimeSpan.FromMilliseconds(10000);
		string defaultTime = string.Format($"{t.Minutes:D2}m:{t.Seconds:D2}s");

		await ReplyAsync($"{defaultTime}. The clock's tickin'.");
		var timer = new Timer(1000);
		timer.Elapsed += HandleTimerElapsed;
		timer.Start();

		await Task.Delay(t);
		timer.Stop();
		await ReplyAsync("Next cronie.");
	}

	[Command("yeet")]
	public Task Yeet() => ReplyAsync("Get outta hea!!");

	public void HandleTimerElapsed(object sender, ElapsedEventArgs e)
	{
		ReplyAsync(".");
	}
}