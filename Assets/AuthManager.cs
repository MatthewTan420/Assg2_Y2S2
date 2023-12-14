using Firebase.Auth;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using Firebase;
using Firebase.Database;
using UnityEngine.UI;
using Firebase.Extensions;
using System.Data.Common;

public class AuthManager : MonoBehaviour
{
    Firebase.Auth.FirebaseAuth auth;

    [SerializeField]
    private TMP_InputField inputEmail;

    [SerializeField]
    private TMP_InputField inputPassword;

    [SerializeField]
    private TMP_InputField logEmail;

    [SerializeField]
    private TMP_InputField logPassword;

    private void Awake()
    {
        auth = FirebaseAuth.DefaultInstance;
    }

    /// <summary>
    /// Create new account for user
    /// </summary>
    public void SignUp()
    {
        string newEmail = inputEmail.text;
        string newPassword = inputPassword.text;

        auth.CreateUserWithEmailAndPasswordAsync(newEmail, newPassword).ContinueWithOnMainThread(task =>
        {
            //perform task handling
            if (task.IsFaulted || task.IsCanceled)
            {
                Debug.LogError("Sorry, there was an error creating your new account, ERROR: " + task.Exception);
                return;//exit from the attempt
            }
            else if (task.IsCompleted)
            {
                Firebase.Auth.AuthResult newPlayer = task.Result;
                //do anything you want after player creation eg. create new player
            }
        });
    }

    /// <summary>
    /// Checks if account exist in database
    /// </summary>
    public void SignInUser()
    {
        string email = logEmail.text;
        string password = logPassword.text;
        auth.SignInWithEmailAndPasswordAsync(email, password).ContinueWithOnMainThread(authTask =>
        {
            if (authTask.IsCanceled)
            {
                Debug.LogError("SignInWithEmailAndPassword Sync was cancelled");
                return;
            }
            if (authTask.IsFaulted)
            {
                Debug.LogError("SignInWithEmailAndPassword Async encountered an error: " + authTask.Exception);
                return;
            }
            FirebaseUser currentPlayer = authTask.Result.User;
            if (currentPlayer != null)
            {
                Debug.Log("login success");
            }
        });
    }

}
