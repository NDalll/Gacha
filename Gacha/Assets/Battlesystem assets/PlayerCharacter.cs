using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
    public float damage;
    public float health;
    public float level;
    public float levelHpMultipler;
    public float levelDamageMultipler;
    public float basicAttackMultiplier;
    public float abilityMultiplier;
    public float ultimateMultiplier;
    public bool basicAttackAOE;
    public bool abilityAOE;
    public bool ultimateAOE;
    public bool isActive;
    public float healthbarSize;
    public GameObject healthbar;
    public GameObject marker;
    private Combat combat;
    private Enemy targetEnemy;
    private float startingHealth;
    private Vector3 localScale;

    // Start is called before the first frame update
    void Start()
    {
        combat = GameObject.FindGameObjectWithTag("Combat").GetComponent<Combat>();
        combat.playerCharacterList.Add(this.gameObject);
        startingHealth = health;
        localScale = healthbar.transform.localScale;
    }
    void Update()
    {
        if (isActive == true)
        {
            marker.SetActive(true);
        }
        else
        {
            marker.SetActive(false);
        }
        localScale.x = health / startingHealth * healthbarSize;
        healthbar.transform.localScale = localScale;
        if (health < 0)
        {
           gameObject.SetActive(false);
           damage = 0;
        }
    }
    public void Attack(int attackType, int target)
    {
        targetEnemy = combat.enemyList[target].GetComponent<Enemy>();
        if (attackType == 0)
        {
            targetEnemy.health -= damage * basicAttackMultiplier;
        }
        else if (attackType == 1)
        {
            targetEnemy.health -= damage * abilityMultiplier;
        }
        else if (attackType == 2)
        {
            targetEnemy.health -= damage * ultimateMultiplier;
        }
    }
}
