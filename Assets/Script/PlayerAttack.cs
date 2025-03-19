using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public float attackDamage;
    private int enemyLayer;
    private int destructibleLayer;
    void Start()
    {
        enemyLayer = LayerMask.NameToLayer("Enemy");
        destructibleLayer = LayerMask.NameToLayer("Destruction");
    }

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == enemyLayer)
        {
            collision.GetComponent<Enemy>().TakeDamage(attackDamage);
        }

        if (collision.gameObject.layer == destructibleLayer)
        {
            collision.GetComponent<Destructible>().HitDestructible();
        }
    }
}
