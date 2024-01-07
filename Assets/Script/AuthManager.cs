using Firebase.Auth;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using TMPro;
using UnityEngine;
using Firebase;
//using Firebase.Database;
using UnityEngine.UI;
using Firebase.Extensions;
using UnityEngine.SceneManagement;
using Oculus.Platform.Models;
using Firebase.Database;
using static OVRPlugin;

public class AuthManager : MonoBehaviour
{
    FirebaseAuth auth;

    [SerializeField]
    private TMP_InputField inputEmail;
    [SerializeField]
    private TMP_InputField inputPassword;
    [SerializeField]
    private TMP_InputField logEmail;
    [SerializeField]
    private TMP_InputField logPassword;
    [SerializeField]
    private TMP_InputField inputUser;
    [SerializeField]
    private TMP_InputField inputCoun;
    [SerializeField]
    private TMP_InputField inputAge;

    public static string UID;

    public GameObject dataUI;
    public GameObject authUI;
    public Timer Timer;
    public GameObject login;
    public GameObject signup;

    DatabaseReference mDatabaseRef;
    DatabaseReference reference;

    public TextMeshProUGUI t;

    void Start()
    {
        auth = FirebaseAuth.DefaultInstance;
        mDatabaseRef = FirebaseDatabase.DefaultInstance.RootReference;
        reference = FirebaseDatabase.DefaultInstance.GetReference("players");

        if (UID != null && Timer != null)
        {
            Login();
        }
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
                UID = newPlayer.User.UserId;
                t.text = UID;
                dataUI.SetActive(true);
                authUI.SetActive(false);
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
                SceneManager.LoadScene(1);
            }
        });
    }

    public void CreateData()
    {
        string newUser = inputUser.text;
        string newCoun = inputCoun.text;
        int newAge = int.Parse(inputAge.text);
        WriteNewUser(newUser, 0, 0, newCoun, newAge, false, 0);
    }

    /// <summary>
    /// Create data on firebase
    /// </summary>
    private void WriteNewUser(string name, int time, int points, string country, int age, bool admin, int num)
    {
        User user = new User(name, time, points, country, age, admin, num);
        string json = JsonUtility.ToJson(user);
        mDatabaseRef.Child("players").Child(UID).SetRawJsonValueAsync(json);
        SceneManager.LoadScene(1);
    }

    public void UpdateData(int time, int points, int num)
    {
        Dictionary<string, object> childUpdates = new Dictionary<string, object>();
        childUpdates["/time"] = time;
        childUpdates["/points"] = points;
        childUpdates["/num"] = num;

        reference.Child(UID).UpdateChildrenAsync(childUpdates);
    }

    public void Login()
    {
        mDatabaseRef.Child("players").GetValueAsync().ContinueWithOnMainThread(task =>
        {
            if (task.IsFaulted)
            {
                //@TODO
                //process error
            }
            else if (task.IsCompleted)
            {
                DataSnapshot ds = task.Result;

                foreach (var v in ds.Children)
                {
                    string data = v.ToString();

                    string playerKey = v.Key;
                    string playerDetails = v.GetRawJsonValue();
                    Debug.LogFormat("Player Key: {0} \n Player Details: {1}", playerKey, playerDetails);

                    User p = JsonUtility.FromJson<User>(playerDetails);

                    if (v.Key == UID)
                    {
                        Timer.orgTime = p.time;
                    }
                }
            }
        });

        SceneManager.LoadScene(2);
    }

    public void noAccount()
    {
        signup.SetActive(true);
        login.SetActive(false);
    }

    public void gotAccount()
    {
        signup.SetActive(false);
        login.SetActive(true);
    }
    
    /*
    public TextMeshProUGUI t;

    private void OnEnable()
    {
        Application.logMessageReceived += Debugt;
    }

    private void OnDisable()
    {
        
        Application.logMessageReceived -= Debugt;
    }

    private void Debugt(string msg, string st, LogType ty)
    {
        t.text += msg + "\n";
    }*/
}
