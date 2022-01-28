using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;
using System.Linq;

namespace com.impactionalGames.LudoPrime
{
    public class EndGameManager : MonoBehaviourPunCallbacks
    {
        public GameObject winImage;
        public GameObject lossImage;
        public static EndGameManager egm;

        public RollinDice[] scoreDice;

        public Text[] ranktext;

        public string levelToLoad;


        public WinnerDecider winDecide;

        private void Start()
        {
            egm = this;
        }
        public void winStarterMethod()
        {
            checkWhichLobby();
        }

        void checkWhichLobby()
        {
            

            if (checkIfItsOneVoneLobby())
            {
                

                winDecide.decideOnevOneWinner();

            }
            else if (!chechIfItsCustomLobby())
            {
                winDecide.decideFourPlayerGameWinner();
            }
            else
            {
                return;
            }
        }

        //deciding which Lobby
        bool checkIfItsOneVoneLobby()
        {
            switch (PhotonNetwork.CurrentLobby.Name)
            {
                case "oneVoneOne":
                    return true;
                case "oneVoneFive":
                    return true;
                case "oneVoneTen":
                    return true;
                case "oneVoneTwentyFive":
                    return true;
                case "oneVoneFifty":
                    return true;
                case "oneVoneHundred":
                    return true;
                default:
                    return false;
            }

        }

        bool chechIfItsCustomLobby()
        {
            switch (PhotonNetwork.CurrentLobby.Name)
            {
                case "customLobby":
                    return true;
                default:
                    return false;
            }

        }

        bool checkIfItsOneWinnerLobby()
        {
            switch (PhotonNetwork.CurrentLobby.Name)
            {
                case "oneWinnerOne":
                    return true;
                case "oneWinnerFive":
                    return true;
                case "oneWinnerTen":
                    return true;
                case "oneWinnerTwentyFive":
                    return true;
                case "oneWinnerFifty":
                    return true;
                case "oneWinnerHundred":
                    return true;
                default:
                    return false;
            }
        }

        bool checkIfItsTwoWinnersLobby()
        {
            switch (PhotonNetwork.CurrentLobby.Name)
            {
                case "twoWinnersOne":
                    return true;
                case "twoWinnersFive":
                    return true;
                case "twoWinnersTen":
                    return true;
                case "twoWinnersTwentyFive":
                    return true;
                case "twoWinnersFifty":
                    return true;
                case "twoWinnersHundred":
                    return true;
                default:
                    return false;
            }
        }

        //declaring wins
        void declareOneVoneGame()
        {
            if(scoreDice[0].score > scoreDice[2].score)
            {
                if (PhotonNetwork.LocalPlayer == PhotonNetwork.PlayerList[0])
                {
                    winImage.SetActive(true);

                    //setting up the leaderboardNames
                    setUpleaderBoardName(0, 1, -1, -1);

                    return;

                }
                else if (PhotonNetwork.LocalPlayer == PhotonNetwork.PlayerList[1])
                {
                    lossImage.SetActive(true);

                    //setting up the leaderboardNames
                    setUpleaderBoardName(0, 1, -1, -1);

                    return;

                }
            }
            else
            {
                if (PhotonNetwork.LocalPlayer == PhotonNetwork.PlayerList[0])
                {
                    lossImage.SetActive(true);

                    //setting up the leaderboardNames
                    setUpleaderBoardName(1, 0, -1, -1);

                    return;


                }
                else if (PhotonNetwork.LocalPlayer == PhotonNetwork.PlayerList[1])
                {
                    winImage.SetActive(true);

                    //setting up the leaderboardNames
                    setUpleaderBoardName(1, 0, -1, -1);

                    return;

                }

            }
        }

        void declareOneWinnerGame()
        {
          Dictionary<int, int> playerRanks = new Dictionary<int, int>();
            playerRanks.Add(0, scoreDice[0].score);
            playerRanks.Add(1, scoreDice[1].score);
            playerRanks.Add(2, scoreDice[2].score);
            playerRanks.Add(3, scoreDice[3].score);

            int i = 0;

            foreach(var item in playerRanks.OrderBy(i => i.Value))
            {
                
               ranktext[i].text = PhotonNetwork.PlayerList[item.Key].NickName;
                i++;
            }





        }



        void setUpleaderBoardName(int rank1, int rank2, int rank3, int rank4)
        {
            ranktext[0].text = PhotonNetwork.PlayerList[rank1].NickName;
            ranktext[1].text = PhotonNetwork.PlayerList[rank2].NickName;

            if(rank3 != -1)
            {
                ranktext[2].text = PhotonNetwork.PlayerList[rank3].NickName;
            }
            else
            {
                return;
            }
            if (rank4 != -1)
            {
                ranktext[3].text = PhotonNetwork.PlayerList[rank4].NickName;
            }
            else
            {
                return;
            }

        }





    }
}
