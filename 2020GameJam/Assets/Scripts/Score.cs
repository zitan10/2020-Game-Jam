using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

    public Text scoreText;
    private GameObject GameLogic;
    private LevelControl levelControl;
    private GameObject[] walls;

    // Use this for initialization
    void Start () {
        GameLogic = GameObject.Find("GameLogic");
        levelControl = GameLogic.GetComponent<LevelControl>();

    }
	
	// Update is called once per frame
	void Update () {
        walls = GameObject.FindGameObjectsWithTag("wall");
        scoreText.text = "Total Score: " + (levelControl.level + walls.Length).ToString();
	}
}
