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

    private GameObject[] enemies;

    private float clostestEnemyDistance;


    private Vector3 target;

    // Use this for initialization
    void Start () {
        prefab = Resources.Load("Projectile") as GameObject;
        timer = 0f;
        //Prevent projectile from passing through objects
        rb = projectile.GetComponent<Rigidbody>();
        rb.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;
        target = new Vector3(0,0,0);

        clostestEnemyDistance = 10000f;

        if (enemies == null)
        {
            enemies = GameObject.FindGameObjectsWithTag("enemyTag");
        }

    }

    // Update is called once per frame
    void Update()
    {
        enemies = GameObject.FindGameObjectsWithTag("enemyTag");
        target = new Vector3(0, 0, 0);

        
        foreach (GameObject enemy in enemies)
        {
            float distanceCheck = Vector3.Distance(enemy.transform.position, this.transform.position);
            clostestEnemyDistance = 10000000f;
            if (distanceCheck < clostestEnemyDistance)
            {
                clostestEnemyDistance = distanceCheck;
                target = enemy.transform.position;
            }
        }

        //Is enemy position close to player position?

        //Direction from player to enemy
        Vector3 direction = target - this.transform.position;
        //Prevent enemy from rotation upwards
        //direction.y = 0;

        if (Vector3.Distance(target, this.transform.position) < 4000)
        {
            //Rotata Turrent Barrel
            this.transform.rotation = Quaternion.Slerp(
                this.transform.rotation, Quaternion.LookRotation(direction), 2000f * Time.deltaTime);

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
