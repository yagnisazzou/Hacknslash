using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    
    public void TakeDamage (int damage)
    {
        Debug.Log("ow)");
        GetComponent<Animator>().Play("Take Damage");
    }

}
