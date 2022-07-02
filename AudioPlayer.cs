using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    public GameObject takeDamageSourseObject;
    public GameObject attackSourseObject;
    public GameObject shootSourseObject;
    public GameObject deadSourseObject;

    public AudioSource walkAudio;
    public AudioSource bowStringAudio;

    private float distanseAudio = 30;

    private void Start()
    {
        SetAudioSoursesSettings(deadSourseObject.GetComponents<AudioSource>());
        SetAudioSoursesSettings(attackSourseObject.GetComponents<AudioSource>());
        SetAudioSoursesSettings(takeDamageSourseObject.GetComponents<AudioSource>());

        SetAudioSettings(walkAudio);
        SetAudioSettings(bowStringAudio);
    }

    private void SetAudioSoursesSettings(AudioSource[] audios)
    {
        foreach (AudioSource audio in audios)
        {
            audio.minDistance = distanseAudio;
            audio.maxDistance = distanseAudio;
        }
    }

    private void SetAudioSettings(AudioSource audio)
    {
        audio.minDistance = distanseAudio;
        audio.maxDistance = distanseAudio;
    }

    public void DeadSoursePlay()
    {
        AudioSource[] audios = deadSourseObject.GetComponents<AudioSource>();

        audios[Random.Range(0, audios.Length)].Play();
    }

    public void TakeDamageSoursePlay()
    {
        AudioSource[] audios = takeDamageSourseObject.GetComponents<AudioSource>();

        audios[Random.Range(0, audios.Length)].Play();
    }

    public void AttackSoursePlay()
    {
        AudioSource[] audios = attackSourseObject.GetComponents<AudioSource>();

        audios[Random.Range(0, audios.Length)].Play();
    }

    public void ShootoursePlay()
    {
        AudioSource[] audios = shootSourseObject.GetComponents<AudioSource>();

        audios[Random.Range(0, audios.Length)].Play();
    }

    public void WalkAudioPlay()
    {
        if (!walkAudio.isPlaying)
        {
            walkAudio.Play();
        }
    }

    public void WalkAudioStop()
    {
        walkAudio.Stop();
    }
}