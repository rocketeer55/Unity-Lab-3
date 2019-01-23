using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour {

    public float upForce;

    private bool isDead;
    private Rigidbody2D rigidbody2D;
    private Animator animator;

    void Start() {
        upForce = 200f;
        isDead = false;

        rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update() {
        if (isDead == false) {
            if (Input.GetMouseButtonDown(0)) {
                rigidbody2D.velocity = Vector2.zero;
                rigidbody2D.AddForce(new Vector2(0, upForce));
                animator.SetTrigger("Flap");
            }
        }
    }

    void OnCollisionEnter2D() {
        rigidbody2D.velocity = Vector2.zero;
        isDead = true;
        animator.SetTrigger("Die");
        GameControl.instance.BirdDied();
    }
}
