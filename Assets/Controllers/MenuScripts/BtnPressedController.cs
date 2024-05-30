using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class BtnPressedInLevelController : MonoBehaviour
{
    public AudioClip buttonSound;

    private AudioSource audioSource;

    private void Awake()
    {
        Button[] buttons = GetComponentsInChildren<Button>();
        foreach (Button button in buttons)
        {
            button.onClick.AddListener(PlayButtonSound);
        }
    }

    private void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.playOnAwake = false;
    }

    public void PlayButtonSound()
    {
        audioSource.PlayOneShot(buttonSound);
    }
}
