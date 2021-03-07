using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody rb;
    Transform transform;
    [SerializeField] float mainThrust = 100f;
    [SerializeField] float mainRotate = 1f;
    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        transform = GetComponent<Transform>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessThrust();
        ProcessRotation();
    }
    void ProcessThrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            rb.AddRelativeForce(Vector3.up * mainThrust*Time.deltaTime);
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
            
            Debug.Log("Thrust Working");
        }
        else { audioSource.Stop(); }
        
        
    }
    void ProcessRotation()
    {   if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.D)){}
        else if (Input.GetKey(KeyCode.A))
        {
            ApplyRotation(mainRotate);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            ApplyRotation(-mainRotate);
        }
    }

    private void ApplyRotation(float rotationThisFrame)
    {
        rb.freezeRotation = true; //freezing rotation so we can manually rotate
        transform.Rotate(Vector3.forward * rotationThisFrame * Time.deltaTime );
        rb.freezeRotation = false;
    }
}
