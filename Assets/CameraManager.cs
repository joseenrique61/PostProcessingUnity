using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public List<Camera> cameras;
    public List<AudioClip> audioClips;

    public AudioSource audioSource;
    public AudioSource cameraChangeAudioSource;

    private int currentCamera = 0;

    // Start is called before the first frame update
    void Start()
    {
        cameras[currentCamera].gameObject.SetActive(true);
        audioSource.clip = audioClips[currentCamera];
        Debug.Log($"Played audio {currentCamera}");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("j"))
        {
            cameras[currentCamera].gameObject.SetActive(false);
            currentCamera -= 1;
            if (currentCamera < 0)
            {
                currentCamera = cameras.Count - 1;
            }
            cameras[currentCamera].gameObject.SetActive(true);
            audioSource.clip = audioClips[currentCamera];
            cameraChangeAudioSource.Play();
            Debug.Log($"Played audio {audioClips[currentCamera]}");
            Debug.Log($"Changed camera. Played audio {cameraChangeAudioSource.clip.name}");
        }
        else if (Input.GetKeyDown("k"))
        {
            cameras[currentCamera].gameObject.SetActive(false);
            currentCamera = (currentCamera + 1) % cameras.Count;
            cameras[currentCamera].gameObject.SetActive(true);
            audioSource.clip = audioClips[currentCamera];
            cameraChangeAudioSource.Play();
            Debug.Log($"Played audio {audioClips[currentCamera]}");
            Debug.Log($"Changed camera. Played audio {cameraChangeAudioSource.clip.name}");
        }
    }
}
