using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAudioOnFall : MonoBehaviour
{
    AudioSource source;

    public void Start()
    {
        source = FindObjectOfType<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        source.Play();
    }
}
