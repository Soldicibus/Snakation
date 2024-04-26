using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FirstSceneController : MonoBehaviour
{
    public Canvas settings;
    public Canvas lvlselect;

    private void Start()
    {
        settings.gameObject.SetActive(false);
        lvlselect.gameObject.SetActive(false);
    }
}
