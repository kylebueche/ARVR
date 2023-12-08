using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class PlaySound : MonoBehaviour
{
    public AudioSource audioName;

    public void PlayAudio()
    {
        audioName.Play();
    }
}

