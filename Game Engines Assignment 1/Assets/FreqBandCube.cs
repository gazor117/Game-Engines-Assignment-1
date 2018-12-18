using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreqBandCube : MonoBehaviour
{

    public int bandIndex;
    public float startscale;
    public float scaleMultiplier;
    public bool useBuffer = false;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (useBuffer == true)
        {
            transform.localScale = new Vector3 (transform.localScale.x, (AudioAnalise.bandBuffer[bandIndex] * scaleMultiplier) + startscale, transform.localScale.z);
        }
        if (useBuffer == false)
        {
            transform.localScale = new Vector3 (transform.localScale.x, (AudioAnalise.freqBands[bandIndex] * scaleMultiplier) + startscale, transform.localScale.z);
        }
        
      
    }
}
