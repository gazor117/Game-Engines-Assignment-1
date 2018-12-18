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
    }

    void GetSpectrumAudioSource()
    {
        audio.GetSpectrumData(samples, 0, FFTWindow.Blackman);

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
