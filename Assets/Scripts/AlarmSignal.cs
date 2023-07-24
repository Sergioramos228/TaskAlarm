using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(AudioSource))]
public class AlarmSignal : MonoBehaviour
{
    private Coroutine _volumeChanging;
    private AudioSource _audio;

    private void Awake()
    {
        TryGetComponent(out _audio);
    }


    public void PutOffSignal()
    {
        StartChangeVolume(Vector2.down);
    }
    public void PutOnSignal()
    {
        StartChangeVolume(Vector2.up);
    }

    private IEnumerator VolumeUp()
    {
        yield return null;
        int targetVolume = 1;

        while (_audio.volume != targetVolume)
        {
            yield return null;
            _audio.volume = Mathf.MoveTowards(_audio.volume, targetVolume, Time.deltaTime);
        }
    }

    private IEnumerator VolumeDown()
    {
        yield return null;
        int targetVolume = 0;

        while (_audio.volume != targetVolume)
        {
            yield return null;
            _audio.volume -= Mathf.MoveTowards(targetVolume, _audio.volume, Time.deltaTime);
        }
    }

    private void StartChangeVolume(Vector2 vector)
    {
        if (_volumeChanging!= null)
            StopCoroutine(_volumeChanging);

        if(vector == Vector2.up)
            _volumeChanging = StartCoroutine(VolumeUp());
        else
            _volumeChanging = StartCoroutine(VolumeDown());
    }
}
