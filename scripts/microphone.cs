using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class microphone : MonoBehaviour
{
    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
      audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
      if (Input.GetKeyDown("space")) {
        if (!Microphone.IsRecording(""))
          audioSource.clip = Microphone.Start("", false, 15, 48000);
        else {
          Microphone.End("");
          audioSource.Play();
        }
      }
    }
}
