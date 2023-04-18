using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.Pool;

public class EnemyPool : MonoBehaviour
{
    private IObjectPool<Enemy> _pool;
    private int _maxPoolSize = 10;
    private int _stackDefaultCapacity = 10;

    public IObjectPool<Enemy> Pool
    {
        get
        {
            if (_pool == null)
            {
                _pool = new ObjectPool<Enemy>( 
                    CreateEnemy, 
                    ActionOnGet, 
                    ActionOnRelease,
                    ActionOnDestroy,
                    true,
                    _stackDefaultCapacity,
                    _maxPoolSize
                    );

            }
            return _pool;
        }
    }

    private Enemy CreateEnemy()
    {
        var gameObject = GameObject.CreatePrimitive(PrimitiveType.Cube);
        Enemy enemy = gameObject.AddComponent<Enemy>();
        gameObject.name = "Drone";
        enemy.Pool = Pool;
        return enemy;
    }

    private void ActionOnGet(Enemy e)
    {
        e.gameObject.SetActive(true);
    }

    private void ActionOnRelease(Enemy e)
    {
        e.gameObject.SetActive(false);
    }

    private void ActionOnDestroy(Enemy e)
    {
        Destroy(e.gameObject);
    }

    public void Spawn()
    {
        int amount = UnityEngine.Random.Range(1, _maxPoolSize);
        for(int i = 0; i < amount; i++)
        {
            var e = Pool.Get();
            
            e.transform.position = UnityEngine.Random.insideUnitSphere * 10;
            e.transform.position = new Vector3(e.transform.position.x, e.transform.position.y, 0);
            e.gameObject.SetActive(true);
        }
        
    }

}
