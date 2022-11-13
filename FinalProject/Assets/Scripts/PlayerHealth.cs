using UnityEngine;
//using UnityEngine.UI;
//using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField]
    float maxHealth = 5f;
    [SerializeField]
    float currentHealth;
    public Transform player;
    public HealthBar bar;

    void Start()
    {
        // Player starts at full health
        currentHealth = maxHealth;
    }

    public void takeDamage()
    {
        // Public void so the Damage script can access this (since the spike has
        // the on trigger enter function)
        currentHealth -= 1;
        Debug.Log("damage");
        // test because I accidentally stacked some spikes
    }

    void FixedUpdate()
    {
        //Constantly updates health bar
        bar.UpdateHealthBar(maxHealth, currentHealth);
        if (currentHealth == 0f || player.position.y < -10)
        {
            Debug.Log("Skill Issue tbh");
            currentHealth = maxHealth;
        }
    }

    public void Heal(float amount)
    {
        currentHealth = Mathf.Clamp(currentHealth+amount, 0, 6);
    }
}
