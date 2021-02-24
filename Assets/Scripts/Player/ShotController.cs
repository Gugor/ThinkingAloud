using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotController : MonoBehaviour
{
    public float speed = 10.0f;
    public LayerMask roofMask;
    void FixedUpdate()
    {
        transform.Translate(new Vector3(0, speed * Time.deltaTime, 0));
        
    }
    private void Update()
    {
        RaycastHit hitInfo;
        if (Physics.SphereCast(transform.position,0.5f,new Vector3(transform.position.x,transform.position.y - 0.25f, transform.position.z), out hitInfo, 0.25f, roofMask)) 
        {
            Remove();
        }
    }

    public void Remove() 
    {
        Destroy(gameObject);
    }


}
