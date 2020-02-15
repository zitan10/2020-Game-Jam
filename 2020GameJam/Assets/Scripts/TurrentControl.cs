using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurrentControl : MonoBehaviour {

    public GameObject turrent1;
    public Transform player;

	// Use this for initialization
	void Start () {
        turrent1.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		if (Vector3.Distance(player.position, this.transform.position) < 5)
        {
            if (Input.GetKeyDown(KeyCode.T))
            {
                turrent1.SetActive(true);
                this.gameObject.SetActive(false);
            }
        }
	}
}
