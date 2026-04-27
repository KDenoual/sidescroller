using UnityEngine;

public class spike : MonoBehaviour
{
    public GameObject player;
    public int damage;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.GetComponent<playerHP>())
        {
            collision.collider.GetComponent<playerHP>().TakeDamage(damage);
        }

    }
}
