using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    private Rigidbody2D m_RigidBody;
    private ShootingComponent m_Shooting;
    private HealthComponent m_Health;
    private MovementComponent m_Movement;

    // Start is called before the first frame update
    void Start()
    {
        m_RigidBody = GetComponent<Rigidbody2D>();
        m_Health = GetComponent<HealthComponent>();
        m_Movement = GetComponent<MovementComponent>();
        m_Shooting = GetComponent<ShootingComponent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            m_Movement.Move(m_RigidBody, Vector2.left);
        }
        if (Input.GetKey(KeyCode.D))
        {
            m_Movement.Move(m_RigidBody, Vector2.right);
        }
    }
}
