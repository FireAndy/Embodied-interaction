using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path : MonoBehaviour
{
    // Start is called before the first frame update
    public List<Transform> nodes;
    public List<Vector3> positions;
    public int subdiv = 10;

    public Transform followObject;
    public Transform hand;
    void Start()
    {
        positions = new List<Vector3>();
        if(nodes.Count > 0){
            
            for(int i = 0 ; i < nodes.Count - 1; i++){
                Debug.DrawLine(nodes[i].position, nodes[i+1].position, Color.blue);
                Vector3 dir = (nodes[i+1].position - nodes[i].position)/subdiv;
                Vector3 temp = nodes[i].position;

                for(int j = 0 ; j < subdiv; j++){
                    positions.Add(temp + dir);

                    temp = temp + dir;
                }

            }
        }

    }

    public struct PathNode{
        public Vector3 prev;
        public Vector3 cur;
        public Vector3 next;
        public Vector3 dir;
    }

    // Update is called once per frame
    void Update()
    {
        if(positions.Count > 0){
            for(int i = 0 ; i < positions.Count - 1; i++){
                Debug.DrawLine(positions[i] + Vector3.right, positions[i+1]+ Vector3.right, Color.red);
            }
        }

        if(hand != null && followObject != null){
            PathNode node = GetClosestPointOnPath(hand.transform.position);
            followObject.transform.position = node.cur;
            followObject.LookAt(node.next);
        }
    }

    public PathNode GetClosestPointOnPath(Vector3 pos){
        float dist = 1000;
        PathNode result = new PathNode();
        for(int i = 0 ; i < positions.Count; i++){

            float temp = Vector3.Distance(pos, positions[i]);

            if(temp < dist){
                dist = temp;
                result = new PathNode{cur = positions[i], dir = positions[i + 1]- positions[i], next =  positions[i + 1]};
            }
        }
        return result;
    }
}
