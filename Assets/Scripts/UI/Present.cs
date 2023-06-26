using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Present : MonoBehaviour
{
    public static Present instance;
    public GameObject giftpanel;
    public Text gifttxt;

    public int reward;
    // Start is called before the first frame update
    void Start()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    // Update is called once per frame
    public IEnumerator GiftGet()
    {
        giftpanel.SetActive(true);
        gifttxt.text = " +" + reward;
        yield return new WaitForSeconds(1.5f);
        giftpanel.SetActive(false);
        reward = 0;
    }
}
