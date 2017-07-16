using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class spawner : MonoBehaviour {

    public GameObject[] ghosts = {};
    public int spawnNum = 0;
    public int maxNum = 3;
    public int leftscore = 0;
    public int rightscore = 0;
    public int gameTimer = 8100;
    public GameObject boomMinus;
    public GameObject boomPlus;
    public AudioClip clip;
    public GameObject steeringTarget;

    public void spawn()
    {
        for(int i = spawnNum; i < maxNum; i++)
        {
            Vector3 HitSpherePos;
            do {
                HitSpherePos = new Vector3(this.transform.position.x + Random.Range(-this.transform.lossyScale.x / 2, this.transform.lossyScale.x / 2),
                                                   this.transform.position.y + Random.Range(-this.transform.lossyScale.y / 2, this.transform.lossyScale.y / 2),
                                                   this.transform.position.z + Random.Range(-this.transform.lossyScale.z / 2, this.transform.lossyScale.z / 2));
            } while (HitSpherePos.magnitude < this.transform.lossyScale.x / 4 || HitSpherePos.y < 1);
            int whichGhost = Random.Range(0, ghosts.Length);
            GameObject ghost = Instantiate(ghosts[whichGhost], HitSpherePos, Quaternion.LookRotation(new Vector3(-1,0,0), new Vector3(0,1,0))) as GameObject;
            despawn newDespawner = ghost.AddComponent<despawn>();
            newDespawner.boom = boomMinus;
            if(ghost.gameObject.tag == "good")
            {
                newDespawner.boom = boomPlus;
            }
            newDespawner.lifeTime = 9000;

            steering newSteering = ghost.AddComponent<steering>();
            newSteering.target = steeringTarget;

            // AudioSource newAudio = ghost.AddComponent<AudioSource>();

            // newAudio.playOnAwake = false;
            // newAudio.clip = clip; 
            newDespawner.SpawnArea = this.gameObject;
            spawnNum++;
            
        }
    }




	// Use this for initialization
	void Start () {
        spawn();
    }
	
	// Update is called once per frame
	void Update () {
        if (gameTimer > 0)
        {
            spawn();
            gameTimer--;
        }
        if (gameTimer == 5400)
        {
            maxNum = 15;
        }
        else if(gameTimer == 2700)
        {
            maxNum = 25;
        }
        
    }
}
