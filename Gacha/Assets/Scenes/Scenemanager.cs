using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scenemanager : MonoBehaviour
{ 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void ToCombatScene()
    {
        SceneManager.LoadScene("Combat");
    }
    public void ToGachaScene()
    {
        SceneManager.LoadScene("Gacha");
    }
    public void ToRollingScene()
    {
        if (FreeGemTimer.freeGems >= 900)
        {
            FreeGemTimer.freeGems = FreeGemTimer.freeGems - 900;
            PlayerPrefs.SetInt("freeGems", FreeGemTimer.freeGems);
            SceneManager.LoadScene("Rolling");
        }
    }
    public void ToMainScene()
    {
        SceneManager.LoadScene("Main");
    }
}
