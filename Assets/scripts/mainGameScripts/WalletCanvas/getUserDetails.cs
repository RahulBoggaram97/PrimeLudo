using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using SimpleJSON;


namespace com.impactionalGames.LudoPrime
{
    public class getUserDetails : MonoBehaviour
    {



        private void Start()
        {
            getUserDet();

            playerPermData.setPhoneNumber("7894561230");

            Debug.Log("phone number in the start" + playerPermData.getPhoneNumber());

        }

        public void getUserDet() => StartCoroutine(getUserDeatails_coroutine());

        public void updateUser() => StartCoroutine(updateUser_Coroutine());

        IEnumerator getUserDeatails_coroutine()
        {
            string phone = playerPermData.getPhoneNumber();

            string uri = "https://ludogame-backend.herokuapp.com/api/getUserDetails/" + playerPermData.getPhoneNumber() ;

            Debug.Log(uri);
            using (UnityWebRequest request = UnityWebRequest.Get(uri))
            {
                yield return request.SendWebRequest();
                if(request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError)
                {
                    Debug.Log(request.error);
                }
                else
                {
                    Debug.Log(request.downloadHandler.text);

                    JSONNode node = JSON.Parse(request.downloadHandler.text);

                    //[{"UserId":"1643254696575",
                    //"Phone":"7894561230",
                    //"Joined":"2022-01-27T03:38:17.000Z",
                    //"Name":"prime1643254696575",
                    //"ProfilePic":"undefined",
                    //"Wallet":0,
                    //"Points":100,
                    //"Won":0,
                    //"Lose":0,
                    //"Drawn":0,
                    //"Total":0,
                    //"LastGame":0,
                    //"MatchPoints":null}]

                    Debug.Log(node[0]["UserId"].ToString());

                   
                    playerPermData.setMoney(int.Parse(node[0]["Wallet"].ToString()));

                    Debug.Log("money is :" + node[0]["Wallet"].ToString());
                   
                    
                }
            }
        }


        IEnumerator updateUser_Coroutine()
        {
            Debug.Log("loding");

            string url = "https://ludogame-backend.herokuapp.com/api/updateUser";
            WWWForm form = new WWWForm();
            form.AddField("Phone", playerPermData.getPhoneNumber());
            form.AddField("Name", playerPermData.getUserName());

            using (UnityWebRequest request = UnityWebRequest.Post(url, form))
            {
                yield return request.SendWebRequest();
                if (request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError)
                {
                    Debug.Log(request.error);
                }
                else
                {
                    Debug.Log(request.downloadHandler.text);
                    
                }
            }
        }
    }
}
