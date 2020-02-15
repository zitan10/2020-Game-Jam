using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurrentAI : MonoBehaviour {


    public Transform player;
    GameObject prefab;
    public GameObject projectile;
    public Transform barrel;

    private Rigidbody rb;
    private float timer;
    public float turrentWaitTime = 1f;

    // Use this for initialization
    void Start () {
        prefab = Resources.Load("Projectile") as GameObject;
        timer = 0f;
        //Prevent projectile from passing through objects
        rb = projectile.GetComponent<Rigidbody>();
        rb.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;
    }

    // Update is called once per frame
    void Update()
    {

        //Is enemy position close to player position?

        //Direction from player to enemy
        Vector3 direction = player.position - this.transform.position;
        //Prevent enemy from rotation upwards
        //direction.y = 0;

        if (Vector3.Distance(player.position, this.transform.position) < 40)
        {
            //Rotata Turrent Barrel
            this.transform.rotation = Quaternion.Slerp(
                this.transform.rotation, Quaternion.LookRotation(direction), 100f * Time.deltaTime);

            FireProjectile();
        }

    }

    private void FireProjectile()
    {
        timer += 1 * Time.deltaTime;
        if (timer > turrentWaitTime/10) {
            GameObject projectile = Instantiate(prefab) as GameObject;
            projectile.transform.position = barrel.transform.position;
            //Speed of projectile
            Rigidbody rb = projectile.GetComponent<Rigidbody>();
            rb.AddForce(barrel.transform.forward * 3000);
            timer = 0.0f;
        }
    }
}
