using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class enables button sounds.
/// </summary>

public class btnFX : MonoBehaviour {

    private static Audiohandler instance;
    public AudioSource myFx;
    public AudioClip hoverFx;
    public AudioClip clickFx;

    public void HoverSound()
    {
        myFx.PlayOneShot(hoverFx);
    }


    public void ClickSound()
    {
        
        myFx.PlayOneShot(clickFx);
        

    }
}
