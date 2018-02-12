using Discord;
using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace xMdb.Modules.Ping.csproj
{
    public class Ping : ModuleBase<SocketCommandContext>
    {
        private object user;

        [Command("help")]
        public async Task PingAsync1()
        {
            EmbedBuilder builder = new EmbedBuilder();

            builder.AddField(":help", "Brings up this panel")
                 .AddField(":creator", "Tells you some information about the bot")
                 .AddField(":kick", "Kicks user")
                 .AddField(":ban", "Bans user")
                 .AddField(":hownottogetbanned", "Brings up a way to not get banned")
                 .AddField(":subscribe", "Tells you how to subscribe");

            ReplyAsync("", false, builder.Build());

        }

        [Command("subscribe")]
        public async Task Subscribing()
        {
            EmbedBuilder builder = new EmbedBuilder();

            builder.WithTitle("Subscribe")
                .WithDescription(description: $"Subscribe here https://www.youtube.com/channel/UC0XUGR2Fv5svN2qqlg0MAjA/subscribe")
                .WithColor(Color.DarkRed);

            await ReplyAsync("", false, builder.Build());}
             
        [Command("hownottogetbanned")]
        public async Task Banning()
        {
            EmbedBuilder builder = new EmbedBuilder();

            builder.WithTitle("How not to get banned")
                .WithDescription(description: $"Well, all you got to do is say '-rep xMdb' it's as simple as 1, 2, 3.")
                .WithColor(Color.DarkRed);

            await ReplyAsync("", false, builder.Build());}

        [Command("creator")]
        public async Task PingAsync()
        {
            EmbedBuilder builder = new EmbedBuilder();

            builder.WithTitle("Creator")
                .WithDescription(description: $"The xMdb bot is a custom bot owned by 'xMdb', and created by 'I can't stop talking'.")
                .WithColor(Color.DarkRed);

            await ReplyAsync("", false, builder.Build());}

        [Command("kick")]
        [RequireUserPermission(GuildPermission.KickMembers)]
        [RequireBotPermission(GuildPermission.KickMembers)]
        public async Task KickUser(IGuildUser user, string reason = "Breaking The Rules.")
        {
            await user.KickAsync(reason);
        }

        [Command("ban")]
        [RequireUserPermission(GuildPermission.BanMembers)]
        [RequireBotPermission(GuildPermission.BanMembers)]
        public async Task BanUser(IGuildUser user, string reason = "Breaking the Rules.")
        {
            await user.Guild.AddBanAsync(user);
        }
    }
}
