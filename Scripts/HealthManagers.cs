using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using TMPro;


public class HealthManagers : MonoBehaviour
{

    public float health;
    public float maxhealth;
    public Image healthbar;
  //  public TextMeshProUGUI number;

    // Start is called before the first frame update
    void Start()
    {
        health = maxhealth;
        healthbar.fillAmount = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("b"))
        {
            health = health - 5;
            if (health < 0)
            {
                health = 0;
            }
            float fraction = health / maxhealth;
            healthbar.fillAmount = fraction;
            //number.text = health + "/" + maxhealth;
        }

        if (Input.GetKeyDown("n"))
        {
            health = health + 5;
            if (health > 100)
            {
                health = 100;
            }
            float fraction = health / maxhealth;
            healthbar.fillAmount = fraction;
            //number.text = health + "/" + maxhealth;
        }
    }
}
