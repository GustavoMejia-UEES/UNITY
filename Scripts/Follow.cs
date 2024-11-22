using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    public float CamSpeed = 5f;
    public float CamAcceleration = 1.2f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update() 
    {
        CamSpeed += CamAcceleration * Time.deltaTime;
        transform.Translate(new Vector2(1f, 0f) * CamSpeed * Time.deltaTime);
    }
}
