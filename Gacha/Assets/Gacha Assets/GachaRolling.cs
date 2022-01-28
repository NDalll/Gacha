using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GachaRolling : MonoBehaviour
{
    public List<GameObject> rareList;
    public List<GameObject> normalList;
    private GameObject[] charactersList;
    private int rareSlot;
    private int randomCharacter;
    private bool rolling = false;
    public int i;

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
     rolling = true;
        
     rareSlot = Random.Range(1, 10);

        if (i == rareSlot)
        {
            randomCharacter = Random.Range(1, rareList.Count);
            Instantiate(rareList[randomCharacter]);
        }
        else
        {
            randomCharacter = Random.Range(1, normalList.Count);
        }
    }
    public void RollOne()
    {
        rareSlot = Random.Range(1, 10);

        randomCharacter = Random.Range(1, normalList.Count);
    }
}
