using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class EnemyExplosion : MonoBehaviour {

    private AudioSource audioData;

    public int enemy_hp = 5;
    public GameObject ExplosionEffect;
    public int erase_timer = 2;    // how long before wall is removed after hp reaches 0	
                                   // Update is called once per frame

    private void Start()
    {
        audioData = gameObject.GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Projectile")
        {
            enemy_hp--;
        }

        if (enemy_hp == 0)
        {
            audioData.Play();
            Explode();
        }
    }
    //Calls explosion launches wall
    private void Explode()
    {
        GameObject explodeeffect = (GameObject)Instantiate
            (ExplosionEffect, transform.position, transform.rotation);
        Destroy(explodeeffect, erase_timer);
        Destroy(gameObject);
    }
}
