using UnityEngine;

//for looping sounds
public class SecondarySoundManager : MonoBehaviour
{
    [HideInInspector] public static SecondarySoundManager secondarySoundManagerInstance{get; private set;}

    public AudioSource backgroundMusic;

    private void Awake() 
    {
        secondarySoundManagerInstance = this;
    }

    public void BackgroundSoundPlayer(bool state)
    {
        if (state)
        {
            backgroundMusic.Play();

        }
        else
        {
            backgroundMusic.Stop();
        }
    }
}
