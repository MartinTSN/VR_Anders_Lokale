using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastFoward : MonoBehaviour
{
    void Start()
    {
        Debug.DrawRay(transform.position, transform.forward);
    }
}
