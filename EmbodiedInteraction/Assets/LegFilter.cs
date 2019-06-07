using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LegFilter : MonoBehaviour
{
    public Path myPath;
    // Start is called before the first frame update
    public Vector3 velocity;
    public float magnitude;
    Vector3 prevPos;
    Vector3 curPos;
    void Start()
    {
        prevPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        curPos =   transform.position;

        //prevPos = curPos;
        velocity = (curPos - prevPos)/ Time.deltaTime;
        magnitude = velocity.magnitude;
        prevPos = curPos;
        //prevPos = transform.position;
    }

    void OnTriggerEnter(Collider other){
        if(magnitude < 0.08 && magnitude > 0.001 && Mathf.Sign(velocity.y) != -1)


            if(other.transform.tag =="SmogCube"){

                Path.PathNode node = myPath.GetClosestPointOnPath(curPos);
                
                other.transform.position += node.dir * 4;
                if(node.index >= myPath.positions.Count - myPath.subdiv/2){
                    other.transform.parent = null;
                    other.transform.GetComponent<Rigidbody>().isKinematic = false;
                }
           
        }
    }

    void LateUpdate(){
       
    }
}
