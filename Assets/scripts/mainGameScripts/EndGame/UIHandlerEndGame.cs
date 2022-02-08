using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;


namespace com.impactionalGames.LudoPrime
{
    public class UIHandlerEndGame : MonoBehaviourPun
    {
        public EndGameManager endGameManager;
        public WinnerDecider winDec;

        public GameObject leaderBoard;

        public void UpdateLeaderBoard()
        {
           leaderBoard.SetActive(true);
            rpc_updateLeaderBoard();

            //photonView.RPC("rpc_updateLeaderBoard", RpcTarget.AllBufferedViaServer);
        }

        //[PunRPC]
        void rpc_updateLeaderBoard()
        {
            endGameManager.ranktext[0].text = PhotonNetwork.PlayerList[winDec.rank1Index].NickName;
            endGameManager.ranktext[1].text = PhotonNetwork.PlayerList[winDec.rank2Index].NickName;

            if (PhotonNetwork.PlayerList[2] != null)
            {

                endGameManager.ranktext[2].text = PhotonNetwork.PlayerList[winDec.rank3Index].NickName;
                endGameManager.ranktext[3].text = PhotonNetwork.PlayerList[winDec.rank4Index].NickName;
            }
            else
            {
                return;
            }
        }
    }

}