using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementComponent : MonoBehaviour
{
    [SerializeField] private float m_PlayerSpeed;

    public void Move(Rigidbody2D rb, Vector2 direction)
    {
        rb.AddForce(direction * m_PlayerSpeed, ForceMode2D.Force);
    }
}
