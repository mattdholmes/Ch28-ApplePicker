﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour
{
    public GameObject applePrefab;
    public float speed = 1f;
    public float lrEdge = 10f;
    public float directionalChange = 0.1f;
    public float appleRate = 1f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("DropApple", 2f, appleRate);
    }

    void DropApple()
    {
        GameObject apple = Instantiate(applePrefab) as GameObject;
        apple.transform.position = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;
        if ( pos.x < -lrEdge )
        {
            speed = Mathf.Abs(speed);
        }else if (pos.x > lrEdge)
        {
            speed = -Mathf.Abs(speed);
        }
    }
    void FixedUpdate()
    {
        if (Random.value < directionalChange)
        {
            speed *= -1;
        }
    }
}
