using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using LukeWaffel.AndroidGallery;

public class BrowseAndroid : MonoBehaviour {
    public Sprite attireImage;
    private void Start()
    {
        attireImage = Resources.Load("Graphics/defaultAttire", typeof(Sprite)) as Sprite;
    }
    // Update is called once per frame
    void Update()
    {
        this.GetComponent<Image>().sprite = attireImage;
    }
    public void SelectAttire()
    {
        Debug.Log("adb:" + "its loading!");
        AndroidGallery.Instance.OpenGallery(attire);
    }
    private void attire()
    {
        Debug.Log("adb:" + "its loaded!");
        attireImage = AndroidGallery.Instance.GetSprite();
    }
}
