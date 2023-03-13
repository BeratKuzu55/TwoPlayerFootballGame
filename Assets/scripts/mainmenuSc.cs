using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainmenuSc : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject optionsMenu , mainmenu;
    public bool kontrol;
    public int buildindex;
    GameObject result;
    bool result_kontrol = false;
    public void Start()
    {
       
       
        mainmenu = GameObject.Find("mainmenu");
    }


    public void Update()
    {
        if (GameObject.Find("result"))
        {
            result = GameObject.Find("result");
            result_kontrol = true;
            GameObject.Find("winner").GetComponent<TextMeshProUGUI>().text = result.GetComponent<resultsc>().result;
        }

    }

    public void startbutton()
    {
        if(result_kontrol)
        {
            Destroy(result);
        }
       
        SceneManager.LoadScene(0);
    }
  

    public void quitbutton()
    {
        Application.Quit();
    }


 
}
