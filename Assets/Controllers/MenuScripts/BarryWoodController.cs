using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[RequireComponent(typeof(Button))]
public class OpacityController : MonoBehaviour
{
    public RawImage rawImage;
    public AudioClip buttonSound;
    public float opacityIncreaseSpeed = 0.1f;
    public float opacityDecreaseSpeed = 0.1f;

    private AudioSource audioSource;
    private CanvasGroup canvasGroup;
    private bool isIncreasingOpacity;

    private void Start()
    {
        Button button = GetComponent<Button>();
        button.onClick.AddListener(OnButtonClicked);

        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = buttonSound;

        canvasGroup = rawImage.GetComponent<CanvasGroup>();
    }

    private void OnButtonClicked()
    {
        if (!isIncreasingOpacity)
        {
            StartCoroutine(ButtonAction());
        }
    }

    private IEnumerator ButtonAction()
    {
        isIncreasingOpacity = true;
        audioSource.PlayOneShot(buttonSound);
        StartCoroutine(ChangeOpacity());
        yield return new WaitForSeconds(1f);
        StartCoroutine(ChangeOpacity2());
    }

    private IEnumerator ChangeOpacity()
    {
        for (float i = 0f; i <= 1.05f; i += 0.05f)
        {
            canvasGroup.alpha = i;
            yield return new WaitForSeconds(0.05f);
        }
    }
    private IEnumerator ChangeOpacity2()
    {
        for (float i = 1f; i >= -0.05f; i -= 0.05f)
        {
            canvasGroup.alpha = i;
            yield return new WaitForSeconds(0.05f);
        }
        isIncreasingOpacity = false;
    }
}
