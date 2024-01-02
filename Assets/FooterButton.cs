using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class FooterButton : MonoBehaviour
{
    public Sprite[] active;
    public Sprite[] notActive;

    public Image[] image;
    private void Start()
    {
        Page page = SingletonManager.Instance.currentPage;

        switch (page)         
        {
            case Page.profile:
                image[0].sprite = active[0];
                image[1].sprite = notActive[1];
                image[2].sprite = notActive[2];
                image[3].sprite = notActive[3];
                break;
            case Page.tools:
                image[1].sprite = active[1];
                image[0].sprite = notActive[0];
                image[2].sprite = notActive[2];
                image[3].sprite = notActive[3];
                break;
            case Page.draw:
                image[2].sprite = active[2];
                image[1].sprite = notActive[1];
                image[0].sprite = notActive[0];
                image[3].sprite = notActive[3];
                break;
            case Page.pustaka:
                image[3].sprite = active[3];
                image[1].sprite = notActive[1];
                image[2].sprite = notActive[2];
                image[0].sprite = notActive[0];
                break;
            default:    
                break;
        }

    }
    public void ChangeScene(int index)
    {
        Page page;
        switch (index)
        {
            case 2:
                page = Page.tools;
                break;

            case 8:
                page = Page.draw;
                break;

            case 10:
                page = Page.pustaka;
                break;
            default:
                page = Page.profile;
                break;
        }
        SingletonManager.Instance.currentPage = page;
        StaticSceneChanger.ChangeScene(index);

    }
}

public enum Page
{
    profile, tools, draw, pustaka
}
