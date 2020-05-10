using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyCard : MonoBehaviour
{
    void FixedUpdate()
    {
        
        transform.Rotate(new Vector3(0, 1, 0));

    }
    private void OnTriggerStay(Collider other)
    {
        PlayerHealth player = other.GetComponent<PlayerHealth>();

        if (player != null)
        {
            if (this.gameObject.name == "KeyCard01")
            {
                transform.gameObject.SetActive(false);
                player.key01 = true;
                player._key01.gameObject.SetActive(true);
            }
            if (this.gameObject.name == "KeyCard02")
            {
                transform.gameObject.SetActive(false);
                player.key02 = true;
                player._key02.gameObject.SetActive(true);
            }
        }
    }
}
