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

        // Play the first clip immediately
        PlayFirstClip();
    }

    void PlayFirstClip()
    {
        audioSource.clip = firstClip;
        audioSource.loop = false;
        audioSource.Play();

        // Schedule the second clip to start after the first clip ends
        double startTime = AudioSettings.dspTime + firstClip.length + 0.55;
        ScheduleSecondClip(startTime);
    }

    void ScheduleSecondClip(double startTime)
    {
        // Create a new AudioSource to handle the scheduling of the second clip
        AudioSource secondAudioSource = gameObject.AddComponent<AudioSource>();
        secondAudioSource.clip = secondClip;
        secondAudioSource.loop = true;
        secondAudioSource.PlayScheduled(startTime);
    }

    void Update()
    {
        // No update logic needed for this task
    }
}
