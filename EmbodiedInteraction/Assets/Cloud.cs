using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud : MonoBehaviour
{
    public Transform smogParticle;

    public float heightStep;
    public float height = 0.5f;
    public float radius;
    // Start is called before the first frame update
    void Start()
    {
        GenerateSmog();
    }


    public Path myPath;


  public void GenerateSmog(){
      for(float i = 0; i< height ; i+=heightStep){
          for(int j = 0; j< 50 ; j++)
            Instantiate(smogParticle, transform.position + new Vector3(0,i,0) + (Vector3)Random.insideUnitSphere *radius, Quaternion.identity, transform);
      }
    }
/*
      public void GenerateSmog(){

      for(float i = 0; i< 1 ; i+=heightStep){
          for(int j = 0; j< 50 ; j++)
            Instantiate(smogParticle, transform.position + new Vector3(0,i,0) + (Vector3)Random.insideUnitSphere *radius, Quaternion.identity);
      }
    }
     */
    // Update is called once per frame
    void Update()
    {
        
    }
}
