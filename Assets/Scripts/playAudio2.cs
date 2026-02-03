using UnityEngine;

public class playAudio2 : MonoBehaviour
{
    public float fadeTimeInSeconds;
    private AudioMixer;

    private AudioSource audio;
    private AudioSnapshot

    private void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            audio.Play();   
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            
        }
    }

}
