using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenseWall : MonoBehaviour
{
    public int wall_hp = 1000;
    public Rigidbody rb;
    public GameObject ExplosionEffect;
    public int erase_timer = 2;    // how long before wall is removed after hp reaches 0

    private void OnCollisionEnter(Collision col) {
        if(col.gameObject.tag == "EnemyProjectile")
        {
            wall_hp--;
        }

        if(wall_hp == 0)
        {
            Explode();
        }      
    }
    
    //Calls explosion launches wall
    private void Explode()
    {
        GameObject explodeeffect = (GameObject)Instantiate
            (ExplosionEffect, transform.position, transform.rotation);
        rb.AddForce(0, 8500000f, 0);
        rb.AddTorque(0, 5000000f, 7000000f);
        Destroy(explodeeffect, erase_timer);
        Destroy(gameObject, erase_timer);
    }
}
