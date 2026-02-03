using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class playAudio : MonoBehaviour
{
    public float fadeTimeInSeconds;

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
            StartCoroutine(FadeAudio(true));
        }
    }
 private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            audio.Pause();
        }
    }

    private IEnumerator FadeAudio(bool fadeIn)
    {
        float timer = 0;
        while(timer < fadeTimeInSeconds)
        {
            audio.volume = Mathf.Lerp(0, 1, timer / fadeTimeInSeconds);
            timer += Time.deltaTime;
            yield return null;
        }

        audio.volume = 1;
    }

}
