using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerDeath2 : MonoBehaviour
{

    public int health = 4;
    public int numOfStars = 4;
    public Image[] stars;
    public Sprite fullStars;
    public Sprite emptyStars;

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            health--;
            SoundScript.PlaySound("playerDie");

            for (int i = 0; i < stars.Length; i++)
            {
                if (i < health)
                {
                    stars[i].sprite = fullStars;
                }
                else
                {
                    stars[i].sprite = emptyStars;
                }

                if (i < numOfStars)
                {
                    stars[i].enabled = true;
                }
                else
                {
                    stars[i].enabled = false;
                }
            }
            if (health <= 0)
            {
                Invoke("SceneM", 1);
            }
        }

        if (collision.gameObject.CompareTag("LevelDone"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 3);
        }
    }

    void SceneM()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
