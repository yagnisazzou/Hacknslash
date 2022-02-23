using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    [SerializeField] protected Transform target;

    [SerializeField] protected float smoothSpeed = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void FixedUpdate()
    {

        Vector3 targetPosition = new Vector3(target.position.x, target.position.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, targetPosition, smoothSpeed);
        
    }

}
