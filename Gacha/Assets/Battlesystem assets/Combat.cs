using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combat : MonoBehaviour
{
    private Enemy currentEnemy;
    private PlayerCharacter currentCharacter;
    public List<GameObject> enemyList;
    public List<GameObject> playerCharacterList;
    public int targetid = -1;
    public static bool targetChosen = false;
    public int activeCharacter = 0;
    // Start is called before the first frame update

    void Update()
    {
        for (int i = 0; i < enemyList.Count; i++) 
        {
            currentEnemy = enemyList[i].GetComponent<Enemy>();
            if (currentEnemy.target == true)
            {
                targetid = i;
            }
        }
    } 
    public void Attack(int attackType)
    {   
        currentCharacter = playerCharacterList[activeCharacter].GetComponent<PlayerCharacter>();

        if (attackType == 0)
        {
            Debug.Log("basic attack clicked");
        }
        else if (attackType == 1)
        {
            //run character attack
            Debug.Log("ability clicked");
        }
        else if (attackType == 2)
        {
            //run character attack
            Debug.Log("Ultimate clicked");
        }
        if (activeCharacter <= playerCharacterList.Count - 1)
        {
            currentCharacter.attack(targetid, attackType);
            activeCharacter =+ 1;
        }
        if (activeCharacter > playerCharacterList.Count - 1)
        {
            EnemyAttack();
        }

    }
    public void EnemyAttack()
    {
        //enemies attack

        activeCharacter = 0;
    }
}

