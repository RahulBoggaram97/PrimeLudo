using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

namespace com.impactionalGames.LudoPrime
{
    public class EndGameManager : MonoBehaviourPunCallbacks
    {
        public GameObject cellibrationPrefab;
        public static EndGameManager egm;

        int winnerCount = 0;

        public string levelToLoad;

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
            
                if (PhotonNetwork.CurrentLobby.Name == "oneVone")
                {
                    showCellibration();
                    endGame();
                }
                if (PhotonNetwork.CurrentLobby.Name == "oneWinner")
                {
                    showCellibration();
                    endGame();
                }
                if (PhotonNetwork.CurrentLobby.Name == "twoWinners")
                {
                    checkWinnersCount();
                }
                if (PhotonNetwork.CurrentLobby.Name == "threeWinners")
                {
                    checkWinnersCount();
                }
                else
                {
                    return;
                }
            
        }

        void showCellibration()
        {
            if (PhotonNetwork.LocalPlayer.IsLocal)
            {
                cellibrationPrefab.SetActive(true);
            }   
            PhotonNetwork.LeaveRoom();
        }

        

        void checkWinnersCount()
        {
            if(winnerCount == 0)
            {
                firstWinner();
                winnerCount = 1;
            }
            if(winnerCount == 1)
            {
                secondWinner();
                winnerCount = 2;
            }
            if (winnerCount == 2)
            {
                thirdWinner();
            }
            else return;
        }

        void firstWinner()
        {
            GameManager.gm.totalPlayersCanPlay = 3;
            GameManager.gm.rollingDiceList.Remove(GameManager.gm.rolleddice);
            GameManager.gm.RollingDiceManager();
        }

        void secondWinner()
        {
            
            if (PhotonNetwork.CurrentLobby.Name == "twoWinners")
            {
                showCellibration();
                endGame();
            }
            else
            {
                GameManager.gm.totalPlayersCanPlay = 2;
                GameManager.gm.rollingDiceList.Remove(GameManager.gm.rolleddice);
                GameManager.gm.RollingDiceManager();

            }
        }

        void thirdWinner()
        {
            showCellibration();
            endGame();
        }

        void endGame()
        {
            PhotonNetwork.LeaveRoom();

        }

        public override void OnLeftRoom()
        {
            PhotonNetwork.LoadLevel(levelToLoad);
        }
    }
}
