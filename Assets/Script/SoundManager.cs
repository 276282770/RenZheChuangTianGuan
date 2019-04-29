using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;
    // Start is called before the first frame update
    public AudioSource audioBg;
    public AudioSource audio2;
    public AudioClip clipGameOver;
    public AudioClip clipCountDown;
    void Start()
    {
        Instance = this;
        DontDestroyOnLoad(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PlayGameOver()
    {
        audio2.clip = clipGameOver;
        audio2.Play();
    }
    public void PlayCountDown()
    {
        audio2.clip = clipCountDown;
        audio2.Play();
    }
    public void PlayBGM()
    {
        audioBg.Play();
    }
    public void StopBGM()
    {
        audioBg.Stop();
    }

}
