using System.Collections;

using UnityEngine;

public class ButtonDontSomething : MonoBehaviour
{
    public bool isLose;
    // Start is called before the first frame update
    void OnEnable()
    {
        isLose = true;
        StartCoroutine(Peset());
    }

    // Update is called once per frame
    IEnumerator Peset()
    {
        yield return new WaitForSeconds(3f);
        
        isLose = false;
        this.enabled = false;
    }
}
