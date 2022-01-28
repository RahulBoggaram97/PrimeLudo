using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace com.impactionalGames.LudoPrime
{
    public class authManager : MonoBehaviour
    {
        [Header("Phone no. panel")]
        public GameObject enterPhonePanel;
        public InputField phoneNoField;
        public InputField countyCodeField;

        [Header("OTP Panel")]
        public GameObject enterOtpPanel;
        public InputField OTPField;

      

        [Header("For Debugging")]
        public Text debugText;

        [Header("Singleton Vars")]
        [SerializeField]  public static authManager instance;

        public static event Action<loginState> loginStateChanged;


        [Header("Levels to be Loaded")]
        public string gameMenu;

        private void Awake()
        {
            instance = this;
        }

        private void Start()
        {
            updateLoginState(loginState.enterPhoneNum);
        }

        public loginState state;

        

        public void updateLoginState(loginState newState)
        {
            state = newState;

            switch (state)
            {
                case loginState.enterPhoneNum:
                    handleEnterPhoneNumState();
                    break;
                case loginState.enterOtpNum:
                    handleEnterOtpState();
                    break;
                case loginState.authenticated:
                    handleOnAuthenticated();
                    break;
                case loginState.loggedIn:
                    handleOnLoggedIn();
                    break;
            }

            loginStateChanged?.Invoke(state);

        }

        

        private void handleEnterPhoneNumState()
        {
            enterPhonePanel.SetActive(true);
            enterOtpPanel.SetActive(false);
            countyCodeField.text = "+91";
        }

        private void handleEnterOtpState()
        {
            enterPhonePanel.SetActive(false);
            enterOtpPanel.SetActive(true);
        }

        public void handleOnAuthenticated()
        {
            debugText.text = "authmangare event has been called";
        }

         public void handleOnLoggedIn()
        {
            SceneManager.LoadScene(gameMenu);
        }


    }

    public enum loginState
    {
        enterPhoneNum,
        enterOtpNum,
        authenticated, 
        loggedIn
    }
}