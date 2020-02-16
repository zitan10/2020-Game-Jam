using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class LevelControl : MonoBehaviour {

    public int level;
    private bool nextWave;
    private GameObject Player;
    public Text scoreText;

    // Use this for initialization
    void Start () {
        level = 1;
        nextWave = true;
        Player = GameObject.Find("PlayerObject");
        PlayerHP PlayerHPScript = Player.GetComponent<PlayerHP>();
        scoreText.text = "";
    }
	
	// Update is called once per frame
	void Update () {

        PlayerHP PlayerHPScript = Player.GetComponent<PlayerHP>();
        if (PlayerHPScript.current_hp <= 0)
        {
            scoreText.text = "You Dead, press F to restart";
            Player.GetComponent<PlayerController>().enabled = false;
            if (Input.GetKeyDown(KeyCode.F))
            {
                SceneManager.LoadScene("SampleScene");
            }
        }

        GameObject[] enemies;

        //Check how many enemies left
        if (!nextWave)
        {
            enemies = GameObject.FindGameObjectsWithTag("enemyTag");
            Debug.Log(enemies.ToString());
            if (enemies == null || enemies.Length == 0)
            {
                nextWave = true;
                level++;
            }
        }

        //Create new wave
        else
        {
            SpawnEnemies();
            nextWave = false;
        }

	}

    void SpawnEnemies()
    {
        GameObject enemy;
        enemy = Resources.Load("EnemyOne") as GameObject;
        for (int i = 0; i < level; i++)
        {
            GameObject enemySpawn1 = Instantiate(enemy) as GameObject;
            GameObject enemySpawn2 = Instantiate(enemy) as GameObject;
            GameObject enemySpawn3 = Instantiate(enemy) as GameObject;
            GameObject enemySpawn4 = Instantiate(enemy) as GameObject;

            enemySpawn1.transform.position =
                new Vector3(Random.Range(50, 70), 2.8f, Random.Range(-85, -15));
            enemySpawn2.transform.position =
                new Vector3(Random.Range(-20, 40), 2.8f, Random.Range(-80, 0));
            enemySpawn3.transform.position =
                new Vector3(Random.Range(-65, -35), 2.8f, Random.Range(-70, 3));
            enemySpawn4.transform.position =
                new Vector3(Random.Range(-30, 25), 2.8f, Random.Range(10, 30));
        }
    }
    void OnGUI()
    {
        GUI.Label(new Rect(10, 10, 100, 20), level.ToString());
    }
}
