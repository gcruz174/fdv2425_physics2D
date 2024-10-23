using System;
using UnityEngine;

public class DragBox : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 5f;
    
    private Rigidbody2D _rb2d;
    
    private void Start()
    {
        _rb2d = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        _rb2d.velocity = Vector2.right * moveSpeed;
    }
}
