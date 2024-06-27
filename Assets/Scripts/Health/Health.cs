using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Runtime.InteropServices;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int startlife = 10;
    public bool destroyOnKill = false;
    public float delayToKill = 0f;
    private int _currentLife;
    private bool _isDead = false;

    private void Init()
    {
        _isDead = false;
        _currentLife = startlife;
    }
    private void Awake()
    {
        Init();
    }

    public void Damage(int damage)
    {
        if (_isDead) return;
        _currentLife -= damage;

        if (_currentLife <= 0)
        {
            Kill();
        }
    }
    private void Kill()
    {
        _isDead = true;
        if (destroyOnKill) Destroy(gameObject,delayToKill);
    }
}
