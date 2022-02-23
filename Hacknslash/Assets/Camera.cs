using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    [SerializeField] protected Transform target;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void FixedUpdate()
    {

        transform.position = new Vector3(target.position.x, target.position.y, transform.position.z);
        
    }

}
