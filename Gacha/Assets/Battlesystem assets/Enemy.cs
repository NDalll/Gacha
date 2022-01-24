using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    private Combat combat;
    public bool target = false;
    public GameObject marker;
    public Slider healthbar;
    public float health;
    

    void Start()
    {
        combat = GameObject.FindGameObjectWithTag("Combat").GetComponent<Combat>();
        combat.enemyList.Add(this.gameObject);
    }

    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (combat.targetChosen == true && target == false)
            {
                combat.targetChosen = false;
                Invoke("Delay", 0.01f);
                target = true;
            }
            else
            {
                combat.targetChosen = true;
                target = true;
            }
        } 
    }

    // Update is called once per frame
    void Update()
    {
        if (target == true)
        {
            marker.SetActive(true);
        }
        else
        {
            marker.SetActive(false);
        }
        if (combat.targetChosen == false)
        {
            target = false;
        }

        if (health <= 0)
        {
            target = false;
            gameObject.SetActive(false);
        }
    }

    void Delay()
    {
        combat.targetChosen = true;
        target = true;
    }
}

