using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using SimpleJSON;
using UnityEngine.SceneManagement;

public class LocationController : MonoBehaviour {
    AndroidJavaClass intentClass;
    AndroidJavaObject intentObject;
    string subject;
    string message;
    string link;
    string getServer;
    //WebRequest

    // Use this for initialization
    void Start()
    {
        intentClass = new AndroidJavaClass("android.content.Intent");
        intentObject = new AndroidJavaObject("android.content.Intent");
        //set action to that intent object   
        intentObject.Call<AndroidJavaObject>
        ("setAction", intentClass.GetStatic<string>("ACTION_SEND"));

        getServer = "http://test-vhan.herokuapp.com/user/getLocation";
    }
    private void AttachShareContent()
    {
        link = GameObject.Find("CodeLbl").GetComponent<Text>().text;
        subject = "Here's my Current Location!";
        message = "Here's my current location! " + link;
        //set the type as text and put extra subject and text to share
        intentObject.Call<AndroidJavaObject>("setType", "text/plain");
        intentObject.Call<AndroidJavaObject>("putExtra",
                    intentClass.GetStatic<string>("EXTRA_SUBJECT"), subject);
        intentObject.Call<AndroidJavaObject>("putExtra", intentClass.GetStatic<string>("EXTRA_TEXT"), message);
    }
    // Update is called once per frame
    void Update()
    {
        AttachShareContent();
    }
    public void Share()
    {
        //create current activity object
        AndroidJavaClass unity = new
                        AndroidJavaClass("com.unity3d.player.UnityPlayer");
        AndroidJavaObject currentActivity =
                     unity.GetStatic<AndroidJavaObject>("currentActivity");

        //call createChooser method of activity class     
        AndroidJavaObject chooser =
                intentClass.CallStatic<AndroidJavaObject>("createChooser",
                             intentObject, "Share Location Code");
        currentActivity.Call("startActivity", chooser);
    }
    public void OnGetLocationPressed()
    {
        //GET Request
        StartCoroutine(GetLocation());
    }
    IEnumerator GetLocation()
    {
        Debug.Log("initiated");
        using (UnityWebRequest www = UnityWebRequest.Get(getServer))
        {
            yield return www.Send();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                // Or retrieve results as binary data
                byte[] results = www.downloadHandler.data;
                Debug.Log(www.downloadHandler.text);
                //Debug.Log(JSON.Parse(sample)["name"].Value);
                Debug.Log(JSON.Parse(www.downloadHandler.text));
                JSONNode obj = JSON.Parse(www.downloadHandler.text);
                GameObject.Find("Label").GetComponent<Text>().text = "Level: " + obj["level"].Value + " Area: " + AreaCodeMap(int.Parse(obj["shop_code"].Value));
            }
        }
    }
    private string AreaCodeMap(int code)
    {
        string area = "";
        switch(code)
        {
            case 0:
                area = "Main Lobby";
                break;
            case 1:
                area = "Toilet";
                break;
            case 2:
                area = "Food Court";
                break;
            case 3:
                area = "Game Center";
                break;
            case 4:
                area = "Cinema";
                break;
            case 5:
                area = "Main Door";
                break;
        }
        return area;
    }
    public void OnBackPressed()
    {
        SceneManager.LoadScene("HomeScene", LoadSceneMode.Single);
    }
}
