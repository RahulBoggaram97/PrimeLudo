using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace com.impactionalGames.LudoPrime
{
    public static class playerPermData 
    {
        //id made by firebase during registration
        public const string LOCAL_ID_PREF_KEY = "firebaseAuthenticatedLocalID";
        public const string EMAIL_ID_PREF_KEY = "firebaseGoolgeAuthenticatedID";
        public const string USERNAME_PREF_KEY = "userName";
        public static string MONEY_PREF_KEY = "money";
        public static string PHONE_NO_PREF_KEY = "phoneNumber";


        //EMAIL
        public static void setEmail(string value)
        {
            PlayerPrefs.SetString(EMAIL_ID_PREF_KEY, value);
        }

        public static string getEmail()
        {
            return PlayerPrefs.GetString(EMAIL_ID_PREF_KEY);
        }

        //LOCAL ID
        public static void setLocalId(string value)
        {
            PlayerPrefs.SetString(LOCAL_ID_PREF_KEY, value);
        }

        public static string getLocalId()
        {
            return PlayerPrefs.GetString(LOCAL_ID_PREF_KEY);
        }

        //USER NAME
        public static void setUserName(string value)
        {
            PlayerPrefs.SetString(USERNAME_PREF_KEY, value);
        }

        public static string getUserName()
        {
            return PlayerPrefs.GetString(USERNAME_PREF_KEY);
        }

        //MONEY
        public static void setMoney(int value)
        {
            PlayerPrefs.SetInt(MONEY_PREF_KEY, value);
        }

        public static int getMoney()
        {
            return PlayerPrefs.GetInt(MONEY_PREF_KEY);  
        }

        //PHONE NUM
        public static void setPhoneNumber(string value)
        {
            PlayerPrefs.SetString(PHONE_NO_PREF_KEY , value);
        }

        public static string getPhoneNumber()
        {
            return PlayerPrefs.GetString(PHONE_NO_PREF_KEY);
        }
    }
}
