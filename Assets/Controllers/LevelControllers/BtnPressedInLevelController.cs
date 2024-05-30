using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class BtnPressedController : MonoBehaviour
{
    public AudioClip buttonSound;

    private AudioSource audioSource;

    private void Awake()
    {
        Button button = GetComponent<Button>();
        button.onClick.AddListener(PlayButtonSound); // Робимо прив'язку до дії PlayButtonSound
    }

    private void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.playOnAwake = false;
    }

    public void PlayButtonSound()
    {
        audioSource.PlayOneShot(buttonSound); // Граємо звук
    }
}
