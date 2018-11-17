using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using SimpleJSON;
using UnityEngine.SceneManagement;

public class findcarController : MonoBehaviour {
    string getServer;
    public int currentSelectedCar = 0;
    bool updated = false;
    private string location1;
    private string location2;
    // Use this for initialization
    void Start () {
        getServer = "http://test-vhan.herokuapp.com/car/getLocation/";
        StartCoroutine(FindCar());
    }
	private void SwitchSelection()
    {
        switch(currentSelectedCar)
        {
            case 0: //first car plate
                GameObject.Find("Preview").transform.Find("Map1").gameObject.SetActive(true);
                GameObject.Find("Preview").transform.Find("Map2").gameObject.SetActive(false);
                GameObject.Find("Carplate1").GetComponent<Image>().color = new Color(0.5f, 0.5f, 0.5f, 1);
                GameObject.Find("Carplate2").GetComponent<Image>().color = new Color(0f, 0f, 0f, 1);
                break;
            case 1: // second car plate
                GameObject.Find("Preview").transform.Find("Map1").gameObject.SetActive(false);
                GameObject.Find("Preview").transform.Find("Map2").gameObject.SetActive(true);
                GameObject.Find("Carplate1").GetComponent<Image>().color = new Color(0f, 0f, 0f, 1);
                GameObject.Find("Carplate2").GetComponent<Image>().color = new Color(0.5f, 0.5f, 0.5f, 1);
                break;
        }
    }
	// Update is called once per frame
	void Update () {
        SwitchSelection();
	}
    public void OnCarplateClicked()
    {
        if (currentSelectedCar == 0)
            currentSelectedCar = 1;
        else
            currentSelectedCar = 0;
    }
    public void OnFindCarPressed()
    {
        StartCoroutine(FindCar());
    }
    IEnumerator FindCar()
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
                    JSONNode obj = JSON.Parse(www.downloadHandler.text);
                    string carplate1 = obj[0]["occupy"].Value;
                    string carplate2 = obj[1]["occupy"].Value;
                    string location1 = "Level: " + obj[0]["level"].Value + " Sloat: " + obj[0]["slot"].Value;
                    string location2 = "Level: " + obj[1]["level"].Value + " Sloat: " + obj[1]["slot"].Value;
                    GameObject.Find("Carplate1").transform.Find("Text").GetComponent<Text>().text = carplate1;
                    GameObject.Find("Carplate2").transform.Find("Text").GetComponent<Text>().text = carplate2;
                    updated = true;
                }
            }
        }
    }
    public void OnBackPressed()
    {
        SceneManager.LoadScene("HomeScene", LoadSceneMode.Single);
    }
}
