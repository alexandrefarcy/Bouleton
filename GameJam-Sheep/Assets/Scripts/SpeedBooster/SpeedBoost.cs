using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBoost : MonoBehaviour
{
    public PlayerController speedControl;
    private float defaultSpeed;
    public float boostSpeed =12;

    private void Start()
    {
        speedControl = gameObject.GetComponent<PlayerController>();
      //  defaultSpeed = speedControl.
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag =="speedBoost")
        {

        }
    }
}
