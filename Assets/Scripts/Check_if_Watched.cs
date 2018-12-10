using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class Check_if_Watched : MonoBehaviour
{
    public Canvas Chat;

    void Update()
    {
        Ray raycast = new Ray(transform.position, transform.forward);
        Debug.DrawRay(raycast.origin, raycast.direction * 100);
        RaycastHit hit;

        if (Physics.Raycast(raycast, out hit))
        {
            if (hit.collider.gameObject.name == "Chat")
            {
                if (gameObject.GetComponentInParent<Hand>().gameObject.transform.rotation.y > 70)
                {
                    for (int i = 0; i < Chat.transform.childCount; i++)
                    {
                        Chat.transform.GetChild(i).gameObject.SetActive(true);
                    }
                }
            }
            else
            {
                for (int i = 0; i < Chat.transform.childCount; i++)
                {
                    Chat.transform.GetChild(i).gameObject.SetActive(false);
                }
            }
        }
    }
}
