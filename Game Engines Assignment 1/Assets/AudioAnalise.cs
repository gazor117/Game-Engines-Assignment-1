using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent (typeof(AudioSource))]
public class AudioAnalise : MonoBehaviour
{
    private AudioSource audio;
    public static float[] samples = new float[512];
    
    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        GetSpoectrumAudioSource();
    }

    void GetSpoectrumAudioSource()
    {
        audio.GetSpectrumData(samples, 0, FFTWindow.Blackman);

    }
}
