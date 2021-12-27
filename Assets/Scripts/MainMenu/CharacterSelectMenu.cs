using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSelectMenu : MonoBehaviour
{
    [SerializeField] private Button [] charSelectButtons;

    [SerializeField] private GameObject[] selectedCharCheckBox;

    public void InitializeCharMenu()
    {
        for (int i = 0; i < charSelectButtons.Length; i++)
        {
            int charData = DataManger.GetDate(TagManager.CHARACTERDATA + i.ToString());

            if (charData == 0)
            {
                charSelectButtons[i].interactable = false;
            }
            
            selectedCharCheckBox[i].SetActive(false);
        }
        selectedCharCheckBox[DataManger.GetDate(TagManager.SELECTEDCHARACTERDATA)].SetActive(true);
    }
}
