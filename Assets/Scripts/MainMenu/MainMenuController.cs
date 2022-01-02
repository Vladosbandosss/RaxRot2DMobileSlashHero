using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
   [SerializeField] private GameObject characterSelectMenuPanel;

   [SerializeField] private Text highScore;

   private CharacterSelectMenu _characterSelectMenu;

   private string HSCORE = "hightScore";
   
   private void Start()
   {
      
      if (PlayerPrefs.HasKey(HSCORE))
     {
        highScore.text ="HighScore: " + PlayerPrefs.GetInt(HSCORE).ToString() +"m";
     }
     else
     {
        highScore.text ="HighScore:" + 0 + "m";
     }
     
      _characterSelectMenu = GetComponent<CharacterSelectMenu>();
   }

   public void OpenCloseMenu(bool open)
   {
      if (open)
      {
         _characterSelectMenu.InitializeCharMenu();
         
      }
      characterSelectMenuPanel.SetActive(open);
   }

   public void SelectCharacter()
   {
      int selectedChar = int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);

      GamePlayController.instance.selectedCharacter = selectedChar;
      
      DataManger.SaveData(TagManager.SELECTEDCHARACTERDATA,selectedChar);
      
      _characterSelectMenu.InitializeCharMenu();
   }

   public void PlayGame()
   {
      SceneManager.LoadScene(TagManager.GAMEPLAYSCENENAME);
   }
}
