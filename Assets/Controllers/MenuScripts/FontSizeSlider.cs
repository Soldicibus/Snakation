using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FontSizeSlider : MonoBehaviour
{
    public Slider slider;
    public float minFontSize = 36f;
    public float maxFontSize = 60f;
    private bool hasInteracted = false;

    private void Start()
    {
        slider.onValueChanged.AddListener(OnSliderValueChanged);
    }

    private void OnSliderValueChanged(float value)
    {
        hasInteracted = true;
    }

    private void Update()
    {
        if (hasInteracted)
        {
            float fontSize = Mathf.Lerp(minFontSize, maxFontSize, slider.value);
            TMP_Text[] texts = Resources.FindObjectsOfTypeAll<TMP_Text>();
            foreach (TMP_Text text in texts)
            {
                text.fontSize = fontSize;
            }
        }
    }
}
