using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Avatar : MonoBehaviour
{
    public Image avt;
    public Image avtIngame;

    public Sprite[] newavt;

    public GameObject notification;

    public GameObject avatar;
    public GameObject avatarIngame;
    public GameObject avatarPanel;


    private void Start()
    {
       avt = avatar.GetComponent<Image>();
       avtIngame = avatarIngame.GetComponent<Image>();
       notification.SetActive(true);
    }

    public void ChoseAvatar(int id)
    {

        if(id == 0)
        {
            avt.sprite = newavt[0];
            avtIngame.sprite = newavt[0];
        }
        else if (id == 1)
        {
            avt.sprite = newavt[1];
            avtIngame.sprite = newavt[1];
        }
        else if (id == 2)
        {
            avt.sprite = newavt[2];
            avtIngame.sprite = newavt[2];
        }
        else if (id == 3)
        {
            avt.sprite = newavt[3];
            avtIngame.sprite = newavt[3];
        }
        else if (id == 4)
        {
            avt.sprite = newavt[4];
            avtIngame.sprite = newavt[4];
        }
        else if (id == 5)
        {
            avt.sprite = newavt[5];
            avtIngame.sprite= newavt[5];
        }
        else if (id == 6)
        {
            avt.sprite = newavt[6];
            avtIngame.sprite = newavt[6];
        }
        else if (id == 7)
        {
            avt.sprite = newavt[7];
            avtIngame.sprite = newavt[7];
        }
        else if (id == 8)
        {
            avt.sprite = newavt[8];
            avtIngame.sprite = newavt[8];
        }
        else if (id == 9)
        {
            avt.sprite = newavt[9];
            avtIngame.sprite = newavt[9];
        }
    }
    public void ConfirmAvt()
    {
        notification.SetActive(false);
        avatarPanel.SetActive(false);
    }
    public void OpenAvt()
    {
        avatarPanel.SetActive(true);
    }
    
}
