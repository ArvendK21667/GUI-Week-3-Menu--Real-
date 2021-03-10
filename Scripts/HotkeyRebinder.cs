using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class HotkeyRebinder : MonoBehaviour
{

    [SerializeField]
    public static Dictionary<string, KeyCode> keys = new Dictionary<string, KeyCode>();


    [System.Serializable]
    // Start is called before the first frame update
    public struct KeyUISetup
    {
        public string keyName;
        public TextMeshProUGUI keyDisplayText;
        public string defaultKey;

    }

    public KeyUISetup[] baseSetup;
    public GameObject currentButton;
    public Color32 changedKey = new Color32(40, 70, 250, 255);
    public Color32 selectedKey = new Color32(40, 70, 250, 255);


    private void Start()
    {
        for (int i = 0; i < baseSetup.Length; i++)
        {
            baseSetup[i].keyDisplayText.transform.parent.name = baseSetup[i].keyName;

            keys.Add(baseSetup[i].keyName,
                (KeyCode)System.Enum.Parse(typeof(KeyCode),
                PlayerPrefs.GetString(baseSetup[i].keyName, baseSetup[i].defaultKey)));

            baseSetup[i].keyDisplayText.text = keys[baseSetup[i].keyName].ToString(); 
        }
    }
    // Update is called once per frame
    private void Update()
    {

    }

    public void SaveKeys()
    {
        foreach (var thisKey in keys)
        {
            PlayerPrefs.SetString(thisKey.Key, thisKey.Value.ToString());
        }
        PlayerPrefs.Save();
    }

    public void LoadKeys()
    {
        for (int i = 0; i < baseSetup.Length; i++)
        {
            string newKey = keys[baseSetup[i].keyName].ToString();

            newKey = PlayerPrefs.GetString(baseSetup[1].keyName);

            baseSetup[i].keyDisplayText.transform.parent.GetComponent<Image>().color = Color.white;

        }
    }

    public void ChangeKey(GameObject clickedKey)
    {
        currentButton = clickedKey;
        if (clickedKey != null)
        {
            currentButton.GetComponent<Image>().color = selectedKey;
        }
    }

    private void OnGUI()
    {
        string newKey = "";
        Event e = Event.current;

        if (currentButton == null)
            return;

        if (e.isKey)
        {
            newKey = e.keyCode.ToString();
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            newKey = "LeftShift";
        }
        else if (Input.GetKey(KeyCode.RightShift))
        {
            newKey = "RightShift";

        }

        if (newKey != "")
        {

            keys[currentButton.name] = (KeyCode)System.Enum.Parse(typeof(KeyCode), newKey);

            currentButton.GetComponentInChildren<TextMeshProUGUI>().text = newKey;

            currentButton.GetComponent<Image>().color = changedKey;

            currentButton = null;
        }


    }
}

