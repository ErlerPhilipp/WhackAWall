using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour {

    public GameObject hitSphere;
    public int spawnNum = 0;
    int maxNum = 3;
    public int leftscore = 0;
    public int rightscore = 0;


    void spawn()
    {
        for(int i = spawnNum; i < maxNum; i++)
        {
            Vector3 HitSpherePos = new Vector3(this.transform.position.x + Random.Range(-this.transform.lossyScale.x/2, this.transform.lossyScale.x/2),
                                               this.transform.position.y + Random.Range(-this.transform.lossyScale.y/2, this.transform.lossyScale.y/2),
                                               this.transform.position.z + Random.Range(-this.transform.lossyScale.z/2, this.transform.lossyScale.z/2));
            Instantiate(hitSphere, HitSpherePos, Quaternion.identity);
            spawnNum++;
        }
    }




	// Use this for initialization
	void Start () {
        spawn();
    }
	
	// Update is called once per frame
	void Update () {
        spawn();
    }
}
