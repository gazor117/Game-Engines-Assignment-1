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
            transform.localScale = new Vector3 ((AudioAnalise.bandBuffer[bandIndex] * scaleMultiplier) + startscale, (AudioAnalise.bandBuffer[bandIndex] * scaleMultiplier) + startscale, 
                (AudioAnalise.bandBuffer[bandIndex] * scaleMultiplier) + startscale);
        }
        if (useBuffer == false)
        {
            transform.localScale = new Vector3 ((AudioAnalise.freqBands[bandIndex] * scaleMultiplier) + startscale, (AudioAnalise.freqBands[bandIndex] * scaleMultiplier) + startscale, 
                (AudioAnalise.freqBands[bandIndex] * scaleMultiplier) + startscale);
        }
        
      
    }
}
