using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class mapController : MonoBehaviour {
    GameObject Car;
    GameObject Path1;
    GameObject Path2;
	// Use this for initialization
	void Start () {
        Car = this.transform.Find("Car").gameObject;
        Path1 = this.transform.Find("Path1").gameObject;
        Path2 = this.transform.Find("Path2").gameObject;
	}
	
	// Update is called once per frame
	void Update () {
        Car.GetComponent<Image>().color = Color.Lerp(Color.white, Color.red, Mathf.PingPong(Time.time * 2f, 1));
        Path1.GetComponent<Image>().color = Color.Lerp(Color.green, Color.white, Mathf.PingPong(Time.time *0.5f, 1));
        Path2.GetComponent<Image>().color = Color.Lerp(Color.green, Color.white, Mathf.PingPong(Time.time * 0.5f, 1));
    }
}
