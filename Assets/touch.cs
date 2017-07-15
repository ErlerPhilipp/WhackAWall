using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SteamVR_TrackedObject))]

public class touch : MonoBehaviour {

    SteamVR_TrackedObject trackedObj;
    public GameObject SpawnArea;
    AudioSource audio;
    public AudioClip beam;
    int counter = 0;
    
    // Use this for initialization
    void Awake () {
        trackedObj = GetComponent<SteamVR_TrackedObject>();
        audio = GetComponent<AudioSource>();
        beam = GetComponent<AudioClip>();

    }
	
	// Update is called once per frame
	void FixedUpdate () {
        
        if(counter > 0)
        {
            SteamVR_Controller.Input((int)trackedObj.index).TriggerHapticPulse(2000);
            counter--;
        }
	}

    public void OnTriggerStay(Collider other)
    {
        SteamVR_Controller.Device device = SteamVR_Controller.Input((int)trackedObj.index);
        
        
        if (device.GetPressDown(SteamVR_Controller.ButtonMask.Trigger))
        {
            audio.PlayOneShot(beam,1);
            other.gameObject.SetActive(false);
            Destroy(other.gameObject);
            spawner spawn = SpawnArea.GetComponent("spawner") as spawner;
            spawn.spawnNum--;
            if (trackedObj.tag == "left")
            {
                counter = 45;
                spawn.leftscore++;
                Debug.Log("Linker Score: " + spawn.leftscore);
            }
            else
            {
                counter = 45;
                spawn.rightscore++;
                Debug.Log("Rechter Score: "+ spawn.rightscore);
            }

            
        }

    }
}
