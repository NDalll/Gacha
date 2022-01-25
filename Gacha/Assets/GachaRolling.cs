using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GachaRolling : MonoBehaviour
{
    public List<GameObject> charactersList;
    public List<GameObject> rareList;
    public List<GameObject> normalList;
    public int rareSlot;
    public int randomCharacter;

    // Start is called before the first frame update
    void Start()
    {
        charactersList = Data.gachaCharacterData;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RollTen()
    {
        rareSlot = Random.Range(1, 10);
        for (int i = 0; i < 10; i++)
        {
            if (i == rareSlot)
            {
                randomCharacter = Random.Range(1, rareList.Count);
            }
            else
            {
                randomCharacter = Random.Range(1, normalList.Count);
            }
        }
    }
}
