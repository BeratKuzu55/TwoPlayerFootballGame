using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class resultsc : MonoBehaviour
{
    public string result;
    ball_sc ball_script;
    // Start is called before the first frame update
    void Start()
    {
      
       
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("ball"))
        {
            ball_script = GameObject.Find("ball").GetComponent<ball_sc>();
            result = ball_script.kazanan;
            print("result :" + result);
        }
        DontDestroyOnLoad(gameObject);
    }
}
