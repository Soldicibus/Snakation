using System.Collections;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip firstClip;
    public AudioClip secondClip;

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

        double startTime = AudioSettings.dspTime + firstClip.length + 0.55;
        ScheduleSecondClip(startTime);
    }

    void ScheduleSecondClip(double startTime)
    {
        AudioSource secondAudioSource = gameObject.AddComponent<AudioSource>();
        secondAudioSource.clip = secondClip;
        secondAudioSource.loop = true;
        secondAudioSource.PlayScheduled(startTime);
    }

    void Update()
    {
    }
}
