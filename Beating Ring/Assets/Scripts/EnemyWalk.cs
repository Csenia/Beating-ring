using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWalk : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private float _speed = 3f;
    [SerializeField] private int _healthEnemy = 50;
    [SerializeField] private float _detectionRange = 5f;
    [SerializeField] private List<RuntimeAnimatorController> _controls = new List<RuntimeAnimatorController>();
    private Animator _anim;
    private bool _isCillisin = false;
    private bool _isCloseToPlayer = false;

    void Start()
    {
        _anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (_player != null)
        {
            float distanceToPlayer = Vector3.Distance(transform.position, _player.position);

            if (distanceToPlayer >= _detectionRange)
            {
                Vector3 direction = _player.position - transform.position;
                direction.Normalize();

                transform.position += direction * _speed * Time.deltaTime;

                _isCloseToPlayer = false;
            }
            else
            {
                _isCloseToPlayer = true;
            }

            if (_isCloseToPlayer)
            {
                _anim.runtimeAnimatorController = _controls[1];
            }
            else
            {
                _anim.runtimeAnimatorController = _controls[0];
            }
        }
        print(_healthEnemy);
        if(_isCillisin && Input.GetKeyDown(KeyCode.E))
        {
            GetDamage(25);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _isCillisin = true;
        }
        else
        {
            _isCillisin = false;
        }
    }

    private void GetDamage(int damage)
    {
        _healthEnemy -= damage;
        if (_healthEnemy <= 0)
        {
           Destroy(gameObject);

        }
    }
}
