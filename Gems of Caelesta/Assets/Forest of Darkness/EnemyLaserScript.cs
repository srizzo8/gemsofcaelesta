using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLaserScript : MonoBehaviour
{
    public NewAttackingScriptForEnemies newAttacking;

    IEnumerator StillEnemy()
    {
        newAttacking.c = 0;
        yield return new WaitForSeconds(2f);
        yield break;
    }
    void OnCollisionEnter2D(Collision2D c)
    {
        if(c.gameObject.CompareTag("DrAurora"))
        {
            StartCoroutine(StillEnemy());
        }
    }
}
