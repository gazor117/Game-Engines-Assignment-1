using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreqBandCube : MonoBehaviour
{

    public int bandIndex;
    public float startscale;
    public float scaleMultiplier;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale = new Vector3 (transform.localScale.x, (AudioAnalise.freqBands[bandIndex] * scaleMultiplier) + startscale, transform.localScale.z);
    }
}
