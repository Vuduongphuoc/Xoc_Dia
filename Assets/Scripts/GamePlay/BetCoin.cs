using System.Collections;
using UnityEngine;

public class BetCoin : MonoBehaviour
{
    [SerializeField] Transform[] BetPlace;
    private float speed;

    public ButtonDoSomething btn;
    public ButtonDontSomething btned;

    public GameObject player;
    public GameObject host;
    Transform nextpos;

    // Start is called before the first frame update
    private void Awake()
    {
        speed = 140f;
    }
    void Start()
    { 
        nextpos = BetPlace[BetSystem.btnid];
    }

    // Update is called once per frame
    void Update()
    {
        if(!RandomDice.Instance.inCountDown)
        {
            btn = GetComponentInParent<ButtonDoSomething>();
            btned = GetComponentInParent<ButtonDontSomething>();
            StartCoroutine(DelayResult());
            if (btn.isWin)
            {
               transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
                
            }
            else if(btned.isLose)
            {
                transform.position = Vector3.MoveTowards(transform.position, host.transform.position, speed * Time.deltaTime);
                
            }
            StartCoroutine(Disable());
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, nextpos.position, speed * Time.deltaTime);
            setParent();

        }
    }
    public void setParent()
    {
        transform.SetParent(nextpos);
    }
    IEnumerator Disable()
    {
        yield return new WaitForSeconds(1f);
        gameObject.SetActive(false);
    }
    IEnumerator DelayResult()
    {
        yield return new WaitForSeconds(5f);
    }
    
}
