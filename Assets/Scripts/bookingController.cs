using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using SimpleJSON;
using UnityEngine.SceneManagement;

public class bookingController : MonoBehaviour {
    string getServer;
    string[] levelsAvail;
    string[] slotsAvail;
    private bool updated = false;
    public int initialLevel = 1;
    // Use this for initialization
    void Start () {
        getServer = "http://test-vhan.herokuapp.com/car/parking/booking";
        StartCoroutine(BookCar());
    }
	public void SwitchLevel()
    {
        switch(initialLevel)
        {
            case 1:
                GameObject.Find("Preview").transform.Find("Map1").gameObject.SetActive(true);
                GameObject.Find("Preview").transform.Find("Map2").gameObject.SetActive(false);
                break;
            case 2:
                GameObject.Find("Preview").transform.Find("Map1").gameObject.SetActive(false);
                GameObject.Find("Preview").transform.Find("Map2").gameObject.SetActive(true);
                break;
        }
    }
	// Update is called once per frame
	void Update () {
        SwitchLevel();
        initialLevel = GameObject.Find("Dropdown").GetComponent<Dropdown>().value + 1;
	}
    public void OnBookCarPressed()
    {
        GameObject.Find("Canvas").transform.Find("Success").gameObject.SetActive(true);
    }
    IEnumerator BookCar()
    {
        using (UnityWebRequest www = UnityWebRequest.Get(getServer))
        {
            yield return www.Send();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                if(!updated)
                {
                    // Or retrieve results as binary data
                    byte[] results = www.downloadHandler.data;
                    Debug.Log(www.downloadHandler.text);
                    //Debug.Log(JSON.Parse(sample)["name"].Value);
                    Debug.Log(JSON.Parse(www.downloadHandler.text));
                    Debug.Log(www.downloadHandler.data);
                }
            }
        }
    }
    public void BackHome()
    {
        SceneManager.LoadScene("HomeScene", LoadSceneMode.Single);
    }
}
