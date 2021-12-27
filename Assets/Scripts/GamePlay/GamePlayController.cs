using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GamePlayController : MonoBehaviour
{
    public static GamePlayController instance;

    [HideInInspector] public int selectedCharacter = 0;

    [SerializeField] private int char2UnlockSore = 10, char3UnlockScore = 20;

    [SerializeField] private GameObject[] players;
    
    
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start()
    {
        //PlayerPrefs.DeleteAll();///////
        int gameData = DataManger.GetDate(TagManager.DATAINITIALIZED);
      
        if (gameData == 0)
        {
            //первый раз зпустил
            selectedCharacter = 0;
            DataManger.SaveData(TagManager.SELECTEDCHARACTERDATA,selectedCharacter);
            DataManger.SaveData(TagManager.HIGHSCOREDATA,0);
            
            DataManger.SaveData(TagManager.CHARACTERDATA+ "0",1);
            DataManger.SaveData(TagManager.CHARACTERDATA+ "1",1);
            DataManger.SaveData(TagManager.CHARACTERDATA+ "2",1);
            
            DataManger.SaveData(TagManager.DATAINITIALIZED,1);
        }else if (gameData == 1)
        {
            selectedCharacter = DataManger.GetDate(TagManager.SELECTEDCHARACTERDATA);
        }
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    
    private void OnSceneLoaded(Scene scene, LoadSceneMode sceneMode)
    {
        if (scene.name == TagManager.GAMEPLAYSCENENAME)
        {
            
            Instantiate(players[selectedCharacter]);
            
            Camera.main.GetComponent<CameraFollow>().FindPlayerRef();
        }
        
    }
}
