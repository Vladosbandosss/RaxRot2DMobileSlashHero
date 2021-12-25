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
   private void Start()
   {
      highScore.text = "0m";
      _characterSelectMenu = GetComponent<CharacterSelectMenu>();
   }

   public void OpenCloseMenu(bool open)
   {
      characterSelectMenuPanel.SetActive(open);
   }

   public void SelectCharacter()
   {
      int selectedChar = int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);
      Debug.Log(selectedChar);
   }

   public void PlayGame()
   {
      SceneManager.LoadScene(TagManager.GAMEPLAYSCENENAME);
   }
}
