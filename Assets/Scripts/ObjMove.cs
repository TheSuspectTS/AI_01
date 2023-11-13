using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjMove : MonoBehaviour
{
    public Transform target;

    public bool useX;
    public bool useY;
    public bool useZ;

    public Vector3 offset;

    private void Update() {
        
        Vector3 newPos = new Vector3();
        if(useX) newPos.x = target.position.x;
        if(useY) newPos.y = target.position.y;
        if(useZ) newPos.z = target.position.z;
        transform.position = newPos + offset;

    }
}
