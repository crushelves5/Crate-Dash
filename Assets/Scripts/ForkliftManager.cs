using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForkliftManager : MonoBehaviour {

    
    public Crate[] crateArray;
    int crateIndex;
    

	// Use this for initialization
	void Start () {
        crateArray = new Crate[3];
        crateIndex = 0;
        
	}
	


    public void AddCrate(Crate crate)
    {
        
        if (crateIndex < crateArray.Length)
        {
            crateArray.SetValue(crate, crateIndex);
            if (crateArray[0] != null)
            {
                crateIndex++;
            }
        }
    }

    public void Clean()
    {
        crateIndex = 0;

    }
}
