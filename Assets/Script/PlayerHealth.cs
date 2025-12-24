using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Collections; 

public class PlayerHealth : MonoBehaviour
{
    [Header("HP Settings")]
    public int maxHealth = 10;
    public int currentHealth;

    [Header("UI Reference")]
    public Image heartImage;
    public List<Sprite> heartSprites; 

    [Header("Damage Settings")]
    public float damageCooldown = 0.5f; 
    private float lastDamageTime;
    private SpriteRenderer spriteRenderer;

    [Header("Game Over")]
    public GameOverUI gameOverUI;

    void Start()
    {
        currentHealth = maxHealth;
        spriteRenderer = GetComponent<SpriteRenderer>();
        UpdateHeartUI();
    }

    public void TakeDamage(int amount)
    {
        // уроитд
        if (Time.time < lastDamageTime + damageCooldown) return;

        currentHealth -= amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        lastDamageTime = Time.time; 
        UpdateHeartUI();

        StartCoroutine(DamageVisualEffect());

        if (currentHealth <= 0)
        {
            gameOverUI.ShowGameOver();
        }
    }

    void UpdateHeartUI()
    {
        if (heartImage == null || heartSprites.Count == 0) return;

        // сердце
        int spriteIndex = maxHealth - currentHealth;

     
        spriteIndex = Mathf.Clamp(spriteIndex, 0, heartSprites.Count - 1);

        heartImage.sprite = heartSprites[spriteIndex];
    }

    
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            TakeDamage(1);
        }
    }

   
    IEnumerator DamageVisualEffect()
    {
        if (spriteRenderer != null)
        {
            spriteRenderer.color = Color.red;
            yield return new WaitForSeconds(0.1f);
            spriteRenderer.color = Color.white;
        }
    }
}