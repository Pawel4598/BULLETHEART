using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    private HealthManager healthManager;
    public float maxHealth = 100f;
    public float currentHealth;
    public HealthBar healthBar;
    private SpriteRenderer spriteRenderer;
    public Color flashColor = Color.red;
    public float flashDuration = 0.1f;


    // Start is called before the first frame update
    void Start()
    {
        healthManager = HealthManager.Instance;
        spriteRenderer = GetComponent<SpriteRenderer>();

        if(healthBar != null )
        {
            healthBar.SetMaxHealth(healthManager.maxHealth);
            healthBar.SetHealth(healthManager.currentHealth);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(float damageAmount)
    {
        healthManager.TakeDamage(damageAmount);
        StartCoroutine(FlashRed());

        if (healthBar != null)
            healthBar.SetHealth(healthManager.currentHealth);

        if (healthManager.currentHealth <= 0)
            Die();
    }

    IEnumerator FlashRed()
    {
        Color originalColor = spriteRenderer.color;
        spriteRenderer.color = flashColor;
        yield return new WaitForSeconds(flashDuration);
        spriteRenderer.color = originalColor;
    }

    void Die()
    {
        SceneManager.LoadScene("DeathScreen", LoadSceneMode.Single); 
    }

    public void TakeHeal(float healAmount)
    {
        healthManager.Heal(healAmount);

        if(healthBar != null )
            healthBar.SetHealth(healthManager.currentHealth);
    }
}

