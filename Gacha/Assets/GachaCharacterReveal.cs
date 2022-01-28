using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GachaCharacterReveal : MonoBehaviour
{
    public Button portrait;
    public Sprite art;
    public Text questionmark;
    public GameObject character;

    private bool clicked = false;
    public float lerpTime = 1;
    public float RotateAmount = 1;
    private float time = 0;

    public Quaternion startQuaternion;

    public void Start()
    {
        startQuaternion = transform.rotation;
    }

    public void Reveal()
    {
        portrait.interactable = false;
        Debug.Log("pressed");
        Invoke("ChangeArt", 0.7f);
        //character.transform.rotation = new Vector3(Mathf.Lerp(0, 360, 1), 0, 0);
        clicked = true;
        Invoke("StopSpin", 1);
    }

    void FixedUpdate()
    {
        if (clicked)
        {
            //transform.rotation = Quaternion.Lerp(transform.rotation, startQuaternion, Time.deltaTime * lerpTime);

            transform.Rotate(Vector3.up * RotateAmount);

        }
    }
    void StopSpin()
    {
        clicked = false;
    }

    void ChangeArt()
    {
        portrait.image.sprite = art;
        questionmark.gameObject.SetActive(false);
        portrait.image.color = Color.white;
    }
}
