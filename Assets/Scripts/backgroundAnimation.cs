using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.UI;

public class backgroundAnimation : MonoBehaviour {
    public float speed;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        /*this.GetComponent<RectTransform>().anchoredPosition = new Vector2(
            this.GetComponent<RectTransform>().anchoredPosition.x + Time.deltaTime * speed, this.GetComponent<RectTransform>().anchoredPosition.y
            );*/	
        this.GetComponent<Renderer>().material.mainTextureOffset = new Vector2(
            Time.time * -speed, 0
            );
    }
}
