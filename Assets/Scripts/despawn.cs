using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class despawn : MonoBehaviour {
    int timer = 900;
    public GameObject SpawnArea;
    // Use this for initialization
    void Start () {
        		
	}
	
	// Update is called once per frame
	void Update () {
        timer--;
        if (timer==0)
        {
            spawner spawn = SpawnArea.GetComponent("spawner") as spawner;
            spawn.spawnNum--;
            Destroy(this.gameObject);
        }
	}
}
