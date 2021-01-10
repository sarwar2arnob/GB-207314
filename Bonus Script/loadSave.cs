using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour
{
    public InputField text;
    private Text input;

    public void save()
    {
        PlayerPrefs.SetString("name", text.text);
        
    }
    public void load()
    {
        input.text = PlayerPrefs.GetString("name");
    }
}
