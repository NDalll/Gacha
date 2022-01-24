using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    private Combat combat;
    public bool target = false;
    public GameObject marker;
    public GameObject healthbar;
    public float health;
    public float damage;
    public float healthbarSize;

    private float startingHealth;
    private Vector3 localScale;
    private PlayerCharacter player;
    void Start()
    {
        combat = GameObject.FindGameObjectWithTag("Combat").GetComponent<Combat>();
        combat.enemyList.Add(this.gameObject);
        startingHealth = health;
        localScale = healthbar.transform.localScale;

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

        localScale.x = health / startingHealth * healthbarSize;
        healthbar.transform.localScale = localScale;

        if (health <= 0)
        {
            target = false;
            gameObject.SetActive(false);
            damage = 0;
        }
    }
    public void Attack()
    {

        int target = Random.Range(0, combat.playerCharacterList.Count);
        player = combat.playerCharacterList[target].GetComponent<PlayerCharacter>();
        player.health -= damage;
    }
    void Delay()
    {
        combat.targetChosen = true;
        target = true;
    }
}

