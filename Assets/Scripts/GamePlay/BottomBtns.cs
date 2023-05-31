
using UnityEngine;

public class BottomBtns : MonoBehaviour
{
    public GameObject wheelDaily;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void wheel()
    {
        wheelDaily.SetActive(true);
    }
    public void exitWheel()
    {
        wheelDaily.SetActive(false);
    }
}
