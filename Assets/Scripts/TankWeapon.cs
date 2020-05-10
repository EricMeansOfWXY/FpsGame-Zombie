using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankWeapon : MonoBehaviour
{
    // Start is called before the first frame update
    public SkinnedMeshRenderer meshRenderer;
    public MeshCollider collider;
    // Update is called once per frame
    void Update()
    {
        Mesh colliderMesh = new Mesh();
        meshRenderer.BakeMesh(colliderMesh); //更新mesh
        collider.sharedMesh = null;
        collider.sharedMesh = colliderMesh; //将新的mesh赋给meshcollider


    }
    private void OnTriggerStay(Collider other)
    {
        PlayerHealth player = other.GetComponent<PlayerHealth>();

        if (player != null)
        {
            player.TakeDamage(10);
        }
    }
}
