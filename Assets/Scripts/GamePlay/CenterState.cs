using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CenterState : MonoBehaviour
{
    public RandomDice random;
    public GameObject center;
    private float speed;
    // Start is called before the first frame update
    void Start()
    {
        speed = 30f;
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(ResultState());
    }
    IEnumerator ResultState()
    {
        transform.position = Vector3.MoveTowards(transform.position, center.transform.position, speed * Time.deltaTime);
        yield return new WaitForSeconds(2f);
        gameObject.GetComponent<ReturnMoneyToPlayer>().enabled = true;
   
        yield return new WaitForSeconds(0.5f);
        gameObject.GetComponent<CenterState>().enabled = false;
    }
}
