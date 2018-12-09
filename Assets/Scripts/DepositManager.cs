using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.Audio;


//Script attached to Deposit collider
public class DepositManager : MonoBehaviour {
    public AudioSource matchSound;
    public AudioSource unmatchSound;
    public event Action Match;
    public event Action UnMatch;
    
    public GameObject plus150;
    public GameObject minus75;
    public GameObject plain;


    public Crate redCrate;
    public Crate blueCrate;
    public Crate greenCrate;
    Crate spawnedCrate;
    Crate[] crateArray;
    Crate.Color[] colorArray;
    public Transform target;
    public Transform crateParent;

    Vector3 targetStartPosition;
    StickyPlatform stickyPlatform;
    bool isMatch;
    bool submitted;


	// Use this for initialization
	void Start () {
        colorArray = new Crate.Color[3];
        targetStartPosition = target.position;
        isMatch = true;
        Randomize();
        submitted = false;
        
	}
	
	// Update is called once per frame
void Randomize()
    {
        int rNum;
        for(int x = 0; x < colorArray.Length; x++)
        {
            rNum = UnityEngine.Random.Range(0, 3);
            if(rNum == 0)
            {
                colorArray[x] = Crate.Color.Red;
            }
            else if(rNum == 1)
            {
                colorArray[x] = Crate.Color.Green;
            }
            else
            {
                colorArray[x] = Crate.Color.Blue;
            }
        }
        Display();
    }

    void Display()
    {
        for(int x = 0; x < colorArray.Length; x++)
        {
            if(colorArray[x] == Crate.Color.Red)
            {
                spawnedCrate = Instantiate(redCrate, target.position, Quaternion.identity) as Crate;
            }
            else if(colorArray[x] == Crate.Color.Green)
            {
                 spawnedCrate = Instantiate(greenCrate, target.position, Quaternion.identity) as Crate;
            }
            else
            {
                spawnedCrate = Instantiate(blueCrate, target.position, Quaternion.identity) as Crate;
            }
            spawnedCrate.GetComponent<Rigidbody>().isKinematic = true;
            spawnedCrate.transform.parent = crateParent;
            target.position = new Vector3(target.position.x, target.position.y + spawnedCrate.transform.GetComponent<MeshCollider>().bounds.size.y, target.position.z);
             
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.tag == "Player")
        {

            //Compare array contents
            crateArray = other.transform.parent.GetComponent<ForkliftManager>().crateArray;
            //if first element is not empty
            if(crateArray[0] != null)
            {
                submitted = true;
                isMatch = true;
                for(int x = 0; x< crateArray.Length; x++)
                {
                    if (crateArray[x] == null) { isMatch = false; break; }
                    if(crateArray[x].color != colorArray[x])
                    {
                        isMatch = false;
                        break;
                    }
                }
                if (isMatch) {
                    plain.SetActive(false);
                    minus75.SetActive(false);
                    plus150.SetActive(true);
                    Match();
                    matchSound.Play();

                }
                else {
                    plain.SetActive(false);
                    plus150.SetActive(false);
                    minus75.SetActive(true);
                   
                    UnMatch();
                    unmatchSound.Play();
                }
            }

            //Refresh cubes and positions
            if (submitted)
            {
                Refresh(other);
                submitted = false;
            }
        }
    }

    void Refresh(Collider other)
    {
        foreach (Transform child in crateParent)
        {
            if (child.tag == "Crate")
            {
                Destroy(child.gameObject);
            }
        }


        target.position = targetStartPosition;
        stickyPlatform = other.transform.parent.GetComponentInChildren<StickyPlatform>();
        stickyPlatform.Refresh();
        Randomize();
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            plus150.SetActive(false);
            minus75.SetActive(false);
            plain.SetActive(true);
        }
    }

}
