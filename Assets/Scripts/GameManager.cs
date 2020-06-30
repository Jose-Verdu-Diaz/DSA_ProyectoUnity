using UnityEngine;
using System.Collections;
using System.Collections.Generic;        //Allows us to use Lists. 
using Completed;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public static GameManager instance = null;                //Static instance of GameManager which allows it to be accessed by any other script.
    private BoardManager boardScript;                        //Store a reference to our BoardManager which will set up the level.

    private string stringNivel;
    private int levelNumber;

    private AndroidJavaObject currentActivity;

    //Awake is always called before any Start functions
    void Awake()
    {
        stringNivel = "X,X,X,X,X;X,E.C,,O.B,X;X,X,X,X,X";
        levelNumber=1;

        if (Application.platform == RuntimePlatform.Android)
        {
            AndroidJavaClass UnityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
            currentActivity = UnityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
            AndroidJavaObject intent = currentActivity.Call<AndroidJavaObject>("getIntent");
            bool hasExtra = intent.Call<bool>("hasExtra", "arguments");
            if (hasExtra)
            {
                AndroidJavaObject extras = intent.Call<AndroidJavaObject>("getExtras");
                stringNivel = extras.Call<string>("getString", "arguments");
                levelNumber = extras.Call<int>("getInt", "levelNumber");
            }
        }

        //Check if instance already exists
        if (instance == null)
            //if not, set instance to this
            instance = this;

        //If instance already exists and it's not this:
        else if (instance != this)
            //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
            Destroy(gameObject);

        //Sets this to not be destroyed when reloading scene
        DontDestroyOnLoad(gameObject);

        //Get a component reference to the attached BoardManager script
        boardScript = GetComponent<BoardManager>();

        //Call the InitGame function to initialize the first level 
        InitGame();
    }

    //Initializes the game for each level.
    void InitGame()
    {
        //Call the SetupScene function of the BoardManager script, pass it current level number.
        boardScript.SetupScene(stringNivel, levelNumber);

    }

    public void finalizarPartida()
    {
        //Debug.Log(GameObject.Find("Canvas").transform.Find("Time").GetComponent<Text>().text);

        int score = 400;
        int time = 30;
        string mask = "FALSE";
        levelNumber = 1;
        string completed = "TRUE";
        currentActivity.Call("onGameFinish", score, time, mask, levelNumber, completed);
    }
}
