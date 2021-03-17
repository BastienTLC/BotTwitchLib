using System;
using TwitchLib.Client;
using TwitchLib.Client.Events;
using TwitchLib.Client.Models;
using TwitchLib.Communication.Events;

namespace FranklinBot
{
    internal class Bot
    {
        ConnectionCredentials creds = new ConnectionCredentials(ChannelInformation.ChannelName, ChannelInformation.BotToken);
        TwitchClient client;
        internal void Connect(bool isLogging)
        {
            client = new TwitchClient();
            client.Initialize(creds, ChannelInformation.ChannelName);

            Console.WriteLine("[FKBOT]: Connecting...");

            if (isLogging)
            {
                client.OnLog += client_Onlog;
            }

            client.OnError += Client_OnError;
            client.OnMessageReceived += Client_OnMessageReceived;
            client.OnChatCommandReceived += Client_OnChatCommandReceived;
           
            client.Connect();
            client.OnConnected += Client_OnConnected;
        }

        private void Client_OnConnected(object sender, OnConnectedArgs e)
        {
            Console.WriteLine("[FKBOT]: Connected");
        }

        private void Client_OnChatCommandReceived(object sender, OnChatCommandReceivedArgs e)
        {
            switch (e.Command.CommandText.ToLower())  //Lis les commandes faite pas un utilisateur lambda.
            {
                case "salut":
                    client.SendMessage(ChannelInformation.ChannelName, $"Ok @{e.Command.ChatMessage.DisplayName}");
                    break;
            }
        }

        private void Client_OnMessageReceived(object sender, OnMessageReceivedArgs e)
        {
            Console.WriteLine($"[{e.ChatMessage.DisplayName}]: {e.ChatMessage.Message}");
        }

        private void Client_OnError(object sender, OnErrorEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void client_Onlog(object sender, OnLogArgs e)
        {
            Console.WriteLine(e.Data);
        }

        internal void Disconnect()
        {
            Console.WriteLine("[FKBOT]: Disdonnecting...");
            client.Disconnect();
            Console.WriteLine("[FKBOT]: Disconect");

        }
    }
}