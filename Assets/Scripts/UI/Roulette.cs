using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Roulette : MonoBehaviour
{
    public static Roulette instance;

    public float rotatePower;
    public float stopPower;

    public CoinsSystem coinsSystem;
    Rigidbody2D rbody;
    int inRotate;
    float t;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        CoinsSystem.moneyValue = PlayerPrefs.GetInt("money");
        rbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(rbody.angularVelocity > 0)
        {
            rbody.angularVelocity -= stopPower*Time.deltaTime;
            rbody.angularVelocity = Mathf.Clamp(rbody.angularVelocity, 0, 1440);
        }
        if(rbody.angularVelocity == 0 && inRotate == 1)
        {
            t += 1 * Time.deltaTime;
            if(t >= 0.5f)
            {
                GetReward();

                inRotate = 0;
                t = 0;
            }
        }
    }

    public void Rotete()
    {
        if(inRotate == 0)
        {
            rbody.AddTorque(rotatePower);
            inRotate = 1;

        }
    }

    public void GetReward()
    {
        float rot = transform.eulerAngles.z;

        if (rot > 0+22 && rot <= 45+22)
        {
            Present.instance.reward = 200;
            StartCoroutine(Present.instance.GiftGet());
            CoinsSystem.moneyValue += 200;
            UpdateMoney();
        }
        else if(rot > 45+22 && rot <= 90+22)
        {
            Present.instance.reward = 400;
            StartCoroutine(Present.instance.GiftGet());
            CoinsSystem.moneyValue += 400;

            UpdateMoney();
        }
        else if (rot > 90 + 22 && rot <= 135 + 22)
        {
            Present.instance.reward = 600;
            StartCoroutine(Present.instance.GiftGet());
            CoinsSystem.moneyValue += 600;
            UpdateMoney();
        }
        else if (rot > 135 + 22 && rot <= 180 + 22)
        {
            Present.instance.reward = 800;
            StartCoroutine(Present.instance.GiftGet());
            CoinsSystem.moneyValue += 800;
            UpdateMoney();
        }
        else if (rot > 180 + 22 && rot <= 225 + 22)
        {
            Present.instance.reward = 1000;
            StartCoroutine(Present.instance.GiftGet());
            CoinsSystem.moneyValue += 1000;
            UpdateMoney();
        }
        else if (rot > 225 + 22 && rot <= 270 + 22)
        {
            Present.instance.reward = 1500;
            StartCoroutine(Present.instance.GiftGet());
            CoinsSystem.moneyValue += 1500;
            UpdateMoney();
        }
        else if (rot > 270 + 22 && rot <= 315 + 22)
        {
            Present.instance.reward = 2000;
            StartCoroutine(Present.instance.GiftGet());
            CoinsSystem.moneyValue += 2000;
            UpdateMoney();
        }
        else if (rot > 315 + 22 && rot <= 360 + 22)
        {
            Present.instance.reward = 3000;
            StartCoroutine(Present.instance.GiftGet());
            CoinsSystem.moneyValue += 3000;
            UpdateMoney();
        }
    }
    public void UpdateMoney()
    {
        PlayerPrefs.SetInt("money",CoinsSystem.moneyValue);
        coinsSystem.menuMoneyDisplay.text = " $ " + CoinsSystem.moneyValue;
    }
}
