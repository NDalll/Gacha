using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollSpawnpoint : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (true)
        {

        }
        GameObject[] characters = Data.gachaCharacterData;
        int randomnumber = Random.Range(0, characters.Length);
        Instantiate(characters[randomnumber], transform.position, characters[randomnumber].transform.rotation, transform);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
