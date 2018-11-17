using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class mapController2 : MonoBehaviour
{
    GameObject Carpark1;
    GameObject Carpark2;
    // Use this for initialization
    void Start()
    {
        Carpark1 = this.transform.Find("Block5").gameObject;
        Carpark2 = this.transform.Find("Block1").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        switch (GameObject.Find("BookingController").GetComponent<bookingController>().initialLevel)
        {
            case 1:
                Carpark1.GetComponent<RawImage>().color = Color.Lerp(Color.green, Color.white, Mathf.PingPong(Time.time * 0.5f, 1));
                Carpark2.GetComponent<RawImage>().color = new Color(1,1,1,1);
                break;
            case 2:
                Carpark2.GetComponent<RawImage>().color = Color.Lerp(Color.green, Color.white, Mathf.PingPong(Time.time * 0.5f, 1));
                Carpark1.GetComponent<RawImage>().color = new Color(1, 1, 1, 1);
                break;
        }
    }
}