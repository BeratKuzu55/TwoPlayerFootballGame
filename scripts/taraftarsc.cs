using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class taraftarsc : MonoBehaviour
{
    GameObject right_arm;
    // Start is called before the first frame update
    void Start()
    {
        right_arm = GameObject.Find("RightArm");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator gol_sevinci()
    {
        yield return new WaitForSeconds(0.2f); 
        //right_arm.transform.rotation
    }
}
