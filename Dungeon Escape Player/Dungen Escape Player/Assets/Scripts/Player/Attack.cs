using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    private bool canDamage = true;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("HIT: " + other.name);

        IDamageable hit = other.GetComponent<IDamageable>();

        if(hit != null && canDamage)
        {
            hit.Damage();
            canDamage = false;
            StartCoroutine(AttackCooldown());
        }
    }

    IEnumerator AttackCooldown()
    {
        yield return new WaitForSeconds(1f);
        canDamage = true;
    }
}
