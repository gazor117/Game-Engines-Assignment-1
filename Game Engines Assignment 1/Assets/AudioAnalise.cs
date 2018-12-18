using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent (typeof(AudioSource))]
public class AudioAnalise : MonoBehaviour
{
    private AudioSource audio;
    public static float[] samples = new float[512];
    public static float[] freqBands = new float[8];
    public static float[] bandBuffer = new float[8];
    private float[] bufferDecrease = new float[8];
    
    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        GetSpectrumAudioSource();
        MakeFrequencyBands();
        BandBuffer();
    }

    void GetSpectrumAudioSource()
    {
        audio.GetSpectrumData(samples, 0, FFTWindow.Blackman);

    }


    void BandBuffer()
    {
        for (int g = 0; g < 8; g++)                                            //Loops through frequency bands checking if they're above or below buffer
        {
            if (freqBands[g] > bandBuffer[g])
            {
                bandBuffer[g] = freqBands[g];
                bufferDecrease[g] = 0.005f;
            }
            
            if (freqBands[g] < bandBuffer[g])
            {
                bandBuffer[g] -= bufferDecrease[g];
                bufferDecrease[g] *= 1.2f;

            }
            
        }
        
    }
    
    
    
    void MakeFrequencyBands()
    {
        // 22050 / 512 = 43hrtz per sample
        /*
         *20 - 60
         *60 - 250
         *250 - 500
         *500- 2000
         *2000 - 4000
         *4000 - 6000
         * 6000 - 20000
         *
         *0 - 2 = 86 hertz
         *1 - 4 = 172 hertz    87 - 258
         *2 - 8 = 344 hertz    259 - 602
         *3 - 16 = 688
         *4
         *5
         *6
         *7
         * 
         */


        int count = 0;
        for (int i = 0; i < 8; i++)
        {
            int sampleCount = (int) Mathf.Pow(2, i) * 2;            //How many samples in each band
            float average = 0;                                        

            for (int j = 0; j < sampleCount; j++)                    //Splitting samples into different bands
            {
                average += samples[count] * (count + 1);
                count++;
            }

            average /= count;

            freqBands[i] = average * 10;

        }
    }
}
