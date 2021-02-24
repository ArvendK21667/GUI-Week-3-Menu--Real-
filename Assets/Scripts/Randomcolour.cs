using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Randomcolour : MonoBehaviour
{
    public Image image;

    public void Randomisecolour()
    {
        int redCol = Random.Range(0, 256);
        int blueCol = Random.Range(0, 256);
        int greenCol = Random.Range(0, 256);
        

       Color32 RandomColour = new Color32((byte)redCol, (byte)blueCol, (byte)greenCol, 255);




        image.color = RandomColour;

        
    }








}
