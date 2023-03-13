using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class optionsmenuSc : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject mainmenu;
    mainmenuSc mainmenu_sc;
    void Start()
    {

    }

    public void backbutton()
    {
        SceneManager.LoadScene(1);
        print("kontroll");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
