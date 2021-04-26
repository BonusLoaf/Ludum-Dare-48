using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    Vector2 mousePos;
    Rigidbody2D rigidbody;
    public Light spotlight;
    public float strength;
    public GameObject vision;
    bool spotCooldown = true;
    public AudioSource swimSound;
    public AudioSource bubbleLong;

    Color32 spotColour = new Color32(0xFF, 0xD5, 0x64, 0xFF);

     Vector3 force;

    public GameObject systemScript;

    string target;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = gameObject.GetComponent<Rigidbody2D>();
        force = strength * transform.right;

        randomiseTarget();

        systemScript.SendMessage("Initialise");

    }

    void randomiseTarget()
    {

        int rnd = Random.Range(0, SystemHandler.numOfTargets);

        switch (rnd)
        {
            case 0:
                target = "Billy The Squid";
                break;
            case 1:
                target = "Sandy The Starfish";
                break;
            case 2:
                target = "Chocolate Starfish";
                break;
            case 3:
                target = "Phinn The Shark";
                break;
            case 4:
                target = "Suzzie";
                break;
            case 5:
                target = "Crimson The Fish";
                break;
            case 6:
                target = "Emerald The Fish";
                break;
            case 7:
                target = "Aqua The Fish";
                break;
            case 8:
                target = "Fancy Francis";
                break;
            default:
                target = "Billy The Squid";
                break;
        }

        print(target);

        PlayerPrefs.SetString("target", target);
    }

    // Update is called once per frame
    void  Update()
    {
        //transform.LookAt(mousePos);

        Vector3 dir = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        Quaternion rotate = Quaternion.AngleAxis(angle, Vector3.forward);

        transform.rotation = Quaternion.Lerp(transform.rotation, rotate, Time.time * 0.005f);


        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            rigidbody.AddRelativeForce(force);
            swimSound.Play();
        }

        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            if (spotCooldown)
            {
                bubbleLong.Play();
                vision.SendMessage("TriggerSpot", SendMessageOptions.DontRequireReceiver);
                spotlight.color = Color.white;
                spotCooldown = false;
                Invoke("resetSpot", 0.2f);
            }
        }
    }


    void resetSpot()
    {
        spotlight.color = spotColour;
        Invoke("spotCool", 2f);
    }

    void spotCool()
    {
        spotCooldown = true;
    }

}
