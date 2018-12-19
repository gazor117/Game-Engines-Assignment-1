using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCubes : MonoBehaviour
{
    public GameObject sampleCubePrefab;
    public float circleAmount = 20f;
    //private GameObject[] sampleCubes = new GameObject[5120];
    List<GameObject> sampleCubes = new List<GameObject>();
    public float maxScale;
    public float startingCubeWidth;
    public float startingCubeHeight;
    public float startingCubeDepth;

    
    
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
                xRotationAngleIncrement = (360f / (circleAmount / 2));
                
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
                    Vector3 localScale = sampleCubes[i + (h * 512)].transform.localScale;
                    //localScale.y = Mathf.Lerp(localScale.y, 1 + (AudioAnalise.samples[i] * maxScale),Time.deltaTime * 3.0f);
                    localScale = new Vector3(0.5f,  Mathf.Lerp(localScale.y, 2 + (AudioAnalise.samples[i] * maxScale) ,Time.deltaTime * 3.0f), 1);
                    sampleCubes[i + (h * 512)].transform.localScale = localScale;

                }
    
            }
        }
}
}
