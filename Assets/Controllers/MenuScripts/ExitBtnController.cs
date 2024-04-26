using UnityEngine;
using UnityEngine.UI;

public class ExitButtonController : MonoBehaviour
{
    private void Start()
    {
        Button button = GetComponent<Button>();
        button.onClick.AddListener(ExitGame);
    }

    private void ExitGame()
    {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
