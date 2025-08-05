using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Audio manager is used for PLaying AudioClips with one shot - one click
/// </summary>
public class AudioManager : MonoBehaviour
{
   [Header("Injected Dependencies")]
   [Space]
   [Tooltip("Audio Source")]
   [SerializeField] private AudioSource _audioSource;
   [Tooltip("Audio Clip for Button Click")]
   [SerializeField] private AudioClip _buttonClick;
   [Tooltip("Audio Clip for Matching")]
   [SerializeField] private AudioClip _match;
   [Tooltip("Audio Clip for MIsmatching")]
   [SerializeField] private AudioClip _mismatch;
   [Tooltip("Audio Clip for Won the Level")]
   [SerializeField] private AudioClip _won;
   
   public void PlaySoundButtonClick()
   {
      _audioSource.PlayOneShot(_buttonClick);
   }

   public void PlaySoundMatch()
   {
      _audioSource.PlayOneShot(_match);
   }
   
   public void PlaySoundMismatch()
   {
      _audioSource.PlayOneShot(_mismatch);
   }
   
   public void PlaySoundWin()
   {
      _audioSource.PlayOneShot(_won);
   }
}
