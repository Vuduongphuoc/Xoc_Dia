using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CountDownTimer : MonoBehaviour
{
    float countdownTime;
    public GameObject countdownDisplay;
    public GameObject[] btnDisable;
    // Start is called before the first frame update
    void Start()
    {
        countdownDisplay.SetActive(false);
        StartCoroutine(TimeCountDown());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator TimeCountDown()
    {
        //Time count downs
        countdownTime = 10f;
        countdownDisplay.SetActive(true);
        while (countdownTime >= 0)
        {
            countdownDisplay.GetComponent<Text>().text = countdownTime.ToString();
            yield return new WaitForSeconds(1f);
            countdownTime--;
        }
        
        countdownDisplay.SetActive(false);
        yield return new WaitForSeconds(0.5f);

        //Disable buttons before result

        for (int i = 0; i < btnDisable.Length; i++)
        {
            btnDisable[i].GetComponent<Button>().enabled = false;
        }
        //
        yield return new WaitForSeconds(0.7f);
    }
}
