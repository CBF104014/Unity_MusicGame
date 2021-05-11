using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleEvent : MonoBehaviour
{
    public float CircleSpeed = -7f;

    void Start(){ }

    void Update()
    {
        this.transform.Translate(new Vector2(0, CircleSpeed * Time.deltaTime));
    }
}
