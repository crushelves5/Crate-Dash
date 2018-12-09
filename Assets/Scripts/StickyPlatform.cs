using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickyPlatform : MonoBehaviour {

    Transform parent;
    Vector3 startPosition;
    float startingHeight;
    float crateCount;
    
    public float cubeHeight;

	// Use this for initialization
	void Start () {
        startPosition = transform.position;
        parent = transform.parent;
        startingHeight = transform.position.y;
        crateCount = 0;
	}
	

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Crate")
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + cubeHeight, transform.position.z);
            other.transform.parent = parent;

            Destroy(other.gameObject.GetComponent<Rigidbody>());
            //other.transform.GetComponent<Rigidbody>().isKinematic = true;

            parent.GetComponent<ForkliftManager>().AddCrate(other.GetComponent<Crate>());

            crateCount++;
            if (parent.GetComponent<ForkliftManager>().crateArray[0] == null)
            {
                Refresh();
            }
            if (crateCount == 3)
            {
                transform.GetComponent<Collider>().enabled = false;
            }
        }
        

    }
    public void Refresh()
    {
        foreach (Transform child in parent)
        {
            if (child.tag == "Crate")
            {
                Destroy(child.gameObject);
            }
        }
        parent.GetComponent<ForkliftManager>().Clean(); 
        crateCount = 0;
        transform.position = new Vector3(transform.position.x, startingHeight, transform.position.z);
        transform.GetComponent<Collider>().enabled = true;
    }
  


}
