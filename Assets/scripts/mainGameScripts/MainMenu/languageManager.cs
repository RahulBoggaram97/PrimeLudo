using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace com.impactionalGames.LudoPrime
{
    public class languageManager : MonoBehaviour
    {


        public Dropdown langDrop;
  

        public void Start()
        {
            updateLanguage();
        }


        public List<Text> textList = new List<Text>();

        public List<string> english = new List<string>();
        public List<string> hindi = new List<string>();

        

        public void updateLanguage()
        {
            for (int i = 0; i < textList.Count; i++)
            {
                if (langDrop.value == 1)
                {
                    textList[i].text = hindi[i];
                }
                else
                {
                    textList[i].text = english[i];
                }
            }

        }

    }

}