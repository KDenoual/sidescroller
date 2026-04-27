using UnityEngine;

public class playerHP : MonoBehaviour
{
    public int hpMax;
    public int hp;
    public PlayerMovementPlatformer dash;

    void Start()
    {
        hp = hpMax;
    }
    public void TakeDamage(int damage)
    {
        if (dash.isDashing != true)
        {
            hp -= damage;

            if (hp <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
