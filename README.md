# Audio Visualizer Sphere
## Creating the Sphere
In this project I create a sphere made of cubes which react to audio. It creates the lines of cubes using a nested for loop where I also set the roatation and the position of the cubes. The initial colour of the cubes is also set here. It adds all these cubes to an ArrayList. The first loop creates one circle of cubes, then the rotation value is changed in the next loop so they are placed in a different position. We did the intial line of cubes in class and I iterated on this by creating multiple lines creating a sphere, reversing the direction of some lines and stacking multiple lines on top of each other to get the desired effect. The sphere can also rotate based on speeds set in the editor. The starting size, amount of circles of cubes, max scale can all be set in editor.


## Analyzing Audio
My AudioAnalise script gets the spectrum data of the audio, splitting it into 512 samples and adding it to the samples array. I also split these samples into a further 8 bands but mainly used the opriginal samples. Each cubes y scale was manipulated based on the corresponding sample e.g cube 124.yscale was changed using sample[124]. I learned how to get this spctrum data in class and through youtube tutorials. The sphere also increases in size depending which frequency band you select in editor.

## HSV Colour
The colour of the cubes are changed based on their y scale value in update. It only does this if the sample size is above a certain amount to optimise the project. The colour buffer and the colour multiplier can b

## Favourite Part
My favourite part would be how I reversed and stacked the lines of cubes to get more of an effect from the lower frequency samples as they were much more prevalent in the song I chose. Also having the colour change in update as the project would lag without the colourBuffer I added.



[![YouTube](https://img.youtube.com/vi/watch?v=uoO62u4m6JY&feature=youtu.be/0.jpg)](https://www.youtube.com/watch?v=uoO62u4m6JY&feature=youtu.be)





# Game Engines Assignment
## Concept
My current idea for the project is to create an audio visualizer in unity that will manipulate a sphere made of cubes. The main way it will do this is by getting data from the audio source using the AudioSource.GetSpectrumData method in unity. The shape, size and colour of the cubes will be changed based on the volume and frequency of the audio source. 
![](Images/CubeSphere.jpg)


## Research
I will to do alot more research into fast fourier transforms and windowing to know the best way to go about the spectrum analysis. I am currently thinking of using BlackmanHarris for this, but this could change after further research.


## References
- Unity API on Spectrum Data https://docs.unity3d.com/ScriptReference/AudioSource.GetSpectrumData.html
- Research on fast fourier transforms (FFTs) and windowing
http://www.ni.com/white-paper/4844/en/  
- Visualizer inspiration
https://videobolt.net/home/cat-music-visualizers
- Unity API on FFTs 
https://docs.unity3d.com/ScriptReference/FFTWindow.html
- Post about using above methods
https://answers.unity.com/questions/157940/getoutputdata-and-getspectrumdata-they-represent-t.html
