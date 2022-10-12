using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundScript : MonoBehaviour
{
    public static AudioClip shootingSound, enemyD, playerD, wallExp;
    static AudioSource audioSrc;
    // Start is called before the first frame update
    void Start()
    {
        shootingSound = Resources.Load<AudioClip>("lmg_fire01");
        enemyD = Resources.Load<AudioClip>("die");
        playerD = Resources.Load<AudioClip>("die1");
        wallExp = Resources.Load<AudioClip>("synthetic_explosion_1");
        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "shoot":
                audioSrc.PlayOneShot(shootingSound); 
                break;
            case "enemyDie":
                audioSrc.PlayOneShot(enemyD);
                break;
            case "playerDie":
                audioSrc.PlayOneShot(playerD);
                break;
            case "wallExplosion":
                audioSrc.PlayOneShot(wallExp);
                break;
        }
    }
}
