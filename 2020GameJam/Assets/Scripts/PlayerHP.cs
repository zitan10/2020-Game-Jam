using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHP : MonoBehaviour
{
    // Start is called before the first frame update
    public int starting_hp = 10000;
    public int current_hp;
    public Slider HealthSlider;

    void Start()
    {
        current_hp = starting_hp;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "EnemyProjectile")
        {
            current_hp--;
            if (current_hp >= 0)
            {
                HealthSlider.value = current_hp;
            }

        }

    }
}
