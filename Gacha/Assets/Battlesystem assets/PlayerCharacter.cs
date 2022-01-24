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

    public GameObject marker;
    private Combat combat;
    private Enemy targetEnemy;

    // Start is called before the first frame update
    void Start()
    {
        combat = GameObject.FindGameObjectWithTag("Combat").GetComponent<Combat>();
        combat.playerCharacterList.Add(this.gameObject);
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
