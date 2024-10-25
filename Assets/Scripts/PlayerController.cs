using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float moveSpeed;
    private float verticalInput;

    public float turnSpeed;
    private float horizontalInput;

    public Animator animator;
    public AudioSource playerAudio;
    public AudioClip flamethrowerSound;
    public ParticleSystem fire;

    // Start is called before the first frame update
    void Start()
    {

        animator = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
        fire.Stop();

    }

    // Update is called once per frame
    void Update()
    {
        //Move Forward
        verticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed * verticalInput);

        //Rotate
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up, turnSpeed * Time.deltaTime * horizontalInput);

        if(Input.GetKeyDown(KeyCode.Space))
        {
            fire.Play();
            playerAudio.PlayOneShot(flamethrowerSound, 1.0f);
        }
        if(Input.GetKeyUp(KeyCode.Space))
        {
            fire.Stop();
            playerAudio.Stop();
        }
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("flammable"))
        {
            Destroy(other.gameObject);
        }
    }
}
