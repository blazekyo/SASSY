using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using SimpleJSON;
using UnityEngine.SceneManagement;

public class findFashionController : MonoBehaviour {
    string getServer;
    string type;
    JSONNode node = null;

    //objects
    RawImage Shop1Image;
    RawImage Shop2Image;
    RawImage Shop3Image;
    Text Title1Image;
    Text Title2Image;
    Text Title3Image;

    // Use this for initialization
    void Start()
    {
        getServer = "http://test-vhan.herokuapp.com/shop/getShop/";
        //setup objects
        Shop1Image = GameObject.Find("Canvas").transform.Find("Shops").transform.Find("Shop1").transform.Find("ShopImage1").gameObject.GetComponent<RawImage>();
        Shop2Image = GameObject.Find("Canvas").transform.Find("Shops").transform.Find("Shop2").transform.Find("ShopImage2").gameObject.GetComponent<RawImage>();
        Shop3Image = GameObject.Find("Canvas").transform.Find("Shops").transform.Find("Shop3").transform.Find("ShopImage3").gameObject.GetComponent<RawImage>();

        Title1Image = GameObject.Find("Canvas").transform.Find("Shops").transform.Find("Shop1").transform.Find("ShopTitle1").gameObject.GetComponent<Text>();
        Title2Image = GameObject.Find("Canvas").transform.Find("Shops").transform.Find("Shop2").transform.Find("ShopTitle2").gameObject.GetComponent<Text>();
        Title3Image = GameObject.Find("Canvas").transform.Find("Shops").transform.Find("Shop3").transform.Find("ShopTitle3").gameObject.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (node != null)
        {
            Debug.Log(node[0]);
            Title1Image.text = node[0]["name"].Value;
            Title2Image.text = node[1]["name"].Value;
            Title3Image.text = node[2]["name"].Value;
            GameObject.Find("Canvas").transform.Find("Shops").gameObject.SetActive(true);
            StartCoroutine(FetchImage());
        }
    }
    public void OnSearchShopPressed()
    {
        Debug.Log("searchShopPressed");
        StartCoroutine(GetShop());
    }
    IEnumerator FetchImage()
    {
        WWW www = new WWW(node[0]["image"].Value);
        yield return www;
        Shop1Image.texture = www.texture;
        www = new WWW(node[1]["image"].Value);
        yield return www;
        Shop2Image.texture = www.texture;
        www = new WWW(node[2]["image"].Value);
        yield return www;
        Shop3Image.texture = www.texture;
    }
    IEnumerator GetShop()
    {
        using (UnityWebRequest www = UnityWebRequest.Get(getServer + type))
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
                Debug.Log(www.downloadHandler.data);
                Debug.Log(JSON.Parse(www.downloadHandler.text)[0]["name"].Value);
                node = JSON.Parse(www.downloadHandler.text);
            }
        }
    }
    public void OnBackPressed()
    {
        SceneManager.LoadScene("HomeScene", LoadSceneMode.Single);
    }
}
