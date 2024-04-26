using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UniversalSceneChangeController : MonoBehaviour
{
    private Button button;
    public int levelIndex;
    public float fadeDuration = 1.0f;

    private void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(LoadScene);
    }

    private IEnumerator FadeOutBackgroundAudio()
    {
        AudioSource backgroundAudio = FindObjectOfType<AudioSource>();
        if (backgroundAudio != null)
        {
            float elapsedTime = 0f;
            float startVolume = backgroundAudio.volume;

            while (elapsedTime < fadeDuration)
            {
                float fadeRatio = elapsedTime / fadeDuration;
                backgroundAudio.volume = Mathf.Lerp(startVolume, 0f, fadeRatio);
                elapsedTime += Time.deltaTime;
                yield return null;
            }
            backgroundAudio.volume = 0f;
        }
    }

    private IEnumerator LoadSceneCoroutine()
    {
        yield return StartCoroutine(FadeOutBackgroundAudio());
        SceneManager.LoadScene(levelIndex);
    }

    private void LoadScene()
    {
        StartCoroutine(LoadSceneCoroutine());
    }
}
