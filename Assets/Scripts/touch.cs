﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(SteamVR_TrackedObject))]

public class touch : MonoBehaviour {

    SteamVR_TrackedObject trackedObj;
    public GameObject SpawnArea;
    new AudioSource audio;
    public Light[] lights;
    public GameObject beam;
    public GameObject beamStart;
    public int soundCounter = 20;
   
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
            foreach (Light light in lights)
            {
                light.enabled = true;
            }
            RenderSettings.ambientIntensity = 1;
            RenderSettings.ambientLight = Color.grey;
            RenderSettings.reflectionIntensity = 1;
           // RenderSettings.fog = true;
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
        if (device.GetPressDown(SteamVR_Controller.ButtonMask.Trigger))
        {
            Instantiate(beam, beamStart.transform.position, this.transform.rotation*Quaternion.Euler(0,-90,0));
            if (!audio.isPlaying)
            {
                audio.Play();

            }
        }
        if (audio.isPlaying)
        {
            if (soundCounter > 0)
            {
                soundCounter--;
            }
            else
            {
                audio.Stop();
                soundCounter = 20;
            }
        }

        spawner spawn = SpawnArea.GetComponent("spawner") as spawner;
        if (spawn.gameTimer <= 0 && device.GetPressDown(SteamVR_Controller.ButtonMask.Touchpad))
        {
            changeToScene(1);
        }

    }

    public void OnTriggerStay(Collider other)
    {
        SteamVR_Controller.Device device = SteamVR_Controller.Input((int)trackedObj.index);
        
        
        if (device.GetPressDown(SteamVR_Controller.ButtonMask.Trigger))
        {
            other.gameObject.SetActive(false);
            other.GetComponent<despawn>().kill();
            
            spawner spawn = SpawnArea.GetComponent("spawner") as spawner;
            //spawn.spawnNum--;
            if (other.gameObject.tag == "good")
            {
                counter = 45;
                foreach (Light light in lights)
                {
                    light.enabled = false;
                }
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
    public void changeToScene(int sceneToChangeTo)
    {
        SceneManager.LoadScene(sceneToChangeTo);
    }
}
