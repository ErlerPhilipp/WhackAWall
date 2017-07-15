using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class steering : MonoBehaviour {

    public GameObject target;
    public float velocity = 0.5f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 currPos = this.gameObject.transform.position;
        Vector3 targetPos = target.transform.position;
        Vector3 dir = (targetPos - currPos).normalized;

        this.gameObject.transform.position = currPos + dir * velocity * Time.deltaTime;
        this.gameObject.transform.rotation = Quaternion.FromToRotation(new Vector3(0, 0, 1), dir);
    }
}
