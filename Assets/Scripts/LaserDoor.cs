using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserDoor : MonoBehaviour
{
    void Update()
    {
        Ray ray = new Ray(transform.position,-transform.right);
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
           
            PlayerHealth player = hit.collider.GetComponent<PlayerHealth>();
            Debug.DrawLine(ray.origin, hit.point, Color.red);
            if (player != null)
            {
                player.Dead();
            }
           
           
        }

    }
}
