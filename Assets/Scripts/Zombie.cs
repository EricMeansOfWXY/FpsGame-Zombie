using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{
    public Vector3 vector = Vector3.forward;
    public float speed;
    public Transform target;
    // Start is called before the first frame update
    private IEnumerator Start()
    {
        target = GameObject.Find("target").transform;
        yield return new WaitForSeconds(3.0f);

    }

    // Update is called once per frame
    void Update()
    {
        //transform.Translate(vector * Time.deltaTime, Space.World);
        transform.LookAt(target.position);
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }
}
