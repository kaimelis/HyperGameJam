using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelixTower : MonoBehaviour
{
    private Transform _transform;
    private Player _player;
    private HelixGoal _helixGoal;

    [SerializeField]
    private KeyCode _right;
    [SerializeField]
    private KeyCode _left;

    [SerializeField]
    private float _rotationSpeed = 60;
    [SerializeField]
    private float _rotationAcceleration = 0.1f;

    private float _velocityY;
    private float _smoothVelocityY;

    private bool _isDisabled = false;

    private void Awake()
    {
        _transform = GetComponent<Transform>();

        _player = FindObjectOfType<Player>();

        if(_player != null)
            _player._onPlayerDeath += DisableHelix;

        _helixGoal = FindObjectOfType<HelixGoal>();

        if(_helixGoal != null)
            _helixGoal._onLevelFinished += DisableHelix;
    }

    private void Update()
    {
        if (_isDisabled == true)
            return;

        float horizontalAxis = GetHorizontalAxis();

        float targetRotationVelocityY = horizontalAxis * (_rotationSpeed * Time.deltaTime);
        _velocityY = Mathf.SmoothDamp(_velocityY, targetRotationVelocityY, ref _smoothVelocityY, _rotationAcceleration);

        float targetRotationY = _transform.localEulerAngles.y + _velocityY;

        _transform.localEulerAngles = new Vector3(_transform.localEulerAngles.x, targetRotationY, _transform.localEulerAngles.z);
    }

    private float GetHorizontalAxis()
    {
        float horizontalAxis = 0;

        if (Input.GetKey(_right))
            horizontalAxis += 1;
        if (Input.GetKey(_left))
            horizontalAxis += -1;

        return horizontalAxis;
    }

    private void DisableHelix()
    {
        _isDisabled = true;
    }

    private void OnDisable()
    {
        if (_player != null)
            _player._onPlayerDeath -= DisableHelix;

        if(_helixGoal != null)
            _helixGoal._onLevelFinished -= DisableHelix;
    }
}
