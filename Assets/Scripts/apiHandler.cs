using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Net;

public class apiHandler : MonoBehaviour {
    string url = "https://fashion.recoqnitics.com/analyze";
    string id = "aff7b7616a03b7084f29";
    string pass = "40f17d27e2f0a0013c750322bc567f9c4e9da990";
    // Use this for initialization
    void Start () {
    }
	
	// Update is called once per frame
	void Update () {
    }
    public void LaunchAPI()
    {
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(
            String.Format(url, id, pass)
        );
        HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        StreamReader reader = new StreamReader(response.GetResponseStream());
        string jsonResponse = reader.ReadToEnd();
    }
}
