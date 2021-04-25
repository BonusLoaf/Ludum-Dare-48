using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SystemHandler : MonoBehaviour
{

    public static int numOfTargets = 6;

    public Image letter;

    public Image targInd;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Initialise()
    {

        letter.sprite = Resources.Load<Sprite>(PlayerPrefs.GetString("target") + " Letter");

        targInd.sprite = Resources.Load<Sprite>(PlayerPrefs.GetString("target"));

        targInd.SetNativeSize();

        

        Invoke("disableLetter", 5f);
    }

    void disableLetter()
    {
        letter.enabled = false;
    }
}
