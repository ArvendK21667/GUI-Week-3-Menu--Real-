using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Variables1 : MonoBehaviour
{
    #region My Variables
    //Single line comment
    [Header("Standard Variables")]
    public int wholeNumber;
    public float decimalNumber; //This is a Float
    [Space(20)]
    public string groupingOfCharecters;
    public bool trueOrFalse;

    [Header("Unity Variables")]
    public Vector2 twoFloats; //X,Y
    public Vector3 threeFloats; //X,Y,Z
    public GameObject objectInGame;
    public Transform PositionRotationScale;
    #endregion
    #region Comment
    /*
     Anything inbetween is a comment
     */
    #endregion

    #region My Debug.Logs
    //Runs even if the script is disabled
    //as long as the gameObject is enaled
    void Awake()
    {
        Debug.Log("Awake");
    }

    //Runs everytime the script and gameobject is enabled
    //also rund before start()
    void OnEnable()
    {
        Debug.Log("OnEnable");
    }

    //Gets called before the first frame of your game
    private void Start()
    {
        Debug.Log("Start");

        //MyMethod();
    }
    #endregion

    #region Update Events

    //Runs ever frame
    void Update()
    {
        Debug.Log("Update");
    }

    //Runs after update()
    void LateUpdate()
    {
        Debug.Log("LateUpdate");
    }

    //Runs on a fixed time scale (0.02 seconds)
    void FixedUpdate()
    {
        Debug.Log("FixedUpdate");
    }

    #endregion

    #region Terminate Events

    //Runs when your script or gameobject gets disabled
    //used to clean up your class
    //also runs before OnDestroy
    void OnDisable()
    {
        Debug.Log("OnDisable");
    }

    //is called when object being destroyed, when a scene ends or 
    //is unloaded, application is quitting or user stops playing mode in unity
    void OnDestroy()
    {
        Debug.Log("OnDestroy");
    }

    #endregion

    #region GUI
    //Runs after later update
    //Mainly used for IMGUI
    void OnGUI()
    {
        Debug.Log("OnGUI");
    }

    #endregion

    #region Physics



    void OnCollisionEnter(Collision colission) { }
      


    void OnCollisionStay(Collision colission) { }
    void OnCollisionExit(Collision colission) { }

    void OnCollisionEnter(Collider collision) { }
    void OnCollisionStay(Collider collision) { }
    void OnCollisionExit(Collider collision) { }

    #endregion

    /*id Start()
    {
        MyMethod();

    } */


    public void MyMethod()
    {
        float answer;

        answer = decimalNumber + 3.5f;


        // or is ||
        // and is &&
        // equal to is ==
        // Greater or less than is > or <
        // Greater or Less or equal too is >= or <=

             //13
        if (wholeNumber >= 2 && wholeNumber <= 13) //trueOrFalse
        {
            answer++; //Increase by 1
            answer--; //decrease by 1
            answer--;
            answer += 100; //Increase by 100
            answer -= 50; //Decrease by 50
            answer *= 12; //Multiply by 12
            answer /= 2; //Divide by 2

        }

        else if(answer > 5)
        {
            answer = 9999;
        }
        else
        {

            answer = 0;
        }
        Debug.Log(answer);

        #region My Notes
        /*d update()
         {
             vector3 pos = transform.position;
             pos.x += 0.2f * time.deltatime;
             transform.position = pos;
         }*/
        #endregion
    }
}
