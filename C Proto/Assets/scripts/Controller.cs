using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    private Rigidbody2D rb;
    private float moveV, moveH;
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

        Vector2 inputVector = new Vector2(moveH, moveV);

        inputVector = Vector2.ClampMagnitude(inputVector, 1);
        Vector2 movement = inputVector * moveSpeed;

        Vector2 newPos = currentPos + movement * Time.fixedDeltaTime;
        rb.MovePosition(newPos);
    }
}
