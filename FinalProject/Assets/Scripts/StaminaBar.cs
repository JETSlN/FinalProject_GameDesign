using UnityEngine;
using UnityEngine.UI;

public class StaminaBar : MonoBehaviour
{
    public Image staminabar;

    public void UpdateStaminaBar(float maxStamina, float currentStamina)
    {
        staminabar.fillAmount = currentStamina / maxStamina;
        //Sets the stamina bar to the current stamina percentage
    }
}
