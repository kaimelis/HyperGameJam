using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamereFollow : MonoBehaviour
{
    private Transform _playerTransform;
    private Transform _cameraTransform;

    [SerializeField]
    private float _cameraOffsetY;

    private float _scrollPositionY;

    private void Awake()
    {
        _playerTransform = FindObjectOfType<Player>().transform;
        _cameraTransform = GetComponent<Transform>();
    }

    private void Start()
    {
        _scrollPositionY = _playerTransform.localPosition.y;
    }

    private void LateUpdate()
    {
        if(_playerTransform != null)
        {
            if (_playerTransform.localPosition.y < _scrollPositionY)
            {
                _scrollPositionY = _playerTransform.localPosition.y;
                _cameraTransform.localPosition = new Vector3(_cameraTransform.localPosition.x, _playerTransform.localPosition.y + _cameraOffsetY, _cameraTransform.localPosition.z);
            }
        }
    }
}
