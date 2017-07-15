using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SteamVR_TrackedObject))]

public class touch : MonoBehaviour {

    SteamVR_TrackedObject trackedObj;
    public GameObject SpawnArea;
    new AudioSource audio;
    public Light light;
    public GameObject beam;
    public GameObject beamStart;
   
    int counter = 0;
    int timeCounter = 0;

    // Use this for initialization
    void Awake () {
        trackedObj = this.GetComponentInParent<SteamVR_TrackedObject>();
        audio = GetComponent<AudioSource>();
        

    }

    void Update()
    {
        if (timeCounter > 1)
        {
            timeCounter--;
        }
        
   
        if (timeCounter == 1)
        {
            light.enabled = true;
            RenderSettings.ambientIntensity = 1;
            RenderSettings.ambientLight = Color.grey;
            RenderSettings.reflectionIntensity = 1;
            RenderSettings.fog = true;
            timeCounter = 0;
        }
    }
    // Update is called once per frame
    void FixedUpdate () {
        
        if(counter > 0)
        {
            SteamVR_Controller.Input((int)trackedObj.index).TriggerHapticPulse(2000);
            counter--;
        }

        SteamVR_Controller.Device device = SteamVR_Controller.Input((int)trackedObj.index);
        if (device.GetPress(SteamVR_Controller.ButtonMask.Trigger))
        {
            Instantiate(beam, beamStart.transform.position, this.transform.rotation*Quaternion.Euler(0,-90,0));
        }

        if (device.GetPressDown(SteamVR_Controller.ButtonMask.Trigger))
        {
            if (!audio.isPlaying)
            {
                audio.Play();
                
            }
        }
        if (device.GetPressUp(SteamVR_Controller.ButtonMask.Trigger))
        {
            audio.Stop();
        }

      
        
    }

    public void OnTriggerStay(Collider other)
    {
        SteamVR_Controller.Device device = SteamVR_Controller.Input((int)trackedObj.index);
        
        
        if (device.GetPress(SteamVR_Controller.ButtonMask.Trigger))
        {
            other.gameObject.SetActive(false);
            other.GetComponent<despawn>().kill();
            
            spawner spawn = SpawnArea.GetComponent("spawner") as spawner;
            //spawn.spawnNum--;
            if (other.gameObject.tag == "good")
            {
                counter = 45;
                light.enabled = false;
                RenderSettings.ambientIntensity = 0;
                RenderSettings.ambientLight = Color.black;
                RenderSettings.reflectionIntensity = 0;
                RenderSettings.fog = false;
                timeCounter = 300;
                if (trackedObj.tag == "left")
                {
                    spawn.leftscore =- 5;
                }
                else
                {
                    spawn.rightscore =- 5;
                }
            }
            else
            {
                if (trackedObj.tag == "left")
                {
                    counter = 45;
                    spawn.leftscore++;
                }
                else
                {
                    counter = 45;
                    spawn.rightscore++;
                }
            }

            
        }
    }
}
