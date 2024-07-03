using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadbobController : MonoBehaviour
{
    [Header("Configuration")]
    [SerializeField] private bool _enable = true;

    [SerializeField] private float _amplitude = 0.015f;
    [SerializeField] private float _frequency = 10.0f;

    [Header("Holders")]
    [SerializeField] private Transform _camera = null;
    [SerializeField] private Transform _cameraHolder = null;
    [SerializeField] private Transform _orientation = null; // Reference to the Orientation object

    private float _toggleSpeed = 2.0f;
    private Vector3 _startPos;
    private PlayerMovement _controller;

    private void Awake()
    {
        _controller = GetComponent<PlayerMovement>();
        _startPos = _camera.localPosition;
    }

    void Update()
    {
        if (!_enable) return;
        CheckMotion();
        ResetPosition();
        _camera.LookAt(FocusTarget());
    }

    private Vector3 FootStepMotion()
    {
        Vector3 pos = Vector3.zero;
        pos.y += Mathf.Sin(Time.time * _frequency) * _amplitude;
        pos.x += Mathf.Cos(Time.time * _frequency / 2) * _amplitude * 2;
        return pos;
    }

    private void CheckMotion()
    {
        float speed = new Vector3(_controller.GetVelocity().x, 0, _controller.GetVelocity().z).magnitude;
        if (speed < _toggleSpeed) return;
        if (!_controller.IsGrounded()) return;

        PlayMotion(FootStepMotion());
    }

    private void PlayMotion(Vector3 motion)
    {
        // Transform motion to be relative to the player's orientation
        Vector3 localMotion = _orientation.TransformDirection(motion);
        _camera.localPosition += localMotion;
    }

    private Vector3 FocusTarget()
    {
        Vector3 pos = new Vector3(transform.position.x, transform.position.y + _cameraHolder.localPosition.y, transform.position.z);
        pos += _cameraHolder.forward * 15.0f;
        return pos;
    }

    private void ResetPosition()
    {
        if (_camera.localPosition == _startPos) return;
        _camera.localPosition = Vector3.Lerp(_camera.localPosition, _startPos, 1 * Time.deltaTime);
    }
}
