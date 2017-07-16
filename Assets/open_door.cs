using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class open_door : MonoBehaviour {

    new AudioSource audio;
    public AudioClip sound;
   public spawner SpawnArea;
	// Use this for initialization
	void Start () {
        audio = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
        if(SpawnArea.gameTimer == 0)
        {
            audio.PlayOneShot(sound,1);
            this.gameObject.transform.rotation = Quaternion.identity;
            SpawnArea.gameTimer = -1;
        }
    }
}
