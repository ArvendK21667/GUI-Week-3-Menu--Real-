using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveObject : MonoBehaviour
{

    public Transform obj;

    public void MoveHorizontally(float value)
    {
        obj.position = new Vector3(value, 0, 0);

        PlayerPrefs.SetFloat("Pos", value);
    }

    void Start()
    {
        float pos = PlayerPrefs.GetFloat("Pos");
        MoveHorizontally(pos);
    }
}
