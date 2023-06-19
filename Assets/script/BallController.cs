using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BallController : MonoBehaviour, IBallFactory, IDamageable
{
    public BallType Type;
    public float BallSpeed;
    public float LargeBallRadius;
    public float MediumBallRadius;
    public float SmallBallRadius;
    public float LastBallRadius;
    private PoolingManager m_Pooler;

    /// <summary>
    /// Sets up the pooling system in this entity
    /// </summary>
    /// <param name="pooler"></param>
    public void PoolSetup(PoolingManager pooler)
    {
        this.m_Pooler = pooler;
    }
    
    /// <summary>
    /// cleans up the gameobject
    /// </summary>
    private void CleanUp()
    {
        SetRadius(0f);
        m_Pooler.DisposeEntity(this);
    }

    /// <summary>
    /// set the radius of the gameobject
    /// </summary>
    /// <param name="radius"></param>
    public void SetRadius(float radius)
    {
        radius *= 2;
        gameObject.transform.localScale = new Vector3(radius, radius, radius);
    }

    /// <summary>
    /// set the type of the gameobject
    /// </summary>
    /// <param name="type"></param>
    /// <exception cref="System.NotImplementedException"></exception>
    public void SetType(BallType type)
    {
        Type = type;
    }

    /// <summary>
    /// sets the speed of the gameobject
    /// </summary>
    /// <param name="speed"></param>
    /// <exception cref="System.NotImplementedException"></exception>
    public void SetSpeed(float speed)
    {
        BallSpeed = speed;
    }

    /// <summary>
    /// cleans up the gameobject, then tells the poolingmanager that this is the entity to return to the list
    /// </summary>
    public void Hitted()
    {
        Factory.CreateBall(Type - 1, gameObject.transform.position, BallSpeed);
        CleanUp();        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out IProjectileFactory projectile))
        {
            Hitted();
        }
    }
}
