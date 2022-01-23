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
            if (Combat.targetChosen == true && target == false)
            {
                Combat.targetChosen = false;
                Invoke("Delay", 0.01f);
                target = true;
            }
            else
            {
                Combat.targetChosen = true;
                target = true;
            }
        } 
        if (health <= 0)
        {
            Destroy(gameObject);
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
        if (Combat.targetChosen == false)
        {
            target = false;
        }
    }

    void Delay()
    {
        Combat.targetChosen = true;
        target = true;
    }
}
