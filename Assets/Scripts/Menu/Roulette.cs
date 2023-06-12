using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roulette : MonoBehaviour
{
    public float rotatePower;
    public float stopPower;

    Rigidbody2D rbody;
    int inRotate;
    float t;

    // Start is called before the first frame update
    void Start()
    {
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
            Win(200);
        }
        else if(rot > 45+22 && rot <= 90+22)
        {
            Win(300);
        }
        else if (rot > 90 + 22 && rot <= 135 + 22)
        {
            Win(400);
        }
        else if (rot > 135 + 22 && rot <= 180 + 22)
        {
            Win(500);
        }
        else if (rot > 180 + 22 && rot <= 225 + 22)
        {
            Win(600);
        }
        else if (rot > 225 + 22 && rot <= 270 + 22)
        {
            Win(700);
        }
        else if (rot > 270 + 22 && rot <= 315 + 22)
        {
            Win(800);
        }
        else if (rot > 315 + 22 && rot <= 360 + 22)
        {
            Win(100);
        }
    }
    public void Win(int Score)
    {
        Debug.Log(Score);
    }
}
