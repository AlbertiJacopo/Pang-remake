using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour, IDamageable
{
    public void Hitted()
    {
        DestroyThis();
    }

    /// <summary>
    /// destroys this gameobject
    /// </summary>
    private void DestroyThis()
    {
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out IAbstractFactory abstractFactory))
        {
            Hitted();
        }
    }
}
