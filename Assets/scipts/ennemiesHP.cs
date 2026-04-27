 using UnityEngine;

public class ennemiesHP : MonoBehaviour
{
    public int hpMax;
    public int hp;
    public int giveXP;

    public attaque playerAttaque;

    void Start()
    {
       hp = hpMax;
    }
    public void TakeDamage(int damage)
    {
        hp -= damage;

        if (hp <= 0)
        {
            Destroy(gameObject);
            playerAttaque.attackDamage += giveXP;
        }
    }
}
