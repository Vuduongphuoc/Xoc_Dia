
using UnityEngine;
using UnityEngine.UI;

public class LoadingScene : MonoBehaviour
{
    public GameObject loadingScreen;
    public GameObject menuScreen;
    public Image loadingBarFill;
    public bool isLoad;
    void Start()
    {
        loadingScreen.SetActive(true);
        isLoad = true;
    }
    void Update()
    {
        if (isLoad)
        {
            loadingBarFill.fillAmount += 0.2f * Time.deltaTime;
            if(loadingBarFill.fillAmount == 1)
            {
                isLoad = false;
                loadingScreen.SetActive(false);
                menuScreen.SetActive(true);
                loadingBarFill.fillAmount = 0;
            }
            return;
        }   
    }

}
