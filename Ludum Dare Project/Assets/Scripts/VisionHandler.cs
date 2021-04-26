using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VisionHandler : MonoBehaviour
{
    bool spotCooldown = true;
    public GameObject congr;
    public AudioSource celebrationSound;
    //private List<string> allCollisionObjects;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        print(collision.name);
        if (Input.GetKey(KeyCode.Mouse1))
        {
            if (spotCooldown)
            {
                spotCooldown = false;
                Invoke("reset", 2f);
                if (PlayerPrefs.GetString("target") == collision.name)
                {
                    targetFound();
                }
            }
        }
    }
        //}

        //private void OnCollisionEnter2D(Collision2D collision)
        //{

        //        if (!allCollisionObjects.Contains(collision.gameObject.name))
        //        {
        //            allCollisionObjects.Add(collision.gameObject.name);
        //        }

        //}

        //private void OnCollisioExit2D(Collision2D collision)
        //{



        //            allCollisionObjects.Remove(collision.gameObject.name);


        //}
    

        private void targetFound()
    {
        congr.SetActive(true);
        celebrationSound.Play();
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
        ////print(collision.name);
        //if (Input.GetKey(KeyCode.Mouse1))
        //{
        //    print(allCollisionObjects);
        //    if (spotCooldown)
        //    {
        //        spotCooldown = false;
        //        Invoke("reset", 2f);
        //        foreach (string collider in allCollisionObjects)
        //        {
        //            if (PlayerPrefs.GetString("target") == collider)
        //            {
        //                targetFound();
        //            }
        //        }
                
        //    }
        //}
    }
}
