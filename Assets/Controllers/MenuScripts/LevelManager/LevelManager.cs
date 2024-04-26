using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    int unlockedLVLs;

    public Button[] buttons;
    void Start()
    {
        unlockedLVLs = PlayerPrefs.GetInt("unlockedLVLs", 1);
        

        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].interactable = false;
        }
         
        for (int i = 0; i < unlockedLVLs; i++)
        {
            buttons[i].interactable = true;
        }


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
