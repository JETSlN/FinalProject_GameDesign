using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public static PlayerHealth Instance;
    [SerializeField]
    float maxHealth = 5f;
    [SerializeField]
    float currentHealth;
    public HealthBar bar;
    public AudioSource audioSource;
    public AudioClip hurt;
    void Awake()
    {
        Instance = this;
    }
    
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
        GetComponent<AudioSource>().PlayOneShot(hurt);

        // test because I accidentally stacked some spikes
    }

    void FixedUpdate()
    {
        //Constantly updates health bar
        bar.UpdateHealthBar(maxHealth, currentHealth);
        if (currentHealth == 0f)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public void Heal(float amount)
    {
        currentHealth = Mathf.Clamp(currentHealth+amount, 0, 6);
    }
}
