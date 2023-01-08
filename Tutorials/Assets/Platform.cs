using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public float speed;
    public float distance;
    public float timer;

    Vector3 start;
    // Start is called before the first frame update
    void Start()
    {
        start = gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = start + new Vector3(distance * Mathf.Cos(timer*speed), 0, 0);
        timer += Time.deltaTime ;
    }
}
