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

    Color32 spotColour = new Color32(0xFF, 0xD5, 0x64, 0xFF);

     Vector3 force;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = gameObject.GetComponent<Rigidbody2D>();
        force = strength * transform.right;
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
        }

        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            if (spotCooldown)
            {
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
        Invoke("spotCool", 5f);
    }

    void spotCool()
    {
        spotCooldown = true;
    }

}
