using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VisionHandler : MonoBehaviour
{
    bool spotCooldown = true;
    public GameObject congr;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        print(collision.name);
        if(Input.GetKey(KeyCode.Mouse1))
        {
            if (spotCooldown)
            {
                spotCooldown = false;
                Invoke("reset", 5f);
                if(PlayerPrefs.GetString("target") == collision.name)
                {
                    targetFound();
                }
            }
        }

    }

    private void targetFound()
    {
        congr.SetActive(true);
        Invoke("levelEnd", 5f);
    }

    private void levelEnd()
    {
        SceneManager.LoadScene(1);
    }

    private void reset()
    {
        spotCooldown = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
