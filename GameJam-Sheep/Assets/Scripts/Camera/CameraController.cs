using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    //Ce script a pour objectif de gérer la caméra du jeu

    private Transform _SelfTransform;
    public Transform _Target;

    private Vector3 _Offset;
    [SerializeField] private float _Interpolation = 0.7f;

    [SerializeField] private float _OrbitalRotationSpeed = 5f;

    void Awake()
    {
        Initialisation();
    }
    private void Initialisation()
    {
        _SelfTransform = transform;
        _Offset = _SelfTransform.position - _Target.position;
    }

    void FixedUpdate()
    {
        FollowTarget();
        OrbitalRotation();
    }
    private void FollowTarget()
    {
        _SelfTransform.position = Vector3.Lerp(_SelfTransform.position,
            _Target.position + _Offset,
            _Interpolation);
    }
    private void OrbitalRotation()
    {
        float horizontalRotation = Input.GetAxis("HorizontalR");
        float verticalRotation = Input.GetAxis("VerticalR");
        Vector3 axisRotation = new Vector3(verticalRotation, horizontalRotation, 0);

        Vector3 targetPoint = _Target.position;

        float step = _OrbitalRotationSpeed * Time.fixedDeltaTime;
        _SelfTransform.RotateAround(targetPoint, axisRotation, step);
    }
}
