using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{

    private int health = 15;
    private Material materialWhite;
    private Material materialDefault;
    SpriteRenderer sr;
    private UnityEngine.Object explosionRef;
    //private UnityEngine.Object enemyRef;
    //Vector3 startPos;
    // Start is called before the first frame update
    void Start()
    {
        //startPos = transform.position;
        sr = GetComponent<SpriteRenderer>();
        materialWhite = Resources.Load("WhiteFlash", typeof(Material)) as Material;
        materialDefault = sr.material;
        explosionRef = Resources.Load("Explosion");
        //enemyRef = Resources.Load("EnemyObj");
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
                Invoke("ResetM", .1f);
            }
        }    
    }
    void ResetM()
    {
        sr.material = materialDefault;
    }
    private void SelfKill()
    {
        SoundScript.PlaySound("enemyDie");
        Invoke("EnemyD", .1f);
    }
    void EnemyD()
    {
        GameObject explosion = (GameObject)Instantiate(explosionRef);
        explosion.transform.position = new Vector3(transform.position.x, transform.position.y + .3f, transform.position.z);
        Destroy(gameObject);
        //gameObject.SetActive(false);
        //Invoke("Respawn", 5);
    }

    /*void Respawn()
    {
        GameObject enemyClone = (GameObject)Instantiate(enemyRef);
        enemyClone.transform.position = new Vector3(UnityEngine.Random.Range(startPos.x - 3, startPos.x + 3), startPos.y, startPos.z);

        Destroy(gameObject);
    }*/
}
