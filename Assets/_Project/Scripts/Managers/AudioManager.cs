using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

   [SerializeField] private AudioSource _audioSource;
   [SerializeField] private AudioClip _buttonClick;
   [SerializeField] private AudioClip _match;
   [SerializeField] private AudioClip _mismatch;
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
