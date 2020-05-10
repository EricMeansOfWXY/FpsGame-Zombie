using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserSwitch : MonoBehaviour
{
    public GameObject laserDoor;
    public GameObject _key;
    public int i;
    bool[] keycard = { false, false };
    public GameObject keymessage;
    void Start()
    {
        keymessage.SetActive(false);

    }
    IEnumerator Delay()
    {
        yield return new WaitForSeconds(3.0f);
        keymessage.SetActive(false);
    }
    private void OnTriggerStay(Collider other)
    {
        PlayerHealth player = other.GetComponent<PlayerHealth>();
        keycard[0] = player.key01;
        keycard[1] = player.key02;
     

        if (player != null)
        {
            
            if (keycard[i] == true)
            {
                laserDoor.SetActive(false);
                _key.SetActive(false);

            }
            else
            {
                keymessage.SetActive(true);
                StartCoroutine(Delay());
            }
        }
    }
}
