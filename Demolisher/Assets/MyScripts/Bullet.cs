using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject hitEffect;

    void start()
    {
        Invoke("SelfDestroy", 5f);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
        Destroy(effect, 2f);
        SelfDestroy();
    }
    private void SelfDestroy()
    {
        Destroy(gameObject);
    }
}
