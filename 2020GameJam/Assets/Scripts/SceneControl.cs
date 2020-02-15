using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneControl : MonoBehaviour {

    public Transform player;
    public Transform flag;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (Vector3.Distance(player.position, flag.transform.position) < 5) { 
            UnityEngine.SceneManagement.SceneManager.LoadScene("SampleScene");
        }
	}
}
