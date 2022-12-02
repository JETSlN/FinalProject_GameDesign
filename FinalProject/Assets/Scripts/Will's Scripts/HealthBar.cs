using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Image healthbar;

    public void UpdateHealthBar(float maxHealth, float currentHealth)
    {
        healthbar.fillAmount = currentHealth / maxHealth;
        if (currentHealth/maxHealth > 0.5f) {
            healthbar.color = Color.green;
        } else if (currentHealth/maxHealth > 0.25f) {
            healthbar.color = new Color(1f, 1f, 0f);
        } else {
            healthbar.color = Color.red;
        }
    }
}
