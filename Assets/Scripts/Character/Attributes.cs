using System;
using UnityEngine;
using UnityEngine.UI;

public class Attributes : MonoBehaviour
{
    private Character character;
    [SerializeField] private Slider currentHealthSlider;
    [SerializeField]
    private Slider currentStaminaSlider;

    [Header("UI Settings")]
    [SerializeField] private float widthPerPoint = 2f;

    private void Awake()
    {
        character = GetComponent<Character>();
    }

    void Start()
    {
        UpdateBarsSize();
    }

    public void UpdateBarsSize()
    {
        currentHealthSlider.maxValue = character.MaxHealth;
        currentStaminaSlider.maxValue = character.MaxStamina;

        RectTransform healthRect = currentHealthSlider.GetComponent<RectTransform>();
        healthRect.sizeDelta = new Vector2(character.MaxHealth * widthPerPoint, healthRect.sizeDelta.y);

        RectTransform staminaRect = currentStaminaSlider.GetComponent<RectTransform>();
        staminaRect.sizeDelta = new Vector2(character.MaxStamina * widthPerPoint, staminaRect.sizeDelta.y);

        currentHealthSlider.value = character.CurrentHealth;
        currentStaminaSlider.value = character.CurrentStamina;
    }

    public void TakeDamage(float amount)
    {
        character.CurrentHealth -= amount;
        currentHealthSlider.value = character.CurrentHealth;

        if (character.CurrentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void ConsumeStamina(float amount)
    {
        character.CurrentStamina -= amount;
        currentStaminaSlider.value = character.CurrentStamina;
    }
}
