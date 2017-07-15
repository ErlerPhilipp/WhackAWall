using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer_Script : MonoBehaviour {
    public GameObject SpawnArea;
    public Text text_1;
    public Text text_2;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        spawner spawn = SpawnArea.GetComponent("spawner") as spawner;

        string leftScore = spawn.leftscore.ToString();
        string rightScore = spawn.rightscore.ToString();

        text_1.text = leftScore;
        text_2.text = rightScore;
    }
}
