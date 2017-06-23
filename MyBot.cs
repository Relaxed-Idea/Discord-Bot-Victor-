using Discord;
using Discord.Commands;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VictorBot
{
    class MyBot
    {
        DiscordClient discord;
        CommandService command;

        public MyBot()
        {
            discord = new DiscordClient(x =>
            {
                x.LogLevel = LogSeverity.Info;
                x.LogHandler = Log;
            });

            discord.UsingCommands(x =>
            {
                x.PrefixChar = '■';
                x.AllowMentionPrefix = true;
            });

            command = discord.GetService<CommandService>();

            RegisterPurgeCommand();

            command.CreateCommand("Dustin")
                .Do(async (e) =>
                {
                    await e.Channel.SendMessage("Sir Dustin, what would happen if a meteor hit your house?");
                });

            command.CreateCommand("Soup 2")
                .Do(async (e) =>
                {
                    await e.Channel.SendMessage("Person 1: I'M AT THE SOUP STORE! Person 1: WHY ARE YOU BUYING CLOTHES AT THE SOUP STORE!? Person 1: fUCK YOU!");
                });

            command.CreateCommand("Soup 1")
                .Do(async (e) =>
                {
                    await e.Channel.SendMessage("Person 1: Yo, what's up. Person 2: I need your help, can you come here. Person 1: I can't, I'm buying clothes. Person 2: Alright, well hurry up and come over here. Person 1:I can't find them. Person 2: What do you mean you can't find them? Person 1: I can't find them there's only soup. Person 2: ...what do you mean there's only soup? Person 1: It means there's only soup! Person 2: Well then get out of the soup aisle! Person 1: Alright you don't have to shout at me! Person 1: There's more soup. Person 2: What do you mean there's more soup!? Person 1: There's just more soup. Person 2: Go into the next aisle! Person 1: There's still soup. Person 2: Where ARE YOU RIGHT NOW!? Person 1: I'm at Soup! Person 2: WHAT DO YOU MEAN YOU'RE AT SOUP!? Person 1: I'm mean I'm at Soup! Person 2: WHAT STORE ARE YOU IN?");
                });

            discord.ExecuteAndWait(async () =>
            {
                await discord.Connect("MzIxNDg4NzAxMjIzODYyMjcz.DBfzDw.dIu2DQeGm331ACLHhOKG-f58KGE", TokenType.Bot);
            });

        }
        private void RegisterPurgeCommand()
        {
            command.CreateCommand("Purge")
                .Do(async (e) =>
                {
                    Message[] messagesToDelete;
                    messagesToDelete = await e.Channel.DownloadMessages(20);

                    await e.Channel.DeleteMessages(messagesToDelete);
                });
        }

        private void Log(object sender, LogMessageEventArgs e)
        {
                Console.WriteLine(e.Message);
        }
    }
}
