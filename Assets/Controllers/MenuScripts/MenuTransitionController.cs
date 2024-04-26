using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuTransitionController : MonoBehaviour
{
    public RawImage transitionImage; // Назначаємо зображення переходу
    private Canvas theCanvas;
    public Canvas activeCanvas;
    private bool isUsed;

    private void Start()
    {
        if (!isUsed)
        {
            isUsed = true;
            StartCoroutine(Transit()); // Запускаємо функцію переходу при старті гри
        }
    }

    private IEnumerator Transit()
    {
        theCanvas = GetComponent<Canvas>();
        CanvasGroup canvasGroup = transitionImage.GetComponent<CanvasGroup>(); // Беремо об'єкт CanvasGroup з RawImage
        CanvasGroup canvasGroup2 = theCanvas.GetComponent<CanvasGroup>(); // Беремо об'єкт CanvasGroup з Canvas
        CanvasGroup canvasGroup3 = activeCanvas.GetComponent<CanvasGroup>(); // Беремо об'єкт CanvasGroup з Canvas2

        canvasGroup2.alpha = 1;
        for (float i = 1f; i >= -0.15f; i -= 0.15f) // Робимо поступове зменшення opacity об'єкту CanvasGroup RawImage Canvas2
        {
            canvasGroup.alpha = i;
            canvasGroup3.alpha = i;
            yield return new WaitForSeconds(0.05f);
        }
        transitionImage.gameObject.SetActive(false); // Деактивуємо об'єкт RawImage
        isUsed = false;
    }
}
