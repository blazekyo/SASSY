using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using System.Collections;
using SimpleJSON;

public class GetRequestSample : MonoBehaviour {
    void Start()
    {
        StartCoroutine(GetText());
    }
    // http://test-vhan.hirokuapp.com
    IEnumerator GetText()
    {
        Debug.Log("initiated");
        using (UnityWebRequest www = UnityWebRequest.Get("http://test-vhan.herokuapp.com/"))
        {
            yield return www.Send();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                // Show results as text
                //Debug.Log(www.downloadHandler.text);

                // Or retrieve results as binary data
                byte[] results = www.downloadHandler.data;
                Debug.Log(www.downloadHandler.text);
                string sample = "{ \"student\": {\"name\":\"Delon\" }}";
                //Debug.Log(JSON.Parse(sample)["name"].Value);
                Debug.Log(JSON.Parse(www.downloadHandler.text));
                Debug.Log(www.downloadHandler.data);
                this.GetComponent<Text>().text = www.downloadHandler.text;
            }
        }
    }
}
