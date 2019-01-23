using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingObject : MonoBehaviour {

    private Rigidbody2D rigidbody2D;

    void Start() {
        rigidbody2D = GetComponent<Rigidbody2D>();
        rigidbody2D.velocity = new Vector2(GameControl.instance.scrollSpeed, 0);
    }

    void Update() {
        if (GameControl.instance.gameOver == true) {
            rigidbody2D.velocity = Vector2.zero;
        }
    }
}
