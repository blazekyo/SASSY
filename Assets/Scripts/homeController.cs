using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class homeController : MonoBehaviour {
    public bool shopOn = false;
    public bool locationOn = false;
    public bool carparkOn = false;
    private int currentMall = 1;
    public float currentAlpha = 1;
    public bool fadeDirection = true;
    public float speed;

    private int menuBackY = 0;
    private int locationY = -195;
    private int carparkY = -280;
    private float systemCumulatedTime;

    //objects
    private GameObject MenuBack;
    private GameObject SubBtn1;
    private GameObject SubBtn2;
    private GameObject SubBtn3;
    private GameObject SubBtn4;
    private GameObject SubBtn5;
    private GameObject Mall1;
    private GameObject Mall2;
    private GameObject Mall3;
    private GameObject Mall4;
    // Use this for initialization
    void Start () {
        MenuBack = GameObject.Find("SubList").transform.Find("MenuBack").gameObject;
        SubBtn1 = GameObject.Find("SubList").transform.Find("SubBtn1").gameObject;
        SubBtn2 = GameObject.Find("SubList").transform.Find("SubBtn2").gameObject;
        SubBtn3 = GameObject.Find("SubList").transform.Find("SubBtn3").gameObject;
        SubBtn4 = GameObject.Find("SubList").transform.Find("SubBtn4").gameObject;
        SubBtn5 = GameObject.Find("SubList").transform.Find("SubBtn5").gameObject;

        Mall1 = GameObject.Find("Preview").transform.Find("Mall1").gameObject;
        Mall2 = GameObject.Find("Preview").transform.Find("Mall2").gameObject;
        Mall3 = GameObject.Find("Preview").transform.Find("Mall3").gameObject;
        Mall4 = GameObject.Find("Preview").transform.Find("Mall4").gameObject;
    }
	
	// Update is called once per frame
	void Update () {
		switch(shopOn)
        {
            case true:
                menuBackY = 0;
                locationY = -595;
                carparkY = -680;
                MenuBack.SetActive(true);
                SubBtn1.SetActive(true);
                SubBtn2.SetActive(true);
                SubBtn3.SetActive(false);
                SubBtn4.SetActive(false);
                SubBtn5.SetActive(false);
                break; 
        }
        switch (locationOn)
        {
            case true:
                menuBackY = -80;
                locationY = -195;
                carparkY = -680;
                MenuBack.SetActive(false);
                SubBtn1.SetActive(false);
                SubBtn2.SetActive(false);
                SubBtn3.SetActive(true);
                SubBtn4.SetActive(false);
                SubBtn5.SetActive(false);
                break;
        }
        switch (carparkOn)
        {
            case true:
                menuBackY = -170;
                locationY = -195;
                carparkY = -280;
                MenuBack.SetActive(false);
                SubBtn1.SetActive(false);
                SubBtn2.SetActive(false);
                SubBtn3.SetActive(false);
                SubBtn4.SetActive(true);
                SubBtn5.SetActive(true);
                break;
        }
        GameObject.Find("TitleRow2").GetComponent<RectTransform>().anchoredPosition = new Vector2(
            GameObject.Find("TitleRow2").GetComponent<RectTransform>().anchoredPosition.x,
            locationY
            );
        GameObject.Find("TitleRow3").GetComponent<RectTransform>().anchoredPosition = new Vector2(
            GameObject.Find("TitleRow3").GetComponent<RectTransform>().anchoredPosition.x,
            carparkY
            );
        MenuBack.GetComponent<RectTransform>().anchoredPosition = new Vector2(
            MenuBack.GetComponent<RectTransform>().anchoredPosition.x,
            carparkY
            );
        systemCumulatedTime += Time.deltaTime;
        if (systemCumulatedTime >= 5)
        {
            if (currentMall != 4)
                currentMall++;
            else
                currentMall = 1;
            systemCumulatedTime = 0;
        }
        FlashMall();
    }
    public void OnShopClicked()
    {
        if (shopOn)
        {
            shopOn = false;
        }
        else
        {
            shopOn = true;
            locationOn = false;
            carparkOn = false;
        }
    }
    public void OnLocationClicked()
    {
        if (locationOn)
        {
            locationOn = false;
        }
        else {
            locationOn = true;
            shopOn = false;
            carparkOn = false;
        }
    }
    public void OnCarparkClicked()
    {
        if (carparkOn)
        {
            carparkOn = false;
        }
        else {
            carparkOn = true;
            locationOn = false;
            shopOn = false;
        }
    }
    public void FlashMall()
    {
        switch(currentMall)
        {
            case 1:
                Mall1.GetComponent<RawImage>().color = Color.Lerp(new Color(1, 1, 1, 1), new Color(1, 1, 1, 0), Mathf.PingPong(Time.time*0.3f, 1));
                Mall1.SetActive(true);
                Mall2.SetActive(false);
                Mall3.SetActive(false);
                Mall4.SetActive(false);
                break;
            case 2:
                Mall2.GetComponent<RawImage>().color = Color.Lerp(new Color(1, 1, 1, 1), new Color(1, 1, 1, 0), Mathf.PingPong(Time.time * 0.3f, 1));
                Mall1.SetActive(false);
                Mall2.SetActive(true);
                Mall3.SetActive(false);
                Mall4.SetActive(false);
                break;
            case 3:
                Mall3.GetComponent<RawImage>().color = Color.Lerp(new Color(1, 1, 1, 1), new Color(1, 1, 1, 0), Mathf.PingPong(Time.time * 0.3f, 1));
                Mall1.SetActive(false);
                Mall2.SetActive(false);
                Mall3.SetActive(true);
                Mall4.SetActive(false);
                break;
            case 4:
                Mall4.GetComponent<RawImage>().color = Color.Lerp(new Color(1, 1, 1, 1), new Color(1, 1, 1, 0), Mathf.PingPong(Time.time * 0.3f, 1));
                Mall1.SetActive(false);
                Mall2.SetActive(false);
                Mall3.SetActive(false);
                Mall4.SetActive(true);
                break;
        }
    }
    public void OnShopRecomendationClicked()
    {
        SceneManager.LoadScene("ShopRecomendationScene", LoadSceneMode.Single);
    }
    public void OnFindFashionClicked()
    {
        SceneManager.LoadScene("FindFashionScene", LoadSceneMode.Single);
    }
    public void OnTrackUserClicked()
    {
        SceneManager.LoadScene("TrackLocationScene", LoadSceneMode.Single);
    }
    public void OnCarparkBookingClicked()
    {
        SceneManager.LoadScene("BookCarparkScene", LoadSceneMode.Single);
    }
    public void OnCarFinderClicked()
    {
        SceneManager.LoadScene("FindCarScene", LoadSceneMode.Single);
    }
}
