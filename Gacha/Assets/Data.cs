using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Data : MonoBehaviour
{
    public GameObject[] combatCharacters;
    public GameObject[] collectionCharacters;
    public GameObject[] gachaCharacters;
    public GameObject[] gachaRareCharacters;
    public static GameObject[] combatCharacterData;
    public static GameObject[] collectionCharacterData;
    public static GameObject[] gachaCharacterData;
    public static GameObject[] gachaRareCharacterData;


    void Start()
    {
       // combatCharacterData = combatCharacters;
        collectionCharacterData = collectionCharacters;
        gachaCharacterData = gachaCharacters;
        gachaRareCharacterData = gachaRareCharacters;
    }
}
