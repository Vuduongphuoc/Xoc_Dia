using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CenterState : MonoBehaviour
{
    public GameObject center;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(ResultState());
    }
    IEnumerator ResultState()
    {
        yield return new WaitForSeconds(1f);
        gameObject.GetComponent<ReturnMoneyToPlayer>().enabled = true;
   
        yield return new WaitForSeconds(0.2f);
        gameObject.GetComponent<CenterState>().enabled = false;
    }
}
