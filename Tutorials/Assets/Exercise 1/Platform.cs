using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public float speed;
    public float distance;
    public float timer;
    public bool moveX;
    public bool moveY;
    public bool moveZ;
    private int x;
    private int y;
    private int z;


    Vector3 start;
    Vector3 direction;
    // Start is called before the first frame update
    void Start()
    {
        //Q1.1) What would happen if we didnt save this? (see Q1.2)
        start = gameObject.transform.position;
        moveX = true;
        moveY = false;
        moveZ = false;
    }

    // Update is called once per frame
    void Update()
    {
        //Q1.2) Why would we add start?
        if (moveX) x = 1;
        else x = 0;
        if (moveY) y = 1;
        else y = 0;
        if (moveZ) z = 1;
        else z = 0;

        gameObject.transform.position = start + new Vector3(x * distance * Mathf.Cos(timer * speed), y * distance * Mathf.Cos(timer * speed), z * distance * Mathf.Cos(timer * speed));
        timer += Time.deltaTime;
    }

    void OnCollisionEnter(Collision collision)
    {
        collision.transform.SetParent(transform);
    }

    void OnCollisionExit(Collision collision)
    {
        collision.transform.SetParent(null);
    }
}
