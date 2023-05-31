using System.Collections;

using UnityEngine;


public class ButtonDoSomething : MonoBehaviour
{
    public GameObject glowbutton;
    public bool isWin;
    // Start is called before the first frame update
  
    void OnEnable()
    {
        glowbutton.SetActive(true);
        isWin = true;
        StartCoroutine(Peset());
    }

    // Update is called once per frame
    IEnumerator Peset()
    {
        yield return new WaitForSeconds(3f);
        
        glowbutton.SetActive(false);
        
        isWin = false;
        this.enabled = false;
    }
    
}
