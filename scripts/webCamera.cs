using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class webCamera : MonoBehaviour
{
    Renderer renderer;
    WebCamTexture webcamTexture;
    Texture defaultTexture;
    // Start is called before the first frame update
    void Start()
    {
      renderer = GetComponent<Renderer>();
      defaultTexture = renderer.material.mainTexture;
      webcamTexture = new WebCamTexture("HD WebCam");
    }

    // Update is called once per frame
    void Update()
    {
      if (Input.GetKey("v")) {
        if (!webcamTexture.isPlaying) {
          renderer.material.mainTexture = webcamTexture;
          webcamTexture.Play();
        } else {
          webcamTexture.Stop();
          renderer.material.mainTexture = defaultTexture;
      }
    }
  }

};
