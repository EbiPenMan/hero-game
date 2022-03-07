using System;
using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Nakama;
using ProGraphGroup.Packages.Utility;
using Nakama.TinyJson;
using Newtonsoft.Json;
using ProGraphGroup.Games.Hero.Server;
using ProGraphGroup.Games.Hero.Server.Models;
using ProGraphGroup.Games.Hero.Server.Models.Response;
using ProGraphGroup.General.Utility;
using UnityEngine;

namespace ProGraphGroup.Games.Hero
{
    public class MultiPlayerManager : MonoSingletonExtend<MultiPlayerManager>
    {
        private ISocket socket;
        private List<IUserPresence> connectedOpponents;
        private IMatchmakerTicket matchmakerTicket;
        private IMatchmakerMatched matchmakerMatched;
        private IMatch match;
        
        public async UniTask SendMMRequest()
        {
            await CreateSocket();

            socket.ReceivedMatchmakerMatched += OnMatched;
            socket.ReceivedMatchPresence += OnReceivedMatchPresence;

            socket.ReceivedMatchState  += OnReceivedMatchState;

            await SendMachMakingRequest();


        }

        public async UniTask CreateSocket()
        {
            socket = ServerManager.Instance.client.NewSocket();
            bool appearOnline = true;
            int connectionTimeout = 30;
            await socket.ConnectAsync(ServerManager.Instance.session, appearOnline, connectionTimeout);
        }

        public async UniTask SendMachMakingRequest()
        {
            int minPlayers = 2;
            int maxPlayers = 2;
            string query = "+trophy:>100 mode:arena";
            Dictionary<string, string> stringProperties = new Dictionary<string, string> {{"mode", "arena"}};
            Dictionary<string, double> numericProperties = new Dictionary<string, double> {{"skill", 100}};
            matchmakerTicket =
                await socket.AddMatchmakerAsync(query, minPlayers, maxPlayers, stringProperties, numericProperties);
        }
        public async UniTask SendMachMakingCancelRequest()
        {
            await socket.RemoveMatchmakerAsync(matchmakerTicket);
        }
        public async UniTask SendJoinFoundedMatch()
        {
            match = await socket.JoinMatchAsync(matchmakerMatched);
            foreach (var presence in match.Presences)
            {
                Logger.Info(String.Format("User id '{0}' name '{1}'.", presence.UserId, presence.Username));
            }
        }


        public async void OnMatched(IMatchmakerMatched matchmakerMatched)
        {
            matchmakerMatched = matchmakerMatched;
            Logger.Info("Received: {0}", matchmakerMatched.ToJson());
            var opponents = string.Join(",\n  ", matchmakerMatched.Users); // printable list.
            Logger.Info("Matched opponents: [{0}]", opponents);

            await SendJoinFoundedMatch();

        }

        public async void OnReceivedMatchPresence(IMatchPresenceEvent matchPresenceEvent)
        {
            connectedOpponents = new List<IUserPresence>(2);
            foreach (var presence in matchPresenceEvent.Leaves)
            {
                connectedOpponents.Remove(presence);
            }

            connectedOpponents.AddRange(matchPresenceEvent.Joins);

            // Remove yourself from connected opponents.
            // connectedOpponents.Remove(this);
            Console.WriteLine("Connected opponents: [{0}]", string.Join(",\n  ", connectedOpponents));
        }

        public async UniTask SendMatchState(int opCode , IMatchState newState)
        {
            socket.SendMatchStateAsync(match.Id, opCode, newState.ToJson());
        }

        public async void OnReceivedMatchState( IMatchState newState )
        {
            var enc = System.Text.Encoding.UTF8;
            var content = enc.GetString(newState.State);

            switch (newState.OpCode)
            {
                case 101:
                    Console.WriteLine("A custom opcode.");
                    break;
                default:
                    Console.WriteLine("User '{0}'' sent '{1}'", newState.UserPresence.Username, content);
            }
        }
    }
}