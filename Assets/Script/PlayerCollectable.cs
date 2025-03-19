using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCollectable : MonoBehaviour
{   
    public Text textComponent;
    public int gemNumber;
    // Start is called before the first frame update
    void Start()
    {  
        gemNumber = PlayerPrefs.GetInt("GemNumber", 0);
         textComponent = GameObject.FindGameObjectWithTag("GemUI").GetComponentInChildren<Text>();
        UpdateText();
    }

    // Update is called once per frame
    void UpdateText()
    {
        textComponent.text = gemNumber.ToString();
    }
    public void GemCollected()
    {
        gemNumber +=1;
        UpdateText();
    }
}
