using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Ce script a pour objectif de faire se déplacer le player

    private Rigidbody _Rb;
    [SerializeField] private float _Speed = 5f;

    void Awake()
    {
        Initialisation();
    }
    private void Initialisation()
    {
        _Rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        _Rb.AddForce(movement * _Speed);
    }
}
