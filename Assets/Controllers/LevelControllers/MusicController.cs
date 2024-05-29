using JetBrains.Annotations;
using System.Collections;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    private AudioSource audioSource, secondAudioSource;
    public AudioClip firstClip;
    public AudioClip secondClip;
    public Canvas canvasVictory;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        PlayFirstClip();
    }

    void PlayFirstClip()
    {
        audioSource.clip = firstClip;
        audioSource.loop = false;
        audioSource.Play();

        double startTime = AudioSettings.dspTime + firstClip.length + 0.54;
        ScheduleSecondClip(startTime);
    }

    void ScheduleSecondClip(double startTime)
    {
        secondAudioSource = gameObject.AddComponent<AudioSource>();
        secondAudioSource.clip = secondClip;
        secondAudioSource.loop = true;
        secondAudioSource.PlayScheduled(startTime);
    }

    void Update()
    {
        if (canvasVictory.isActiveAndEnabled) secondAudioSource.volume = 0f;
    }
}
