using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
 
public class playerHP : MonoBehaviour
{
    public int hpMax;
    public int hp;
    public Transform checkpoint;
    public PlayerMovementPlatformer dash;

    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Animator animator;

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
                transform.position = checkpoint.position;
                hp = hpMax;
            }
        }
    }
}
