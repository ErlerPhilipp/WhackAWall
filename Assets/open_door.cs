using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class open_door : MonoBehaviour {

    
   public spawner SpawnArea;
	// Use this for initialization
	void Start () {
       
    }
	
	// Update is called once per frame
	void Update () {
        if(SpawnArea.gameTimer <= 0)
        {
            this.gameObject.transform.rotation = Quaternion.identity;
        }
    }
}
