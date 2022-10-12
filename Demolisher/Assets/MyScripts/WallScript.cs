using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallScript : MonoBehaviour
{
    private int health = 9;
    private Material materialWhite;
    private Material materialDefault;
    SpriteRenderer sr;
    //private UnityEngine.Object explosionRef;

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        materialWhite = Resources.Load("WhiteFlash", typeof(Material)) as Material;
        materialDefault = sr.material;
        //explosionRef = Resources.Load("Explosion");
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("bullet"))
        {
            Destroy(collider.gameObject);
            health--;
            sr.material = materialWhite;
            if (health <= 0)
            {
                SelfKill();
            }
            else
            {
                sr.material = materialDefault;
            }
        }
    }

    private void SelfKill()
    {
        SoundScript.PlaySound("wallExplosion");
        Invoke("wallExplo", .1f);
    }
    void wallExplo()
    {
        Destroy(gameObject);
    }
}
