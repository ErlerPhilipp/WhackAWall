using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_collision : MonoBehaviour {

    public GameObject SpawnArea;
    

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "enemy")
        {
            spawner spawn = SpawnArea.GetComponent("spawner") as spawner;
            spawn.leftscore--;
            spawn.rightscore--;
            other.GetComponent<despawn>().kill();
        }
        else if(other.gameObject.tag == "good")
        {
            spawner spawn = SpawnArea.GetComponent("spawner") as spawner;
            spawn.leftscore++;
            spawn.rightscore++;
            other.GetComponent<despawn>().kill();
        }
    }
}
