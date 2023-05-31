using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnMoneyToPlayer : MonoBehaviour
{
   
    private float speed;
    public GameObject host;
    public GameObject player;

    public RandomDice betButtons;

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
        if (betButtons)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        }
        else if(!betButtons)
        {
            transform.position = Vector3.MoveTowards(transform.position, host.transform.position, speed * Time.deltaTime); 
        }
        
        StartCoroutine(DestroyOnEnter());
        return;
    }
    IEnumerator DestroyOnEnter()
    {
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }
}
