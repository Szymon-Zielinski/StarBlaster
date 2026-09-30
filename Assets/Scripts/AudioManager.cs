using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
   [Header("Shooting SFX")] 
   [SerializeField] private AudioClip shootingClip;

   [SerializeField] [Range(0,1)] private float shootingVolume = 0.1f;
   [Header("Damage SFX")] 
   [SerializeField] private AudioClip damageClip;
   [SerializeField] [Range(0,1)] private float damageVolume = 0.5f;

   // public static AudioManager instance;
   // private void Awake()
   // {
   //    ManageSingleton();
   // }
   //
   // void ManageSingleton()
   // {
   //    int instanceCount = FindObjectsOfType<AudioManager>().Length;
   //    if (instanceCount > 1)
   //    if (instance != null)
   //    {
   //       gameObject.SetActive(false);
   //       Destroy(gameObject);
   //    }
   //    else
   //    {
   //       instance = this;
   //       DontDestroyOnLoad(gameObject);
   //    }
   // }
   public void PlayShootingSFX()
   {
      PlayAudioClip(shootingClip, shootingVolume);
   }

   public void PlayDamageSFX()
   {
      PlayAudioClip(damageClip, damageVolume);
   }

   void PlayAudioClip(AudioClip clip, float volume)
   {
      if (clip != null)
      {
         AudioSource.PlayClipAtPoint(clip, Camera.main.transform.position, volume);
      }
   }
}
