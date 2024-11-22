using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class NewMonoBehaviourScript : MonoBehaviour
{
    public float PlayerSpeed = 5f;
    public float Acceleration = 1.2f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update() 
    {
        PlayerSpeed += Acceleration * Time.deltaTime;
        transform.Translate(new Vector2(1f, 0f) * PlayerSpeed * Time.deltaTime);
    }
}
