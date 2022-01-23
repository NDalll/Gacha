using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackButtons : MonoBehaviour
{
    public bool isUltimate;
    public bool isAbility;
    public bool isBasicAttack;
    private Combat combat;
    private int attackType;
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

    void Update()
    {
        //Change icon for attack based on character
    }

    public void buttonPressed()
    {
        combat.Attack(attackType);
    }
}
