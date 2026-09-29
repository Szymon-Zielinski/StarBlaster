using System;
using UnityEngine;

public class Health : MonoBehaviour
{
   [SerializeField] int health= 50;
   [SerializeField] private ParticleSystem hitParticles;
   [SerializeField] private bool applyCameraShake;
   [SerializeField] bool isPlayer;
   [SerializeField] private int scoreValue = 50;
   
   
   private CameraShake cameraShake;
   private AudioManager audioManager;
   private ScoreKeeper scoreKeeper;

   void Start()
   {
      audioManager = FindObjectOfType<AudioManager>();
      cameraShake = Camera.main.GetComponent<CameraShake>();
      scoreKeeper = FindObjectOfType<ScoreKeeper>();
   }
   private void OnTriggerEnter2D(Collider2D other)
   {
      DamageDealer damageDealer = other.GetComponent<DamageDealer>();
      if (damageDealer != null)
      {
       
         TakeDamage(damageDealer.GetDamage());
         PlayHitParticles();
         damageDealer.Hit();
         audioManager.PlayDamageSFX();
         if (applyCameraShake)
         {
            cameraShake.Play();
         }
      }
   }

   private void TakeDamage(int damage)
   {
      health -= damage;
      if (health <= 0)
      {
        Die();
      }
   }

   void Die()
   {
      if (!isPlayer)
      {
         scoreKeeper.ModifyScore(scoreValue);
      }
      Destroy(gameObject);
   }
   void PlayHitParticles()
   {
      if (hitParticles != null)
      {
         ParticleSystem particels = Instantiate(hitParticles, transform.position, Quaternion.identity);
         Destroy(particels, hitParticles.main.duration + particels.main.startLifetime.constantMax);
      }
   }

   public int GetHealth()
   {
      return health;
   }
}
