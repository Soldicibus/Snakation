using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ResolutionController : MonoBehaviour
{
    public CanvasScaler canvasScaler;

    private Vector2 initialResolution;
    private bool lowres;

    private void Start()
    {
        lowres = false;
        initialResolution = new Vector2(2640f, 1200f);
        UpdateFontSizes();
        SetResolutionToMatchDevice();
        UpdateRawImageResolution();
        UpdateButtonPositionsAndSizes();
    }

    private void SetResolutionToMatchDevice()
    {
        Resolution deviceResolution = Screen.currentResolution;
        Screen.SetResolution(deviceResolution.width, deviceResolution.height, Screen.fullScreen);
        canvasScaler.referenceResolution = new Vector2(deviceResolution.width, deviceResolution.height);
    }

    private void UpdateRawImageResolution()
    {
        Resolution deviceResolution = Screen.currentResolution;
        Vector2 resolution = new Vector2(deviceResolution.width, deviceResolution.height);
        RawImage[] rawImages = GetComponentsInChildren<RawImage>();
        foreach (RawImage rawImage in rawImages)
        {
            if (rawImage != null)
            {
                RectTransform rectTransform = rawImage.GetComponent<RectTransform>();
                rectTransform.sizeDelta = resolution;
            }
        }
    }
    private void UpdateFontSizes()
    {
        float scaleFactorX = (float)Screen.width / initialResolution.x;
        float scaleFactorY = (float)Screen.height / initialResolution.y;

        float averageScaleFactor = (scaleFactorX + scaleFactorY) / 2f;
        TMP_Text[] tmpTexts = GetComponentsInChildren<TMP_Text>();
        foreach (TMP_Text tmpText in tmpTexts)
        {
            if (tmpText != null)
            {
                float initialFontSize = tmpText.fontSize;
                // Calculate the new font size based on the average scale factor
                float newFontSize = initialFontSize * averageScaleFactor;
                tmpText.fontSize = newFontSize;
                RectTransform rectTransform = tmpText.GetComponent<RectTransform>();
                Vector2 position = rectTransform.anchoredPosition;
                Vector2 sizeDelta = rectTransform.sizeDelta;

                position.x *= scaleFactorX;
                position.y *= scaleFactorY;
                sizeDelta.x *= scaleFactorX;
                sizeDelta.y *= scaleFactorY;

                rectTransform.anchoredPosition = position;
                rectTransform.sizeDelta = sizeDelta;
            }
        }
    }
    private void UpdateButtonPositionsAndSizes()
    {
        Resolution deviceResolution = Screen.currentResolution;
        if (deviceResolution.width < 1500 || deviceResolution.height < 820)
        {
            lowres = true;
        }
        float scaleFactorXbb = (float)deviceResolution.width / initialResolution.x;
        float scaleFactorYbb = (float)deviceResolution.height / initialResolution.y;
        float scaleFactorX = (float)deviceResolution.width / initialResolution.x;
        float scaleFactorY = (float)deviceResolution.height / initialResolution.y;
        float sizeMultiplier;
        sizeMultiplier = 1.01f;
        if (lowres == true) sizeMultiplier = 1.55f;

        scaleFactorXbb *= sizeMultiplier;
        scaleFactorYbb *= sizeMultiplier;

        Image[] images = GetComponentsInChildren<Image>();
        Button[] buttons = GetComponentsInChildren<Button>();
        Slider[] sliders = GetComponentsInChildren<Slider>();
        foreach (Button button in buttons)
        {
            if (button != null)
            {
                RectTransform rectTransform = button.GetComponent<RectTransform>();
                Vector2 position = rectTransform.anchoredPosition;
                Vector2 sizeDelta = rectTransform.sizeDelta;

                position.x *= scaleFactorXbb;
                position.y *= scaleFactorYbb;
                sizeDelta.x *= scaleFactorXbb;
                sizeDelta.y *= scaleFactorYbb;

                rectTransform.anchoredPosition = position;
                rectTransform.sizeDelta = sizeDelta;
            }
        }
        sizeMultiplier = 1.02f;
        scaleFactorX *= sizeMultiplier;
        scaleFactorY *= sizeMultiplier;
        foreach (Slider slider in sliders)
        {
            if (slider != null)
            {
                RectTransform rectTransform = slider.GetComponent<RectTransform>();
                Vector2 position = rectTransform.anchoredPosition;
                Vector2 sizeDelta = rectTransform.sizeDelta;

                position.x *= scaleFactorX;
                position.y *= scaleFactorY;
                sizeDelta.x *= scaleFactorX;
                sizeDelta.y *= scaleFactorY;

                rectTransform.anchoredPosition = position;
                rectTransform.sizeDelta = sizeDelta;
            }
        }
        foreach (Image image in images)
        {
            if (image != null)
            {
                RectTransform rectTransform = image.GetComponent<RectTransform>();
                Vector2 position = rectTransform.anchoredPosition;
                Vector2 sizeDelta = rectTransform.sizeDelta;

                position.x *= scaleFactorX;
                position.y *= scaleFactorY;
                sizeDelta.x *= scaleFactorX;
                sizeDelta.y *= scaleFactorY;

                rectTransform.anchoredPosition = position;
                rectTransform.sizeDelta = sizeDelta;
            }
        }
        initialResolution = new Vector2(Screen.width, Screen.height);
    }
}

