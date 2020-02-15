using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyOneAIMovement : MonoBehaviour {

    public Transform player;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
            //Is enemy position close to player position?
            if (Vector3.Distance(player.position, this.transform.position) < 40)
            {
                //Direction from player to enemy
                Vector3 direction = player.position - this.transform.position;
                //Prevent enemy from rotation upwards
                direction.y = 0;
                //Rotate towards player
                this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(direction), 1f * Time.deltaTime);

                //Move enemy towards player if position is close to player
                this.transform.Translate(0, 0, 0.025f);
            }
        }
    
}
