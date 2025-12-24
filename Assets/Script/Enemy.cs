using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{
    public int health = 1;
    public float speed = 3f;
    public float damage = 10f;

    private Transform player;
    private Rigidbody2D rb; 
    private bool isDead = false;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
       
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj != null) player = playerObj.transform;

        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void FixedUpdate()
    {
        if (isDead || player == null)
        {
            rb.linearVelocity = Vector2.zero; 
            return;
        }

        
        Vector2 direction = (player.position - transform.position).normalized;

        
        rb.linearVelocity = direction * speed;
    }

    public void TakeDamage()
    {
        health--;
        if (health <= 0 && !isDead)
        {
            StartCoroutine(Die());
        }
    }

    IEnumerator Die()
    {
        isDead = true;
        GetComponent<Collider2D>().enabled = false;
        rb.linearVelocity = Vector2.zero; 

        float alpha = 1f;
        while (alpha > 0)
        {
            alpha -= Time.deltaTime;
            Color c = spriteRenderer.color;
            c.a = alpha;
            spriteRenderer.color = c;
            yield return null;
        }
        Destroy(gameObject);
    }
}