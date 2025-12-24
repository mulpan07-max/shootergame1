using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 15f;
    public float lifeTime = 3f; // Чтобы пули не летели вечно, забивая память

    void Start()
    {
        // Сразу после появления летим вперед (вправо относительно своего поворота)
        GetComponent<Rigidbody2D>().linearVelocity = transform.right * speed;
        // Удаляем пулю через 3 секунды
        Destroy(gameObject, lifeTime);
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        // Если попали в стену или врага (кроме игрока)
        if (!hitInfo.CompareTag("Player"))
        {
            // Здесь позже добавим урон врагу
            Destroy(gameObject);
        }
    }
}
