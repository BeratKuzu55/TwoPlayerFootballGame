using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerRed_sc : MonoBehaviour
{
    bool kontrol , vurus_yapildi_mi;
    // Start is called before the first frame update
    void Start()
    {
        kontrol = false;
        vurus_yapildi_mi = false;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetAxis("Vertical") >= 0.1f)
        {
           // transform.position += new Vector3( 0f, 0f , -0.05f);
            transform.GetComponent<Rigidbody>().AddForce(new Vector3(0f, 0.0f, -5.1f), ForceMode.Force);
        }
        else if (Input.GetAxis("Vertical") <= -0.1f)
        {
            //transform.position += new Vector3(0f, 0f, 0.05f);
            transform.GetComponent<Rigidbody>().AddForce(new Vector3(0f, 0f, 5.1f), ForceMode.Force);
        }

        if (Input.GetAxis("Horizontal") >= 0.1f)
        {
            //transform.position += new Vector3(-0.05f, 0f, 0f);
            transform.GetComponent<Rigidbody>().AddForce(new Vector3(-5.1f, 0f, 0f), ForceMode.Force);
        }
        else if (Input.GetAxis("Horizontal") <= -0.1)
        {
            //transform.position += new Vector3(0.05f, 0f, 0f);
            transform.GetComponent<Rigidbody>().AddForce(new Vector3(5.1f, 0f, 0f), ForceMode.Force);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("ozelGuc"))
        {
            other.gameObject.SetActive(false);
            //other.transform.SetParent(this.transform);
            Destroy(other);
            StartCoroutine(yeni_ozel_guc());
           
            float random_power_desicion = Random.Range(0f , 2.1f);
            print("ozelguc : " + random_power_desicion);
            if(random_power_desicion <= 1.0f)
            {
                StartCoroutine(besKisiOl());
            }
            else
            {
                kontrol = true;
                StartCoroutine(kaleyeVurus());
            }
                    
        }
    }


    IEnumerator yeni_ozel_guc()
    {
        yield return new WaitForSeconds(40f);
        GameObject.Find("ball").GetComponent<ball_sc>().is_there_any = false;
    }

    IEnumerator kaleyeVurus()
    {
        yield return new WaitForSeconds(30f);
        kontrol = false;
    }


    // kalenin konum vektorunden topun konum vektorunu cýkartalým 
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag.Equals("ball") && kontrol)
        {
            Vector3 topa_vurus_vektoru = GameObject.Find("goalRight").transform.position - GameObject.Find("ball").transform.position;
            GameObject.Find("ball").GetComponent<Rigidbody>().AddForce( topa_vurus_vektoru * 10, ForceMode.Force);
            kontrol = false;
        }
    }

    IEnumerator besKisiOl()
    {
        GameObject clone_player = Instantiate(this.gameObject, new Vector3(transform.position.x , transform.position.y , transform.position.z + 1.5f), Quaternion.identity);
        GameObject clone_player2 = Instantiate(this.gameObject, new Vector3(transform.position.x, transform.position.y, transform.position.z - 0.5f), Quaternion.identity);
        GameObject clone_player3 = Instantiate(this.gameObject, new Vector3(transform.position.x, transform.position.y, transform.position.z + 0.5f), Quaternion.identity);
        GameObject clone_player4 = Instantiate(this.gameObject, new Vector3(transform.position.x, transform.position.y, transform.position.z - 1.5f), Quaternion.identity);
        yield return new WaitForSeconds(10f);
        Destroy(clone_player); Destroy(clone_player2); Destroy(clone_player3); Destroy(clone_player4);
    }
}
