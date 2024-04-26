using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetBtnController : MonoBehaviour
{
    public Canvas theCanvas;
    public Canvas activeCanvas;
    public Button button;
    public RawImage transitionImage;

    private void Start()
    {
        button.onClick.AddListener(TransitS);
    }

    private void TransitS()
    {
        StartCoroutine(TransitionCoroutine());
    }

    private IEnumerator TransitionCoroutine()
    {
        CanvasGroup canvasGroup2 = theCanvas.GetComponent<CanvasGroup>();
        CanvasGroup canvasGroup3 = activeCanvas.GetComponent<CanvasGroup>();
        CanvasGroup canvasGroup1 = transitionImage.GetComponent<CanvasGroup>();

        for (float i = 1f; i >= -0.15f; i -= 0.15f)
        {
            canvasGroup3.alpha = i;
            yield return new WaitForSeconds(0.05f);
        }
        for (float i = 0f; i <= 1.15f; i += 0.15f)
        {
            canvasGroup2.alpha = i;
            yield return new WaitForSeconds(0.05f);
        }
        transitionImage.gameObject.SetActive(true);
        canvasGroup1.alpha = 1;
        theCanvas.gameObject.SetActive(true);
        for (float i = 1f; i >= -0.15f; i -= 0.15f)
        {
            canvasGroup1.alpha = i;
            yield return new WaitForSeconds(0.05f);
        }
        transitionImage.gameObject.SetActive(false);
        activeCanvas.gameObject.SetActive(false);
    }
}
