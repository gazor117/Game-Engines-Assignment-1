using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateSphere : MonoBehaviour
{
    public float VerticalRotateSpeed;
    public float HorizontalRotateSpeed;

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.right * (VerticalRotateSpeed * Time.deltaTime));
        
        transform.Rotate(Vector3.up * (HorizontalRotateSpeed * Time.deltaTime));

    }
}
