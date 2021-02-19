using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerItemDetection : MonoBehaviour
{
    //Ce script a pour objectif de gérer la detection des moutons

    private Transform _SelfTransform;

    void Awake()
    {
        Initialisation();
    }
    private void Initialisation()
    {
        _SelfTransform = transform;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Stickable"))
        {
            CatchNewElement(other.gameObject);
        }
    }

    private void CatchNewElement(GameObject newElement)
    {
        newElement.transform.parent = _SelfTransform;
    }
}
