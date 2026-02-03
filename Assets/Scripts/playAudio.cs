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
            StopAllCoroutines();
            StartCoroutine(FadeAudioOut(true));
        }
    }

    private IEnumerator FadeAudio(bool fadeIn)
    {
        float timer = 0;
        float start = fadeIn ? 0 : audio.volume;
        float end = fadeIn ? 1 : 0;

        if(fadeIn ) audio.Play();
        while(timer < fadeTimeInSeconds)
        {
            audio.volume = Mathf.Lerp(start, end, timer / fadeTimeInSeconds);
            timer += Time.deltaTime;
            yield return null;
        }

        audio.volume = end;
        if (fadeIn) audio.Pause();
    }

    private IEnumerator FadeAudioOut(bool fadeOut)
    {
        float timer = 0;
        while(timer < fadeTimeInSeconds)
        {
            audio.volume = Mathf.Lerp(1, 0, timer / fadeTimeInSeconds);
            timer += Time.deltaTime;
            yield return null;
        }

        audio.volume = 0;
        audio.Pause();
    }

}
