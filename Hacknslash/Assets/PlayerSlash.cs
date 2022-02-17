using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSlash : MonoBehaviour
{

    [SerializeField] protected LayerMask enemyLayer;

    [SerializeField] protected Transform attackPoint;
    [SerializeField] protected float attackRange;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Attack();
        }
    }

    void Attack ()
    {

        Collider2D[] enemiesHit = Physics2D.OverlapCircleAll (attackPoint.position, attackRange, enemyLayer);

        foreach (Collider2D enemy in enemiesHit)
        {
            Debug.Log("HIT " + enemy.name);
        }

    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }


}
