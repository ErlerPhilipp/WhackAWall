using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class despawn : MonoBehaviour {
    public int lifeTime = 3600;
    public GameObject SpawnArea;
    public GameObject boom;
   // new AudioSource audio;
    
    // Use this for initialization
    void Start () {
       // audio = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
        spawner spawn = SpawnArea.GetComponent("spawner") as spawner;
        if (spawn.gameTimer<=0)
        {
            Destroy(this.gameObject);
        }
        lifeTime--;
        if (lifeTime==0)
        {
            kill();
        }
	}
    public void kill()
    {
       // audio.Play();
        spawner spawn = SpawnArea.GetComponent("spawner") as spawner;
        spawn.spawnNum--;
        if (lifeTime > 0)
        {
            GameObject boomInstance = Instantiate(boom, this.gameObject.transform.position, this.gameObject.transform.rotation) as GameObject;
        }
        Destroy(this.gameObject);
        
    }
}
