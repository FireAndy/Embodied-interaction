using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LegFilter : MonoBehaviour
{
    public Path myPath;
    // Start is called before the first frame update
    public Vector3 velocity;
    Vector3 prevPos;
    Vector3 curPos;
    void Start()
    {
        prevPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        curPos = transform.position;

        prevPos = curPos;
        velocity = (curPos - prevPos)/ Time.deltaTime;
        prevPos = transform.position;
    }

    void OnTriggerEnter(Collider other){
        if(other.transform.tag =="SmogCube"){
            other.transform.parent = null;
            other.transform.GetComponent<Rigidbody>().isKinematic = false;
        }
    }

    void LateUpdate(){
       
    }
}
