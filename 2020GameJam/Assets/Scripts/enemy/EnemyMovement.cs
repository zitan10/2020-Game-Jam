using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

    public GameObject[] walls;

    private float clostestWallDistance;

    private Vector3 target;

	// Use this for initialization
	void Start () {
        walls = GameObject.FindGameObjectsWithTag("wall");

        target = new Vector3(0, 0, 0);

        clostestWallDistance = 10000f;
    }

	// Update is called once per frame
	void Update () {

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

        //Is enemy position close to player position?
        if (Vector3.Distance(target, this.transform.position) < 4000)
        {
            //Direction from wall to enemy
            Vector3 direction = target - this.transform.position;
            //Prevent enemy from rotation upwards
            direction.y = 0;
            //Rotate towards wall
            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(direction), 1f * Time.deltaTime);

            //Stop just outside the wall
            if (Vector3.Distance(target, this.transform.position) > 20)
            {
                //Move enemy towards player if position is close to player
                this.transform.Translate(0, 0, 0.025f);
            }
        }
    }
}
