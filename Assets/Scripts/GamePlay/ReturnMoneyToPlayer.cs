using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnMoneyToPlayer : MonoBehaviour
{
   
    private float speed;
    public GameObject host;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        speed = 40f;
    }

    // Update is called once per frame
    void Update()
    {
        MoveToPlayer();
    }
    void MoveToPlayer()
    {
        if (CoinsSystem.realmoneyPlayerGet >= 0)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        }
        else if (CoinsSystem.realmoneyPlayerGet < 0)
        {
            transform.position = Vector3.MoveTowards(transform.position, host.transform.position, speed * Time.deltaTime);
        }
        StartCoroutine(DestroyOnEnter());
    }
    IEnumerator DestroyOnEnter()
    {
        yield return new WaitForSeconds(1.5f);
        Destroy(gameObject);
    }
}
