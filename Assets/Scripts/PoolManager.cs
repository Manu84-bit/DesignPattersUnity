using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    private EnemyPool _pool; 
    // Start is called before the first frame update
    void Start()
    {
        _pool = gameObject.AddComponent<EnemyPool>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnGUI()
    {
        if(GUILayout.Button("Spawn enemies"))
        {
            _pool.Spawn();
        }
    }
}
