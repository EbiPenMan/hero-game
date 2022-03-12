using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Cysharp.Threading.Tasks;
using Nakama;
using ProGraphGroup.Packages.Utility;
using Nakama.TinyJson;
using Newtonsoft.Json;
using ProGraphGroup.Games.Hero.Server;
using ProGraphGroup.Games.Hero.Server.Models;
using ProGraphGroup.Games.Hero.Server.Models.Response;
using ProGraphGroup.Games.Hero.UiManagers;
using ProGraphGroup.General.Utility;
using UnityEngine;
using UnityEngine.UI;

namespace ProGraphGroup.Games.Hero
{
    public class MultiPlayerManager : MonoSingletonExtend<MultiPlayerManager>
    {
        private ISocket socket;
        private List<IUserPresence> connectedOpponents;
        private IMatchmakerTicket matchmakerTicket;
        private IMatchmakerMatched matchmakerMatched;
        private IMatch match;

        protected override void Awake()
        {
            base.Awake();
            MainMenuUiManager.Instance.btn_arenaMatch.onClick.AddListener(() => { InitNewMatchMaking(); });
        }

        public async UniTask InitNewMatchMaking()
        {
            CreateSocket();
            await ConnectSocket();
            await SendMatchMakingRequest();
        }

        public void CreateSocket()
        {
            socket = ServerManager.Instance.client.NewSocket();

            socket.ReceivedMatchmakerMatched -= OnMatched;
            socket.ReceivedMatchmakerMatched += OnMatched;
            socket.ReceivedMatchPresence -= OnReceivedMatchPresence;
            socket.ReceivedMatchPresence += OnReceivedMatchPresence;
            socket.ReceivedMatchState -= OnReceivedMatchState;
            socket.ReceivedMatchState += OnReceivedMatchState;

            socket.Connected += () => { Logger.Info("socket.Connected"); };
            socket.Closed += () => { Logger.Info("socket.Closed"); };
        }

        public async UniTask ConnectSocket()
        {
            Logger.Info("ConnectSocket");
            try
            {
                await socket.ConnectAsync(ServerManager.Instance.session, true, 30);
                Logger.Info("ConnectSocket after");
            }
            catch (Nakama.ApiResponseException ex)
            {
                Logger.Info(String.Format("Error ConnectSocket: {0}:{1}", ex.StatusCode, ex.Message));
            }
        }


        public async UniTask SendMatchMakingRequest()
        {
            Logger.Info("SendMatchMakingRequest");
            int minPlayers = 2;
            int maxPlayers = 2;
            long trophy = 100;
            string query = String.Format("+trophy:>={0} +trophy:<={1} mode:arena", trophy - 20, trophy + 20);
            Dictionary<string, string> stringProperties = new Dictionary<string, string> {{"mode", "arena"}};
            Dictionary<string, double> numericProperties = new Dictionary<string, double> {{"trophy", trophy}};
            try
            {
                matchmakerTicket =
                    await socket.AddMatchmakerAsync(query, minPlayers, maxPlayers, stringProperties, numericProperties);
                    // await socket.AddMatchmakerAsync();
                Logger.Info("SendMatchMakingRequest after send matchmakerTicket: ", matchmakerTicket.Ticket);
            }
            catch (Nakama.ApiResponseException ex)
            {
                Logger.Info(String.Format("Error SendMachMakingRequest: {0}:{1}", ex.StatusCode, ex.Message));
            }
        }

        public async UniTask SendMachMakingCancelRequest()
        {
            Logger.Info("SendMachMakingCancelRequest");
            try
            {
                await socket.RemoveMatchmakerAsync(matchmakerTicket);
            }
            catch (Nakama.ApiResponseException ex)
            {
                Logger.Info(String.Format("Error SendMachMakingCancelRequest: {0}:{1}", ex.StatusCode, ex.Message));
            }
        }

        public async UniTask SendJoinFoundedMatch()
        {
            Logger.Info("SendJoinFoundedMatch");
            try
            {
                match = await socket.JoinMatchAsync(matchmakerMatched);
            }
            catch (Nakama.ApiResponseException ex)
            {
                Logger.Info(String.Format("Error SendJoinFoundedMatch: {0}:{1}", ex.StatusCode, ex.Message));
            }

            foreach (var presence in match.Presences)
            {
                Logger.Info(String.Format("User id '{0}' name '{1}'.", presence.UserId, presence.Username));
            }
        }


        public async void OnMatched(IMatchmakerMatched matchmakerMatched)
        {
            Logger.Info("OnMatched");
            matchmakerMatched = matchmakerMatched;
            Logger.Info("OnMatched Received: {0}", matchmakerMatched.ToJson());
            var opponents = string.Join(",\n  ", matchmakerMatched.Users); // printable list.
            Logger.Info("OnMatched opponents: [{0}]", opponents);

            await SendJoinFoundedMatch();
        }

        public async void OnReceivedMatchPresence(IMatchPresenceEvent matchPresenceEvent)
        {
            Logger.Info("OnReceivedMatchPresence");
            connectedOpponents = new List<IUserPresence>(2);
            foreach (var presence in matchPresenceEvent.Leaves)
            {
                connectedOpponents.Remove(presence);
            }

            connectedOpponents.AddRange(matchPresenceEvent.Joins);

            // Remove yourself from connected opponents.
            // connectedOpponents.Remove(this);
            Logger.Info("Connected opponents: [{0}]", string.Join(",\n  ", connectedOpponents));
        }

        public async UniTask SendMatchState(MatchOpCode opCode, IMatchState newState)
        {
            Logger.Info("SendMatchState");
            try
            {
                await socket.SendMatchStateAsync(match.Id, (long) opCode, newState.ToJson());
            }
            catch (Nakama.ApiResponseException ex)
            {
                Logger.Info(String.Format("Error SendMatchState: {0}:{1}", ex.StatusCode, ex.Message));
            }
        }

        public async void OnReceivedMatchState(IMatchState newState)
        {
            Logger.Info("OnReceivedMatchState");
            Encoding enc = System.Text.Encoding.UTF8;
            String content = enc.GetString(newState.State);
            Logger.Info("OnReceivedMatchState newState: ", content);

            switch ((MatchOpCode) newState.OpCode)
            {
                case MatchOpCode.EndTurn:
                    break;
                case MatchOpCode.SelectCard:
                    break;
                case MatchOpCode.DeselectHeroCards:
                    break;
                case MatchOpCode.ChangeState:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }


    public enum MatchOpCode : long
    {
        EndTurn = 101L,
        SelectCard = 102L,
        DeselectHeroCards = 103L,
        ChangeState = 104L
    }
}