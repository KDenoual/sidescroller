using UnityEngine;

public class attaque : MonoBehaviour
{
    public Transform attackOrigin;
    public float attackRadius = 1f;
    public LayerMask enemyMasck;

    public int attackDamage;

    public float cooldawnTime = .5f;
    private float cooldawnTimer = 0;

    private void Update()
    {
        if (cooldawnTimer <= 0)
        {
            if (Input.GetKey(KeyCode.Mouse0))
            {

                Collider2D[] enemiesInRange = Physics2D.OverlapCircleAll(attackOrigin.position, attackRadius, enemyMasck);
                foreach (var enemy in enemiesInRange)
                {
                    enemy.GetComponent<ennemiesHP>().TakeDamage(attackDamage);
                }
                cooldawnTimer = cooldawnTime;
            }
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
