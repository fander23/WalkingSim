using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class playAudio : MonoBehaviour
{
    private AudioSource audio;
    
private void Start()
    {
        audio = GetComponent<AudioSource>();
    }

private void OnTriggerEnter(Collider other)
    {
      if(other.tag == "Player")
        {
            audio.Play();
        }
    }
 private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            audio.Pause();
        }
    }

}
