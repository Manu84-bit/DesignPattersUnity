using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Enemy : MonoBehaviour
{
    public IObjectPool<Enemy> Pool { get; set; }

    [SerializeField]
    private float _currentHealth;

    [SerializeField]
    private float _maxHealth = 100.0f;

    [SerializeField]
    private float _timeToSelfDesctruct;
    // Start is called before the first frame update
    void Start()
    {
        _currentHealth = _maxHealth;
        _timeToSelfDesctruct = 3.0f;
    }

    // Update is called once per frame
    private void OnEnable()
    {
        AttackPlayer();
        StartCoroutine(SelfDestruct());
    }

    private void OnDisable()
    {
        ResetEnemy();
    }


    private void AttackPlayer()
    {
        Debug.Log("Attacking Player");
    }

    private IEnumerator SelfDestruct()
    {
        yield return new WaitForSecondsRealtime(_timeToSelfDesctruct);
        TakeDamage(_maxHealth);
    }

    private void TakeDamage(float damageAmount)
    {
        _currentHealth -= damageAmount;
        if(_currentHealth <= 0.0f)
        {
            Pool.Release(this);
        }
    }

    private void ResetEnemy()
    {
        _currentHealth = _maxHealth;
    }
}
