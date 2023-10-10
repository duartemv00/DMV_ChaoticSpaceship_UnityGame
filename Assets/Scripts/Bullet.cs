using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (Rigidbody2D))]
[RequireComponent (typeof (BoxCollider2D))]

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed = 24f;
    [SerializeField] private Rigidbody2D rb2D;
    public float bulletZ;

    void FixedUpdate(){
        //rb2D.velocity = new Vector2(speed * Mathf.Sin(bulletZ),speed * Mathf.Cos(bulletZ));
        rb2D.velocity = transform.rotation * new Vector3(0, speed, speed);
    }

    void OnTriggerEnter2D(Collider2D wall) {
        if (wall.gameObject.tag == "Wall" || wall.gameObject.tag == "Enemy") {
            //Destroy(gameObject);
            gameObject.SetActive(false);
        }
    }
}
