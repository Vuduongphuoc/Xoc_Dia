    using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class RandomDice : MonoBehaviour
{

    public GameObject[] dices;

    [SerializeField] private Color[] colors;

    public GameObject[] evenButtons;
    public GameObject[] oddButtons;
    int w_count;
    int r_count;
    // Start is called before the first frame update
    void Start()
    {
        CheckColor();
        dices = GameObject.FindGameObjectsWithTag("Dice");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ChangeColor()
    {
        dices[0].GetComponent<Renderer>().material.color = colors[Random.Range(0, 2)];
        dices[1].GetComponent<Renderer>().material.color = colors[Random.Range(0, 2)];
        dices[2].GetComponent<Renderer>().material.color = colors[Random.Range(0, 2)];
        dices[3].GetComponent<Renderer>().material.color = colors[Random.Range(0, 2)];

    }
    
    public void CheckColor()
    {
        foreach (GameObject a in dices)
        {
            if (a.GetComponent<Renderer>().material.color == colors[0])
            {
                w_count++;
                Debug.Log(w_count);
                return;
            }
        }
    }

    public void ChangeBGEvenOrOdd()
    {
        if (w_count % 2 == 0 && r_count % 2 == 0)
        {
            oddButtons[0].GetComponent<Renderer>().material.color = Color.blue;
            oddButtons[1].GetComponent<Renderer>().material.color = Color.blue;
            oddButtons[2].GetComponent<Renderer>().material.color = Color.blue;

            evenButtons[0].GetComponent<Renderer>().material.color = Color.green;
            evenButtons[1].GetComponent<Renderer>().material.color = Color.green;
            evenButtons[2].GetComponent<Renderer>().material.color = Color.green;
        }
        else if (w_count % 2 != 0 && r_count % 2 !=0  )
        {
            oddButtons[0].GetComponent<Renderer>().material.color = Color.green;
            oddButtons[1].GetComponent<Renderer>().material.color = Color.green;
            oddButtons[2].GetComponent<Renderer>().material.color = Color.green;

            evenButtons[0].GetComponent<Renderer>().material.color = Color.blue;
            evenButtons[1].GetComponent<Renderer>().material.color = Color.blue;
            evenButtons[2].GetComponent<Renderer>().material.color = Color.blue;
        }
    }
}                //else if (w_count == 1 && w_count == 3)
                //{
                //    oddButtons[0].GetComponent<Renderer>().material.color = Color.green;
                //    oddButtons[1].GetComponent<Renderer>().material.color = Color.green;
                //    oddButtons[2].GetComponent<Renderer>().material.color = Color.green;

                //    evenButtons[0].GetComponent<Renderer>().material.color = Color.blue;
                //    evenButtons[1].GetComponent<Renderer>().material.color = Color.blue;
                //    evenButtons[2].GetComponent<Renderer>().material.color = Color.blue;
                //    Debug.Log(w_count + "White");
                //    return;
                //}
 
