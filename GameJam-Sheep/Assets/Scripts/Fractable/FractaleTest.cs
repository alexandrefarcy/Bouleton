using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FractaleTest : MonoBehaviour
{

    private bool fractured_condition;

    public GameObject fractured;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (fractured_condition == true)
            BreakTheThing();
    }


    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag =="Player")
        {
            fractured_condition = true;
        }
    }
    public void BreakTheThing()
    {
        Instantiate(fractured, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
