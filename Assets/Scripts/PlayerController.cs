using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class PlayerController : MonoBehaviour {
    Rigidbody myRigidbody;
    public Vector3 velocity;
   public Vector3 moveInput;
    public float moveSpeed = 5;
    public AudioSource lowDecel;
    public AudioSource highDecel;
	// Use this for initialization
	void Start () {

        myRigidbody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	 void FixedUpdate () {
        moveInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0,0);
        velocity = moveInput.normalized * moveSpeed;
        
        //translate rigidbody
        myRigidbody.MovePosition(myRigidbody.position + velocity * Time.deltaTime);
        if (velocity.magnitude > 0)
        {
            if (!highDecel.isPlaying)
            {
                lowDecel.Pause();
                highDecel.Play();
            }

        }
        else {
            if (!lowDecel.isPlaying)
            {
                highDecel.Pause();
                lowDecel.Play();
            }

                }

        //myRigidbody.AddForce(velocity, ForceMode.VelocityChange);

    }
}
