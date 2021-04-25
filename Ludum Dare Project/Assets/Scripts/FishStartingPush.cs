using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishStartingPush : MonoBehaviour
{
    Rigidbody2D rigidbody;

    float speed = 60;

    bool pushCooldown = true;

    // Start is called before the first frame update
    void Start()
    {

        transform.position = new Vector2(Random.Range(-8, 8.1f), Random.Range(-4, 4.1f));


        rigidbody = gameObject.GetComponent<Rigidbody2D>();

        push();

    }

    void push()
    {
        float rnd = Random.Range(0, 360);

        transform.rotation = Quaternion.Euler(0, 0, rnd);

        rigidbody.AddRelativeForce(transform.up * speed);
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 v = GetComponent<Rigidbody2D>().velocity;
        float angle = Mathf.Atan2(v.y, v.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.AngleAxis(angle, Vector3.forward), 0.005f);

        if(rigidbody.velocity.x < 0.1f && rigidbody.velocity.y < 0.1f)
        {
            if (pushCooldown)
            {
                print("extra push");
                push();
                pushCooldown = false;
                Invoke("pushCool", 4f);
            }
        }


        if (rigidbody.velocity.x > 1.5f || rigidbody.velocity.y > 1.5f)
        {
            print("reset Force");
            rigidbody.velocity = Vector3.zero;
        }
    }

    void pushCool()
    {
        pushCooldown = true;
    }

}
