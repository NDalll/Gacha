using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
    public float damage;
    public float health;
    public float basicAttackMultiplier;
    public float abilityMultiplier;
    public float ultimateMultiplier;
    public bool basicAttackAOE;
    public bool abilityAOE;
    public bool ultimateAOE;

    private Combat combat;
    private Enemy targetEnemy;

    // Start is called before the first frame update
    void Start()
    {
        combat = GameObject.FindGameObjectWithTag("Combat").GetComponent<Combat>();
        combat.playerCharacterList.Add(this.gameObject);
    } 
    public void attack(int attackType, int target)
    {
        if (attackType == 0)
        {
            targetEnemy = combat.enemyList[target].GetComponent<Enemy>();
            targetEnemy.health =- damage * basicAttackMultiplier;
            //run character attack

        }
        else if (attackType == 1)
        {
            targetEnemy = combat.enemyList[target].GetComponent<Enemy>();
            targetEnemy.health = -damage * abilityMultiplier;
            //run character attack

        }
        else if (attackType == 2)
        {
            //run character attack
            targetEnemy = combat.enemyList[target].GetComponent<Enemy>();
            targetEnemy.health = -damage * ultimateMultiplier;
        }
    }


}
