using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(SteamVR_TrackedObject))]

public class scene_manager : MonoBehaviour {

    SteamVR_TrackedObject trackedObj;

    public void Start()
    {
        trackedObj = this.GetComponentInParent<SteamVR_TrackedObject>();
    }

    public void changeToScene(int sceneToChangeTo)
    {
        SceneManager.LoadScene(sceneToChangeTo);
    }
    public void Update()
    {
        SteamVR_Controller.Device device = SteamVR_Controller.Input((int)trackedObj.index);
        if (device.GetPressDown(SteamVR_Controller.ButtonMask.Trigger) || device.GetPressDown(SteamVR_Controller.ButtonMask.Grip) || device.GetPressDown(SteamVR_Controller.ButtonMask.Touchpad)) {
            changeToScene(1);
        }
    }
}
