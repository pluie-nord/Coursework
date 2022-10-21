using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    private Rigidbody2D rb;
    private float moveH, moveV;
    [SerializeField] private float moveSpeed = 1.0f;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        Vector2 currentPos = rb.position;

        moveH = Input.GetAxis("Horizontal")*moveSpeed;
        moveV = Input.GetAxis("Vertical") * moveSpeed;
        rb.velocity = new Vector2(moveH, moveV);

        Vector2 direction = new Vector2(moveH, moveV);
        FindObjectOfType<PlayerAnimation>().SetDirection(direction);
    }

}
