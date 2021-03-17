using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HotkeyRebinder : MonoBehaviour
{
    ///Dictionaries are like arrays, except the "index" number is replaced with a string in this case
    ///So you have a name, and a definition. Like the actual book dictionary.
    ///Name: JumpKey. Definition: SpaceBar
    [SerializeField]        //This holds the keys with both the string name of the action, and the keyCode input.
    public static Dictionary<string, KeyCode> keys = new Dictionary<string, KeyCode>();


    /// <summary>
    /// Structs are like making custom collections of information. A Vector3 is technically a struct of 3 Float values
    /// However, we can make them use different data types when we make our own.
    /// In this case, a string, a text object, and another string.
    /// </summary>
    [System.Serializable]                               //So it shows up in the inspector
    public struct KeyUISetup
    {
        public string keyName;                          //THIS NEEDS TO BE THE SAME AS THE NAME OF THE BUTTON GAMEOBJECT
        public TextMeshProUGUI keyDisplayText;          //The text object in the simulation
        public string defaultKey;                       //What we default the key to.
    }

    public KeyUISetup[] baseSetup;                                          //We've made the struct, now we need an array of them. One for each button we press.
    public GameObject currentKey;                                           //Reference to the Key we are currently rebinding.
    public Color32 changedKey = new Color32(40, 70, 250, 255);              //When we click a key rebind button, make it orange. Feedback to the player.
    public Color32 selectedKey = new Color32(255, 100, 30, 255);            //WHen we've rebinded it, make it blue. More feedback.



    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < baseSetup.Length; i++)
        {
            //The actual name of the GameObject Button is what we compare to the BaseSetup Key Name
            //As such, we set this first to ensure no name mismatches.
            baseSetup[i].keyDisplayText.transform.parent.name = baseSetup[i].keyName;

            keys.Add(baseSetup[i].keyName, (KeyCode)System.Enum.Parse(typeof(KeyCode),      
                PlayerPrefs.GetString(baseSetup[i].keyName, baseSetup[i].defaultKey)));         //This is us generating our dictionary.

            baseSetup[i].keyDisplayText.text = keys[baseSetup[i].keyName].ToString();           //Also make all the text elements update to reflect their keys

        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SaveKeys()
    {
        foreach (var thisKey in keys)
        {
            PlayerPrefs.SetString(thisKey.Key, thisKey.Value.ToString());               //Save to PlayerPrefs for each key
        }
        PlayerPrefs.Save();                                                             //Actually save it.
    }

    public void LoadKeys()
    {
        for (int i = 0; i < baseSetup.Length; i++)
        {
            //To access dictionary values, we need to put the *string* in the [], not an integer. It's not like arrays.
            //This NewKey string will be the button we have assigned.
            string newKey = keys[baseSetup[i].keyName].ToString();

            newKey = PlayerPrefs.GetString(baseSetup[i].keyName);

            baseSetup[i].keyDisplayText.transform.parent.GetComponent<Image>().color = Color.white;
        }
    }

    public void ChangeKey(GameObject clickedKey)                    //Function for a button when we select it.
    {
        currentKey = clickedKey;
        if(clickedKey != null)
        {
            currentKey.GetComponent<Image>().color = selectedKey;   //Just visual aid
        }
    }

    private void OnGUI()    //Allows us to run events. In this dase, key presses.
    {
        string newKey = "";
        Event e = Event.current;

        if (currentKey == null) //If we don't currently have a key to rebind, don't do anything.
            return;

        if (e.isKey)    //This is how we know it's a key press input.
        {
            newKey = e.keyCode.ToString();
        }

        //Shift keys have a special issue, so we need to account for that
        if (Input.GetKey(KeyCode.LeftShift))
        {
            newKey = "LeftShift";
        }
        else if (Input.GetKey(KeyCode.LeftShift))
        {
            newKey = "RightShift";
        }
        //Now just to confirm if we have made an input... can't leave it null by accident
        if (newKey != "")
        {
            //Changes our key in the Dictionary to the key we just pressed.
            keys[currentKey.name] = (KeyCode)System.Enum.Parse(typeof(KeyCode), newKey);

            //Change the display text to match
            currentKey.GetComponentInChildren<TextMeshProUGUI>().text = newKey;

            //Change colour to display changed key
            currentKey.GetComponent<Image>().color = changedKey;

            //Reset to avoid errors with future rebinds.
            currentKey = null;
        }

    }

}
