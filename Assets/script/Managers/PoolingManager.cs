using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PoolingManager : MonoBehaviour
{
    [Min(1)]
    [SerializeField] private uint m_InitialSpawnNumber;
    [SerializeField] private BallController m_BallToSpawn;
    private List<BallController> m_BallsList = new List<BallController>();

    protected virtual void Start()
    {
        InitialSpawnEntities();
    }

    /// <summary>
    /// Spawn the initial entities
    /// </summary>
    private void InitialSpawnEntities()
    {
        for (int i = 0; i < m_InitialSpawnNumber; i++)
        {
            var entity = Instantiate(m_BallToSpawn, transform);
            entity.PoolSetup(this);
            entity.gameObject.SetActive(false);
        }
    }

    /// <summary>
    /// instanciate the next ball in list if there's any, or else it create another one
    /// </summary>
    /// <returns></returns>
    public BallController GetEntity()
    {
        BallController entityPassed;
        if (m_BallsList.Count > 0) entityPassed = m_BallsList.First(x => !x.gameObject.activeInHierarchy);
        else entityPassed = GetNewEntity();
        m_BallsList.Remove(entityPassed);
        return entityPassed;
    }

    /// <summary>
    /// used to create other entities if there aren't any available
    /// </summary>
    /// <returns></returns>
    private BallController GetNewEntity()
    {
        var entity = Instantiate(m_BallToSpawn, transform);
        entity.PoolSetup(this);
        m_BallsList.Add(entity);
        return entity;
    }
    
    /// <summary>
    /// return the entity to the list and deactivate it
    /// </summary>
    /// <param name="entity"></param>
    public void DisposeEntity(BallController entity)
    {
        entity.transform.SetParent(transform);
        entity.gameObject.SetActive(false);
        if (!m_BallsList.Contains(entity)) m_BallsList.Add(entity);
    }
}