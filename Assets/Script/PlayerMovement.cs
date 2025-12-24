using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed = 7f;
    public Rigidbody2D rb;

    [Header("Shooting Settings")]
    public GameObject bulletPrefab;
    public Transform firePoint;


    [Header("Crosshair Settings")]
    public Transform crosshair;
    public float crosshairDistance = 3f;
    public SpriteRenderer crosshairRenderer;
    public Color normalColor = new Color(1, 1, 1, 0.5f);
    public Color targetColor = new Color(1, 0, 0, 1f);
    public LayerMask enemyLayer;

    private Vector2 moveInput;
    private Vector2 mousePos;

  


    void Start()
    {
        Cursor.visible = false;
        // Если забыл перетащить Rigidbody в инспекторе, код найдет его сам
        if (rb == null) rb = GetComponent<Rigidbody2D>();
   

    }

    void Update()
    {
        // ВОТ ЭТИ СТРОКИ БЫЛИ ПРОПУЩЕНЫ:
        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");

        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // Логика прицела и стрельбы
        RaycastHit2D hit = Physics2D.Raycast(crosshair.position, Vector2.zero, 0f, enemyLayer);

        if (hit.collider != null)
        {
            crosshairRenderer.color = targetColor;
            if (Input.GetButtonDown("Fire1"))
            {
                Enemy enemy = hit.collider.GetComponent<Enemy>();
                if (enemy != null) enemy.TakeDamage();
            }
        }
        else
        {
            crosshairRenderer.color = normalColor;
            // Если хочешь стрелять пулями, когда не наведен на врага:
            if (Input.GetButtonDown("Fire1")) Shoot();
        }
    }

    void FixedUpdate()
    {
        rb.linearVelocity = moveInput.normalized * moveSpeed;

        Vector2 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;
        rb.rotation = angle;

        UpdateCrosshair(lookDir);


    }

    void UpdateCrosshair(Vector2 lookDir)
    {
        if (lookDir.magnitude > crosshairDistance)
        {
            lookDir = lookDir.normalized * crosshairDistance;
        }
        crosshair.position = rb.position + lookDir;
    }

    void Shoot()
    {
        if (bulletPrefab != null && firePoint != null)
            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
}