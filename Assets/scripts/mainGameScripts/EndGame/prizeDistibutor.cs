using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

namespace com.impactionalGames.LudoPrime
{
    public class prizeDistibutor : MonoBehaviour
    {
        public WinnerDecider winDec;

        public tansactApiCaller transact;

        public void distributePrizeOneVOne()
        {
            switch (PhotonNetwork.CurrentLobby.Name)
            {
                case "oneVoneOne":

                   if(winDec.rank == winOrLossState.rankOne)
                    {
                        transact.transferMoney("2.4");
                    }
                    else
                    {
                        transact.transferMoney("-2.4");
                    }
                    break;


                case "oneVoneFive":

                    if (winDec.rank == winOrLossState.rankOne)
                    {
                        transact.transferMoney("12");
                    }
                    else
                    {
                        transact.transferMoney("-12");
                    }
                    break;


                case "oneVoneTen":

                    if (winDec.rank == winOrLossState.rankOne)
                    {
                        transact.transferMoney("24");
                    }
                    else
                    {
                        transact.transferMoney("-24");
                    }
                    break;

                case "oneVoneTwentyFive":

                    if (winDec.rank == winOrLossState.rankOne)
                    {
                        transact.transferMoney("60");
                    }
                    else
                    {
                        transact.transferMoney("-60");
                    }
                    break;

                case "oneVoneFifty":


                    if (winDec.rank == winOrLossState.rankOne)
                    {
                        transact.transferMoney("120");
                    }
                    else
                    {
                        transact.transferMoney("-120");
                    }
                    break;

                case "oneVoneHundred":


                    if (winDec.rank == winOrLossState.rankOne)
                    {
                        transact.transferMoney("240");
                    }
                    else
                    {
                        transact.transferMoney("-240");
                    }
                    break;

                default:
                    break;
            }
        }



    }
}
