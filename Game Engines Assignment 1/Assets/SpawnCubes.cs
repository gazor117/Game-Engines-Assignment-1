using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCubes : MonoBehaviour
{
    public GameObject sampleCubePrefab;
    private GameObject[] sampleCubes = new GameObject[512];
    public float maxScale;
    
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 512; i++)
        {
            GameObject instanceSampleCube = (GameObject) Instantiate(sampleCubePrefab);              //Instantiate Cube
            instanceSampleCube.transform.position = this.transform.position;                        //Set Intial position
            instanceSampleCube.transform.parent = this.transform;                                    //Make cube a child of gameobject this script is attached to
            instanceSampleCube.name = "SampleCube" + i;                                               //Change Name of each cube
            float rotationAngleIncrement = 360f / 512f;                                                //Amount each cube has to rotate
            this.transform.eulerAngles = new Vector3(0, -rotationAngleIncrement * i, 0 );
            instanceSampleCube.transform.position = Vector3.forward * 100;                                //Set position of objects
            sampleCubes[i] = instanceSampleCube;                                                        //Link array to instance cubes

        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < 512; i++)
        {
            if (sampleCubes != null)
            {
                sampleCubes[i].transform.localScale = new Vector3(2, (AudioAnalise.samples[i] * maxScale) + 2, 2);
                
            }
            
        }
    }
}
