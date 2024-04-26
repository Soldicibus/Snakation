using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuTransitionController : MonoBehaviour
{
    public RawImage transitionImage; // ��������� ���������� ��������
    private Canvas theCanvas;
    public Canvas activeCanvas;
    private bool isUsed;

    private void Start()
    {
        if (!isUsed)
        {
            isUsed = true;
            StartCoroutine(Transit()); // ��������� ������� �������� ��� ����� ���
        }
    }

    private IEnumerator Transit()
    {
        theCanvas = GetComponent<Canvas>();
        CanvasGroup canvasGroup = transitionImage.GetComponent<CanvasGroup>(); // ������ ��'��� CanvasGroup � RawImage
        CanvasGroup canvasGroup2 = theCanvas.GetComponent<CanvasGroup>(); // ������ ��'��� CanvasGroup � Canvas
        CanvasGroup canvasGroup3 = activeCanvas.GetComponent<CanvasGroup>(); // ������ ��'��� CanvasGroup � Canvas2

        canvasGroup2.alpha = 1;
        for (float i = 1f; i >= -0.15f; i -= 0.15f) // ������ ��������� ��������� opacity ��'���� CanvasGroup RawImage Canvas2
        {
            canvasGroup.alpha = i;
            canvasGroup3.alpha = i;
            yield return new WaitForSeconds(0.05f);
        }
        transitionImage.gameObject.SetActive(false); // ���������� ��'��� RawImage
        isUsed = false;
    }
}
