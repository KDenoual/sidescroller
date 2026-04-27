using UnityEngine;

public class enemyDegat : MonoBehaviour
{
    public int damage;
    public Transform attackOrigin;
    public float attackRadius = 1f;
    public LayerMask enemyMasck;

    public float cooldawnTime = .5f;
    private float cooldawnTimer = 0;

    void Update()
    {
        if (cooldawnTimer <= 0)
        {
            Collider2D[] enemiesInRange = Physics2D.OverlapCircleAll(attackOrigin.position, attackRadius, enemyMasck);
            foreach (var enemy in enemiesInRange)
            {
                enemy.GetComponent<playerHP>().TakeDamage(damage);
            }
            cooldawnTimer = cooldawnTime;
        }
        else
        {
            cooldawnTimer -= Time.deltaTime;
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(attackOrigin.position, attackRadius);
    }
}
