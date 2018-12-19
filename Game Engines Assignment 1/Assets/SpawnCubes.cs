using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCubes : MonoBehaviour
{
    public GameObject sampleCubePrefab;
    private float circleAmount = 20f;
    //private GameObject[] sampleCubes = new GameObject[5120];
    List<GameObject> sampleCubes = new List<GameObject>();
    public float maxScale;
    
    
    // Start is called before the first frame update
    void Start()
    {
        for (int h = 0; h < circleAmount; h++)
        {
            
            for (int i = 0; i < 512; i++)
            {
                float yRotationAngleIncrement;
                float xRotationAngleIncrement;
                
                if (h < circleAmount/2)
                {
                     yRotationAngleIncrement = (360f / 512f); //Amount each cube has to rotate around y axis
                }
                else
                {
                     yRotationAngleIncrement = -360f / 512f; //Amount each cube has to rotate around y axis
                }
                xRotationAngleIncrement = (360f / 10);
                
                /*if (yRotationAngleIncrement > 360)
                {
                    yRotationAngleIncrement = 0;
                }*/

                GameObject instanceSampleCube = (GameObject) Instantiate(sampleCubePrefab); //Instantiate Cube
                instanceSampleCube.transform.position = this.transform.position; //Set Intial position
                instanceSampleCube.transform.parent = this.transform; //Make cube a child of gameobject this script is attached to
                instanceSampleCube.name = "SampleCube" + (i + (h * 512)); //Change Name of each cube
               
                
                this.transform.eulerAngles = new Vector3(xRotationAngleIncrement * h, -yRotationAngleIncrement * i, 0);
                instanceSampleCube.transform.position = Vector3.forward * 100; //Set position of objects
                //sampleCubes[i] = instanceSampleCube; //Link array to instance cubes
                sampleCubes.Add(instanceSampleCube);

            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int h = 0; h < circleAmount; h++)
        {
            for (int i = 0; i < 512; i++)
            {
    
                if (sampleCubes != null)
                {
                    sampleCubes[i + (h * 512)].transform.localScale = new Vector3(0.5f, (AudioAnalise.samples[i] * maxScale) + 2, 1);
    
                }
    
            }
        }
}
}
