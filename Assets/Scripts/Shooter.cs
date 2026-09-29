using System.Collections;
using UnityEngine;



public class Shooter : MonoBehaviour
{
   [Header("Base Variables")]
   [SerializeField] private GameObject projectilePrefab;
   [SerializeField] private float projectileSpeed = 10f;
   [SerializeField] private float projectileLifetime = 5f;
   [SerializeField] float baseFireRate = 0.2f;
   
   [Header("AI Variables")]
   [SerializeField] private bool useAI;
   [SerializeField] private float minimumFireRate = 0.2f;
   [SerializeField] private float fireRateVariance = 0f;
   
  [HideInInspector] public bool isFiring;
   Coroutine fireCoroutine;
   private AudioManager audioManager;

   private void Start()
   {
      audioManager = FindObjectOfType<AudioManager>();
      if (useAI)
      {
         isFiring = true;
      }
   }

   private void Update()
   {
      Fire();
   }

   void Fire()
   {
      if (isFiring && fireCoroutine == null)
      {
         fireCoroutine = StartCoroutine(FireContinuously());
      }
      else if(!isFiring && fireCoroutine != null)
      {
         StopCoroutine(fireCoroutine);
         fireCoroutine = null;
      }
   }
   
   IEnumerator FireContinuously()
   {
      while (true)
      {
         GameObject projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
         projectile.transform.rotation = transform.rotation;
         Rigidbody2D projectileRB = projectile.GetComponent<Rigidbody2D>();
         
         projectileRB.linearVelocity = transform.up * projectileSpeed;
         Destroy(projectile, projectileLifetime);

         float shootAITime = Random.Range(baseFireRate - fireRateVariance, baseFireRate+ fireRateVariance);
         shootAITime = Mathf.Clamp(shootAITime, minimumFireRate, float.MaxValue);
         audioManager.PlayShootingSFX();
         yield return new WaitForSeconds(shootAITime);
      }
   }
}
