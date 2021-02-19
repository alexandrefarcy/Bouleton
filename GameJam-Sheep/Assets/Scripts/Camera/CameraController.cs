using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    //Ce script a pour objectif de gérer la caméra du jeu

    private Camera _Cam;
    private Transform _SelfTransform;
    public Transform _Target;

    private Vector3 _Offset;
    [SerializeField] private float _Interpolation = 0.7f;

    private Vector3 _PreviousPosition;
    [SerializeField] private float _OrbitalRotationSpeed = 5f;

    void Awake()
    {
        Initialisation();
    }
    private void Initialisation()
    {
        _Cam = Camera.main;
        _SelfTransform = transform;
        _Offset = _SelfTransform.position - _Target.position;
    }

    void FixedUpdate()
    {
        OrbitalRotation();
        FollowTarget();
    }
    private void FollowTarget()
    {
        _SelfTransform.position = Vector3.Lerp(_SelfTransform.position,
            _Target.position + _Offset,
            _Interpolation);
    }
    private void OrbitalRotation()
    {
        _SelfTransform.LookAt(_Target);

        if (Input.GetMouseButtonDown(0))
        {
            _PreviousPosition = _Cam.ScreenToViewportPoint(Input.mousePosition);
        }

        if (Input.GetMouseButton(0))
        {
            Vector3 direction = _PreviousPosition - _Cam.ScreenToViewportPoint(Input.mousePosition);

            _SelfTransform.RotateAround(_Target.position, direction, _OrbitalRotationSpeed);

            _PreviousPosition = _Cam.ScreenToViewportPoint(Input.mousePosition);
        }
    }
}
