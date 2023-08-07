using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMovement : MonoBehaviour
{
    [SerializeField]
    private float _speed;

    private Rigidbody2D _rigibody;
    private playerAwareness _playerAwareness;
    private Vector2 _targetDirection;
    private float _rotationSpeed = 100;
    private void Awake()
    {
        _rigibody = GetComponent<Rigidbody2D>();
        _playerAwareness = GetComponent<playerAwareness>();

    }
    

    // Update is called once per frame
    private void FixedUpdate()
    {
        UpdateTargetDirection();
        rotateTowardsTarget();
        SetVelocity();
    }
    private void UpdateTargetDirection()
    {
        if (_playerAwareness.AwareOfPlayer)
        {
            _targetDirection = _playerAwareness.DirectionToPlayer;
        }
        else
        {
            _targetDirection = Vector2.zero;
        }
    }
    private void rotateTowardsTarget()
    {
        if (_targetDirection == Vector2.zero)
        {
            return;
        }

        Quaternion targetrotation = Quaternion.LookRotation(transform.forward, _targetDirection);
        Quaternion rotation = Quaternion.RotateTowards(transform.rotation, targetrotation, _rotationSpeed * Time.deltaTime);

        _rigibody.SetRotation(rotation);
    }
    private void SetVelocity()
    {
        if(_targetDirection == Vector2.zero)
        {
            _rigibody.velocity = Vector2.zero;
        }
        else
        {
            _rigibody.velocity = transform.up * _speed;
        }
    }
}
