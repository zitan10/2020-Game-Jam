using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyOneAIShoot : MonoBehaviour {

    public Transform player;
    GameObject prefab;
    public GameObject projectile;
    public Transform barrel;

    private Rigidbody rb;
    private float timer;
    public float turrentWaitTime = 1f;

    public GameObject[] walls;

    private Vector3 target;

    private float clostestWallDistance;

    // Use this for initialization
    void Start()
    {
        prefab = Resources.Load("EnemyProjectile") as GameObject;
        timer = 0f;
        //Prevent projectile from passing through objects
        rb = projectile.GetComponent<Rigidbody>();
        rb.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;
    }

    // Update is called once per frame
    void Update()
    {
        walls = GameObject.FindGameObjectsWithTag("wall");

        target = new Vector3(0, 0, 0);

        clostestWallDistance = 10000f;
        foreach (GameObject wall in walls)
        {
            float distanceCheck = Vector3.Distance(wall.transform.position, this.transform.position);
            if (distanceCheck < clostestWallDistance)
            {
                clostestWallDistance = distanceCheck;
                target = wall.transform.position;
            }
        }

        //Is enemy position closer to player or wall position?
        Vector3 direction = (Vector3.Distance(player.position, this.transform.position) 
            < Vector3.Distance(target, this.transform.position)
            ) ? player.position - this.transform.position: target - this.transform.position;

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
        if (timer > turrentWaitTime / 10)
        {
            GameObject projectile = Instantiate(prefab) as GameObject;
            projectile.transform.position = barrel.transform.position;
            //Speed of projectile
            Rigidbody rb = projectile.GetComponent<Rigidbody>();
            rb.AddForce(barrel.transform.forward * 3000);
            timer = 0.0f;
        }
    }
}
