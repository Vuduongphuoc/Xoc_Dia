using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BetCoin : MonoBehaviour
{
    
    [SerializeField] Transform[] BetPlace;
    
    private float speed;

    Transform nextpos;
    // Start is called before the first frame update
    void Start()
    {
        speed = 40f;
        nextpos = BetPlace[BetSystem.btnid];
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, nextpos.position, speed * Time.deltaTime);

        StartCoroutine(RoundEnd());
    }
    public void SetParent()
    {
        gameObject.transform.SetParent(BetPlace[BetSystem.btnid]);
    }
    IEnumerator RoundEnd()
    {
        yield return new WaitForSeconds(10.5f);
        gameObject.GetComponent<CenterState>().enabled = true;
        SetParent();
        yield return new WaitForSeconds(0.5f);
        gameObject.GetComponent<BetCoin>().enabled = false;

    }


}
