using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcidEffect : MonoBehaviour
{

    private void Start()
    {
        StartCoroutine(DestroyCountdown());
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        IDamageable hit = other.GetComponent<IDamageable>();

        if(hit != null && other.tag == "Player")
        {
            hit.Damage();
            Destroy(gameObject);
        }
    }

    IEnumerator DestroyCountdown()
    {
        yield return new WaitForSeconds(5);
        Destroy(gameObject);
    }
}
