using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundTile : MonoBehaviour {

    public Mesh mesh;




    public void Initialize(Vector3 pos)
    {
        mesh = GroundTileManager.S.sharedMesh;
        GetComponent<MeshFilter>().mesh = mesh;
        transform.position = pos;
    }
}
