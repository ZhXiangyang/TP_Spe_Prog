using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubble : MonoBehaviour
{
    public float value = 10;
    public int indexX;
    public int indexY;
    public enum Typecolor {black, blue, green, orange, purple, red, yellow};
    public Typecolor type;
    public enum State {wait, moving, merged}
    public State state;
    private Rigidbody2D rb;
    private Vector3 lastVelocity;

    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        lastVelocity = rb.velocity;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("hit");
    }

}
