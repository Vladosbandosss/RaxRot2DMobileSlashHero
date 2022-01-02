using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    [SerializeField]private AudioSource bgAudio, gameOverAudio;

    [SerializeField] private AudioClip bgMusic,
        mainMenuMusic,
        playerAttackSound,
        playerJumpSound,
        playerDeadSound,
        enemyAttackSound,
        enemyDeadSound,
        collectableSound,
        destroyObstacleSound;
    
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
        PlayBGMusic(true);
        }
        else
        {
           PlayBGMusic(false);
        }
    }

    private void PlayBGMusic(bool gamePlay)
    {
        if (gamePlay)
        {
            bgAudio.clip = bgMusic;
        }
        else
        {
            bgAudio.clip = mainMenuMusic;
        }
        bgAudio.Play();
    }

     public void PlayGameOverSound()
     {
         gameOverAudio.volume = 1f;
        gameOverAudio.Play();
     }

     public void PlayAttackSound()
     {
         AudioSource.PlayClipAtPoint(playerAttackSound,Camera.main.transform.position);
        
     }

     public void PlayJumpSound()
     {
         AudioSource.PlayClipAtPoint(playerJumpSound,Camera.main.transform.position);
        
     }

     public void PlayerDeathSound()
     {
         AudioSource.PlayClipAtPoint(playerDeadSound,Camera.main.transform.position);
     }

     public void EnemyAttackSound()
     {
         AudioSource.PlayClipAtPoint(enemyAttackSound,Camera.main.transform.position);
         
     }

     public void EnemyDeadSound()
     {
         AudioSource.PlayClipAtPoint(enemyDeadSound,Camera.main.transform.position);
     }

     public void CollectableSound()
     {
         AudioSource.PlayClipAtPoint(collectableSound,Camera.main.transform.position);
     }

     public void ObstacleDestroySound()
     {
         AudioSource.PlayClipAtPoint(destroyObstacleSound,Camera.main.transform.position);
     }
}
