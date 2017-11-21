﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitlePage : Page
{
    [SerializeField]
    List<Button> lstButton;
    [SerializeField]
    List<Sprite> lstSprite;

    [SerializeField]
    GameObject dialog;
    [SerializeField]
    TextPic txtTerm;

    string iosID;
    string androidID;

    void OnEnable (){
        PageData.Initialize ();
        androidID = "com.google.android.apps.maps";
        iosID = "google-maps-gps-navigation/id585027354?mt=8";

        if (ApplicationLogic.IsShowTermLimitedYokai())
        {
            dialog.SetActive(true);

            txtTerm.text = ApplicationData.GetLocaleText(LocaleType.TermLimitedYokai);

        }
        else
        {
            dialog.SetActive(false);
        }
    }

    public void EnableBluetooth ()
    {
        BluetoothState.EnableBluetooth ();
    }

    void DisalbeButton(string name)
    {
        List<Button> lstTemp = lstButton.FindAll(x => x.name != name);
        Button bt = lstButton.Find(x => x.name == name);
        Color myGray = new Color();
        ColorUtility.TryParseHtmlString("#9C9C9CFF", out myGray);
        bt.GetComponentInChildren<Text>().color = Color.black;
        bt.image.sprite = lstSprite[1];
        foreach (var item in lstTemp)
        {
            item.image.sprite = lstSprite[2];
            item.GetComponentInChildren<Text>().color = myGray;
        }
    }

    public void SelectEnglish()
    {
        ApplicationData.SelectedLanguage = LanguageType.English;
        DisalbeButton("btEnglish");
    }
    public void SelectJapanese()
    {
        ApplicationData.SelectedLanguage = LanguageType.Japanese;
        DisalbeButton("btJapanese");
    }
    public void SelectChinese1()
    {
        ApplicationData.SelectedLanguage = LanguageType.Chinese1;
        DisalbeButton("btChinese");
    }
    public void SelectChinese2()
    {
        ApplicationData.SelectedLanguage = LanguageType.Chinese2;
        DisalbeButton("btChinese2");
    }
    public void SelectThai()
    {
        ApplicationData.SelectedLanguage = LanguageType.Thai;
        DisalbeButton("btThai");
    }

    public void OpenURL()
    {
#if UNITY_ANDROID
        //Application.OpenURL("market://details?id="+androidID);
        Application.OpenURL("esashinavi://");
#elif UNITY_IOS
        //Application.OpenURL("itms-apps://itunes.apple.com/app/"+iosID);
        Application.OpenURL("esashinavi://");
#endif
    }
}