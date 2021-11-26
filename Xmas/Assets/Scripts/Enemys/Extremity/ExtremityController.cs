using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtremityController : MonoBehaviour
{
    // Start is called before the first frame update
    EnemyController enemyController;
    void Start()
    {
        enemyController = GetComponentInParent<EnemyController>();
    }
    public void ExtremityTakeDamage(float damage)
    {
        enemyController.TakeDamage(damage);
    }
}
