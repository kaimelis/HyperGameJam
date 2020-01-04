using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[RequireComponent(typeof(Rigidbody))]
public class Player : MonoBehaviour
{
    private Rigidbody _rigidBody;

    public event Action _onPlayerDeath;

    [SerializeField]
    private float _jumpHeight = 3f;
    [SerializeField]
    private float _timeToReachJumpHeight = 0.3f;

    private float _bounceVelocity;

    private bool _isDisabled = false;

    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody>();

        FindObjectOfType<HelixGoal>()._onLevelFinished += Disable;
    }

    private void Start()
    {
        Physics.gravity = Vector3.up * -(2 * _jumpHeight) / Mathf.Pow(_timeToReachJumpHeight, 2);
        _bounceVelocity = Mathf.Abs(Physics.gravity.y) * _timeToReachJumpHeight;
    }

    private void OnCollisionEnter(Collision target)
    {
        if (_isDisabled == false)
            _rigidBody.velocity = Vector3.up * _bounceVelocity;
    }

    public void Destroy()
    {
        Disable();
        gameObject.SetActive(false);
        _onPlayerDeath?.Invoke();
    }

    private void Disable()
    {
        _rigidBody.velocity = Vector3.zero;
        _isDisabled = true;
    }

    private void OnDisable()
    {
        FindObjectOfType<HelixGoal>()._onLevelFinished -= Disable;
    }
}
