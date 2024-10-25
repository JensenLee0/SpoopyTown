using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AltarExplode : MonoBehaviour
{
    public float explosionforce;
    public ParticleSystem explosionParticles;
    public bool hasnotexploded = false;

    // Start is called before the first frame update
    void Start()
    {
        explosionParticles.Stop();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Rigidbody>().AddRelativeForce(Vector3.back * explosionforce, ForceMode.Impulse);
            explosionParticles.Play();
        }
    }
}
