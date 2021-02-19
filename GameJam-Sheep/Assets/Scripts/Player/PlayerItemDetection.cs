using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerItemDetection : MonoBehaviour
{
    //Ce script a pour objectif de gérer la detection des moutons

    private Transform _SelfTransform;
    private int _NumberOfCollectableObject = 0;

    [SerializeField] private float _GrowFactor = 1.5f;
    [SerializeField] private float _GrowSpeed = 2f;

    private Vector3 _InitScale;

    void Awake()
    {
        Initialisation();
    }
    private void Initialisation()
    {
        _SelfTransform = transform;
        _InitScale = _SelfTransform.localScale;
    }

    void Update()
    {
        Growing();
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Stickable"))
        {
            CatchNewElement(other.gameObject);
        }
    }

    private void CatchNewElement(GameObject newElement)
    {
        _NumberOfCollectableObject++;
        Destroy(newElement);
    }
    private void Growing()
    {
        Vector3 newScale = _InitScale + (new Vector3(_GrowFactor, _GrowFactor, _GrowFactor)* _NumberOfCollectableObject);
        _SelfTransform.localScale = Vector3.Lerp(_SelfTransform.localScale, newScale, _GrowSpeed*Time.deltaTime);
    }

    //RETURNS
    public int GetNumberOfCollectableObject()
    {
        return _NumberOfCollectableObject;
    }
}
