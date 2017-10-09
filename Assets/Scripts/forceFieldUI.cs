using UnityEngine;
using System.Collections;

public class forceFieldUI : MonoBehaviour {

    [SerializeField]
    RectTransform barRectTransform;

    float maxWidth;

    void Awake()
    {
        maxWidth = barRectTransform.rect.width;
    }

    void OnEnable()
    {
        eventManager.onTakeDamage += UpdateShieldDisplay;
        eventManager.onRegenDamage += UpdateShieldDisplay;
    }
    void OnDisable()
    {
        eventManager.onTakeDamage -= UpdateShieldDisplay;
        eventManager.onRegenDamage -= UpdateShieldDisplay;
    }

    void UpdateShieldDisplay(float percentage)
    {
        barRectTransform.sizeDelta = new Vector2(maxWidth * percentage, 10f);
    }
}
