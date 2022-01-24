using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combat : MonoBehaviour
{
    private Enemy currentEnemy;
    private Enemy attackingEnemy;
    private PlayerCharacter currentCharacter;
    public List<GameObject> enemyList;
    public List<GameObject> playerCharacterList;
    public int targetid = 1;
    public bool targetChosen = true;
    public int activeCharacter = 0;
    private bool chosenCharacterDead = false;
    // Start is called before the first frame update
    void Start()
    {
        currentCharacter = playerCharacterList[activeCharacter].GetComponent<PlayerCharacter>();
        currentCharacter.isActive = true;
    }
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
       /* if (currentCharacter.health < 0)
        {
            chosenCharacterDead = true;
        }
        while (chosenCharacterDead)
        {
            currentCharacter = playerCharacterList[activeCharacter].GetComponent<PlayerCharacter>();
            if (currentCharacter.health < 0)
            {
                chosenCharacterDead = true;
            } 
            else if (currentCharacter.health < 0)
            {
                chosenCharacterDead = false;
            }
            activeCharacter++;
        }*/

        if (activeCharacter <= playerCharacterList.Count)
        {
            if (attackType == 0)
            {
                currentCharacter.Attack(attackType, targetid);
                Debug.Log("basic attack clicked");
            }
            else if (attackType == 1)
            {
                //run character attack
                currentCharacter.Attack(attackType, targetid);
                Debug.Log("ability clicked");
            }
            else if (attackType == 2)
            {
                //run character attack
                currentCharacter.Attack(attackType, targetid);
                Debug.Log("Ultimate clicked");
            }
        }

        activeCharacter += 1;
        if (activeCharacter >= playerCharacterList.Count)
        {
            EnemyAttack();
        }
        currentCharacter.isActive = false;
        currentCharacter = playerCharacterList[activeCharacter].GetComponent<PlayerCharacter>();
        currentCharacter.isActive = true;
    }
    public void EnemyAttack()
    {
        for (int i = 0; i < enemyList.Count; i++)
        {
            attackingEnemy = enemyList[i].GetComponent<Enemy>();
            attackingEnemy.Attack();
        }
        //enemies attack
        Debug.Log("Enemies attack");
        activeCharacter = 0;
    }
}

