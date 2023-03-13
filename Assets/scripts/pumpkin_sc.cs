using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pumpkin_sc : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag.Equals("ball"))
        {
            collision.gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(Random.Range(-100f, 0f), 0, Random.Range(0f, 100f)) , ForceMode.Force);
        }
    }
}
