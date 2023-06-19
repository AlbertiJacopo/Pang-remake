using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAbstractFactory
{
    /// <summary>
    /// set the speed of the object
    /// </summary>
    /// <param name="speed"></param>
    public void SetSpeed(float speed);

}

public interface IDamageable
{
    /// <summary>
    /// called when an object is hitted by something
    /// </summary>
    public void Hitted();
}

public interface IBallFactory : IAbstractFactory
{
    /// <summary>
    /// set the radius of the ball
    /// </summary>
    /// <param name="radius"></param>
    public void SetRadius(float radius);
    /// <summary>
    /// set which type is the ball
    /// </summary>
    /// <param name="type"></param>
    public void SetType(BallType type);
}

public interface IProjectileFactory : IAbstractFactory
{
    /// <summary>
    /// set which type is the projectile
    /// </summary>
    /// <param name="type"></param>
    public void SetType(ProjectileType type);
}