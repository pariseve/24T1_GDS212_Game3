using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("----- Audio Source -----")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;
    [SerializeField] AudioSource yippeeSource;

    [Header("----- Audio Clip -----")]
    public AudioClip background;
    public AudioClip dropSound;
    public AudioClip yippee;

    private void Start()
    {
        DontDestroyOnLoad(this.gameObject);

        musicSource.clip = background;
        musicSource.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }

    public void DropSFX()
    {
        Debug.Log("Playing drop sound");
        if (dropSound != null)
        {
            SFXSource.PlayOneShot(dropSound);
        }
        else
        {
            Debug.LogWarning("Drop sound is null.");
        }
    }

    public void YippeeSFX()
    {
        yippeeSource.PlayOneShot(yippee);
    }

}