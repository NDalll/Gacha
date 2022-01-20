using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackButtons : MonoBehaviour
{
    public bool isUltimate;
    public bool isAbility;
    public bool isBasicAttack;
    private Combat combat;
    public int attackType;
    // Start is called before the first frame update
    void Start()
    {
        combat = GameObject.FindGameObjectWithTag("Combat").GetComponent<Combat>();
        if (isBasicAttack)
        {
            attackType = 0;
        }
        else if (isAbility)
        {
            attackType = 1;
        }
        else if (isUltimate)
        {
            attackType = 2;
        }
        else
        {
            attackType = 0;
        }
    }

    public void buttonPressed()
    {
        combat.Attack(attackType);
    }
}
