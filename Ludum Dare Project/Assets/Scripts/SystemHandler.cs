using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SystemHandler : MonoBehaviour
{

    public static int numOfTargets = 9;

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

    public void exit()
    {
        SceneManager.LoadScene(0);
    }

    void disableLetter()
    {
        letter.enabled = false;
    }
}
