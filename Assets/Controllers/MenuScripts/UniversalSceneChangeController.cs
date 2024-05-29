using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class UniversalSceneChangeController : MonoBehaviour
{
    private Button button;
    public AudioSource audioSource;
    public int levelNumber;
    public float fadeDuration = 1.0f;

    private void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(LoadScene);
    }

    private static string NumberToWords(int number)
    {
        if (number == 1) return "One";
        if (number == 2) return "Two";
        if (number == 3) return "Three";
        if (number == 4) return "Four";
        if (number == 5) return "Five";
        if (number == 6) return "Six";
        if (number == 7) return "Seven";
        if (number == 8) return "Eight";
        if (number == 9) return "Nine";
        if (number == 10) return "Ten";
        if (number == 11) return "Eleven";
        if (number == 12) return "Twelve";
        if (number == 13) return "Thirteen";
        if (number == 14) return "Fourteen";
        if (number == 15) return "Fifteen";
        else return null;
    }

    public static string GetLevelName(int levelNumber)
    {
        string levelWord = NumberToWords(levelNumber);
        return "Level" + levelWord;
    }

    private IEnumerator FadeOutBackgroundAudio()
    {
        if (audioSource != null)
        {
            float elapsedTime = 0f;
            float startVolume = audioSource.volume;

            while (elapsedTime < fadeDuration)
            {
                float fadeRatio = elapsedTime / fadeDuration;
                audioSource.volume = Mathf.Lerp(startVolume, 0f, fadeRatio);
                elapsedTime += Time.deltaTime;
                yield return null;
            }
            audioSource.volume = 0f;
        }
    }

    private IEnumerator LoadSceneCoroutine()
    {
        yield return StartCoroutine(FadeOutBackgroundAudio());
        SceneManager.LoadScene(GetLevelName(levelNumber));
    }

    private void LoadScene()
    {
        StartCoroutine(LoadSceneCoroutine());
    }
}
