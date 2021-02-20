using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Ce script a pour objectif de faire se déplacer le player

    private Rigidbody _Rb;
    [SerializeField] private float _Speed = 5f;
    [SerializeField] private float _CurrentSpeed;

    private bool boost;

    void Awake()
    {
        Initialisation();
    }
    private void Initialisation()
    {
        _Rb = GetComponent<Rigidbody>();
        _CurrentSpeed = _Speed;
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        _Rb.AddForce(movement * _CurrentSpeed);       
    }
    #region GET
    //RETURN
    public float GetCurrentSpeed()
    {
        return _CurrentSpeed;
    }
    public float GetInitSpeed()
    {
        return _Speed;
    }
    #endregion

    #region SET
    //SET
    public void SetNewSpeed(float newSpeed)
    {
        _CurrentSpeed = newSpeed;
    }
    public void ResetSpeed()
    {
        _CurrentSpeed = _Speed;
    }
    #endregion

    #region SpeedBoost
    public void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "speedBoost")
        {
            _CurrentSpeed = 25;
        }
    }
    #endregion

    #region Default Speed
    public void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag =="speedBoost")
        {
            _CurrentSpeed = _Speed;
        }
    }

    #endregion


}
