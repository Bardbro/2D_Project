using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine.UI; 

public class PlayfabManager : MonoBehaviour
{
    [Header("UI")]
    public Text messageText; // Reference to the UI Text component
    public InputField emailInputField; // Reference to the email input field
    public InputField passwordInputField; // Reference to the password input field

     public static PlayfabManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    } 
    public void RegisterButton()
    {
        if (passwordInputField.text.Length < 6)
        {
            messageText.text = "Password must be at least 6 characters long.";
            return;
        }
        var request = new RegisterPlayFabUserRequest {
            Email = emailInputField.text,
            Password = passwordInputField.text,
            RequireBothUsernameAndEmail = false
        };
        PlayFabClientAPI.RegisterPlayFabUser(request, OnRegisterSuccess, OnError);
    }
    void OnRegisterSuccess(RegisterPlayFabUserResult result)
    {
        messageText.text = "Registration successful. Welcome ";
    }
    public void LoginButton()
    {
       var request = new LoginWithEmailAddressRequest
        {
            Email = emailInputField.text,
            Password = passwordInputField.text
        };
        PlayFabClientAPI.LoginWithEmailAddress(request, OnLoginSuccess, OnError);
    }
    void OnLoginSuccess(LoginResult result)
    {

        messageText.text = "Login successful. Welcome " + result.PlayFabId;
    }
    public void ResetPasswordButton()
    {
       var request = new SendAccountRecoveryEmailRequest
        {
            Email = emailInputField.text,
            TitleId = "156018"
        };
        PlayFabClientAPI.SendAccountRecoveryEmail(request, OnResetPasswordSuccess, OnError);
    }
    void OnResetPasswordSuccess(SendAccountRecoveryEmailResult result)
    {
        messageText.text = "Password reset email sent. Please check your inbox.";
    }
   

   
   
   
   
   
   


   void GetTitleData()
    {
        PlayFabClientAPI.GetTitleData(new GetTitleDataRequest(), OnTitleDataRecieved, OnError);
    }
    void OnTitleDataRecieved(GetTitleDataResult result)
    {
       if (result.Data == null || result.Data.ContainsKey("Message") == false)
       {
        Debug.Log("No message found in title data.");
        return;
       }
       messageText.text = result.Data["Message"];
    }
   
   
   
    void Start()
    {
        
    }
    // public void login(System.Action<bool> callback)
    // {
    //     // Example PlayFab login logic
    //     PlayFabClientAPI.LoginWithCustomID(new LoginWithCustomIDRequest
    //     {
    //         CustomId = SystemInfo.deviceUniqueIdentifier,
    //         CreateAccount = true
    //     },
    //     result =>
    //     {
    //         Debug.Log("PlayFab login successful!");
    //         callback?.Invoke(true);
    //     },
    //     error =>
    //     {
    //         Debug.LogError("PlayFab login failed: " + error.ErrorMessage);
    //         callback?.Invoke(false);
    //     });
        
    // }
    
    public void login(System.Action<bool> callback)
    {   
        // ver 1
        // var request = new LoginWithCustomIDRequest
        // {
        //     CustomId = SystemInfo.deviceUniqueIdentifier,
        //     CreateAccount = true
        // };

        // PlayFabClientAPI.LoginWithCustomID(request, OnSuccess, OnError);
       

       //ver2
        // var request = new LoginWithCustomIDRequest
        // {
        //     CustomId = SystemInfo.deviceUniqueIdentifier,
        //     CreateAccount = true
        // };

        // PlayFabClientAPI.LoginWithCustomID(request,
        //     result =>
        //     {
        //         Debug.Log("Login successful. Welcome " + result.PlayFabId);
        //         GetTitleData();
        //         callback?.Invoke(true); // Notify success
        //     },
        //     error =>
        //     {
        //         Debug.LogError("Error logging in player: " + error.GenerateErrorReport());
        //         callback?.Invoke(false); // Notify failure
        //     });
    }
    void OnSuccess(LoginResult result)
    {
        Debug.Log("Login successful. Welcome " + result.PlayFabId);
        GetTitleData(); 
    }
    void OnError(PlayFabError error)
    {
        messageText.text = error.ErrorMessage;
        Debug.Log("Error logging in player: " + error.GenerateErrorReport());
    }
}
