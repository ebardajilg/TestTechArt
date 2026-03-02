using UnityEngine;

public class SCPCoinCollector : MonoBehaviour
{
    public Transform target;
    private ParticleSystem ps;
    private ParticleSystem.Particle[] particles;

    void Start()
    {
        ps = GetComponent<ParticleSystem>();
    }

    void LateUpdate()
    {
        int numParticlesAlive = ps.GetParticles(particles = new ParticleSystem.Particle[ps.main.maxParticles]);

        for (int i = 0; i < numParticlesAlive; i++)
        {
            // Tomamos la posición X e Y del contador, pero mantenemos la Z de la partícula para que no se "aleje" de la cámara al ir de un punto al otro.
            Vector3 targetPos = target.position;
            Vector3 destination = new Vector3(targetPos.x, targetPos.y, particles[i].position.z);

            particles[i].position = Vector3.Lerp(particles[i].position, destination, Time.deltaTime * 5f);
        }

        ps.SetParticles(particles, numParticlesAlive);
    }
}