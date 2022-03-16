using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    float speed = 20f;
    public BoxCollider2D boxCollider { get; private set; }
    void Start()
    {
       
        boxCollider = GetComponent<BoxCollider2D>();
        Destroy(this.gameObject, 2f);
    }
    private void Update()
    {
        Movement();
    }

    protected virtual void Movement()
    {
        this.transform.position += this.transform.up * Time.deltaTime * speed;
    }
    private void CheckCollision(Collider2D other)
    {
        Bunker bunker = other.gameObject.GetComponent<Bunker>();

        if (bunker == null || bunker.CheckCollision(boxCollider, transform.position) || other.tag== "Boundary")
        {
            Destroy(gameObject);
        }
       // if (other.tag == "Boundary") Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        CheckCollision(other);
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        CheckCollision(other);
    }
}
