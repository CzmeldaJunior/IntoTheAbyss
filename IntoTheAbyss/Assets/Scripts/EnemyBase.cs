using System.Runtime.CompilerServices;
using UnityEngine;

public class EnemyBase : MonoBehaviour, IDamageable
{
    [SerializeField]
    private EnemyData _enemyData;

    private float _hp;
    private float _movementSpeed;
    private float _attackDamage;

    float _currentHp;

    private void Awake()
    {
        _hp = _enemyData.hp;

        _movementSpeed = _enemyData.movementSpeed;

        _attackDamage = _enemyData.attackDamage;

        _currentHp = _hp;
    }

    public void TakeDamage(float damageToTake)
    {
        _currentHp -= damageToTake;

        if (_currentHp <= 0)
        {
            Die();
        }
    }

    protected virtual void Die()
    {
        Destroy(this.gameObject);
    }
}
