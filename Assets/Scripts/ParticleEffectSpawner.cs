using UnityEngine;
using System.Collections;

public class ParticleEffectSpawner : MonoBehaviour
{
    public GameObject particleEffectPrefab; // Reference to the particle effect prefab

    // Method to spawn the particle effect at a given position
    public void SpawnParticleEffect(Vector3 position)
    {
        // Spawn the particle effect prefab
        GameObject particleEffect = Instantiate(particleEffectPrefab, position, Quaternion.identity);

        // Start playing the particle system
        ParticleSystem particleSystem = particleEffect.GetComponent<ParticleSystem>();
        particleSystem.Play();

        // Start the coroutine to destroy the particle effect after a delay
        StartCoroutine(DestroyParticleEffectAfterDelay(particleEffect, 3f));
    }

    // Coroutine to destroy the particle effect after a delay
    private IEnumerator DestroyParticleEffectAfterDelay(GameObject particleEffect, float delay)
    {
        yield return new WaitForSeconds(delay);

        // Destroy the particle effect after the delay
        Destroy(particleEffect);
    }
}
