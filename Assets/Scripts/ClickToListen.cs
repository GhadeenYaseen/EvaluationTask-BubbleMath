using UnityEngine;

public class ClickToListen : MonoBehaviour
{
    public AudioSource numberToListenTo;
    private AudioSource[] allAudioSources;

    public void PlayClickedNumberSound()
    {
        StopAllAudio();
        numberToListenTo.Play();
    }

    void StopAllAudio() 
    {
	    allAudioSources = FindObjectsByType<AudioSource>(FindObjectsSortMode.None);
	    foreach( AudioSource audioS in allAudioSources)
        {
		    audioS.Stop();
	    }
}
}
