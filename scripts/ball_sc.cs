using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ball_sc : MonoBehaviour
{
    int score_blue, score_red;
    GameObject ScoreRedObject , ScoreBlueObject , sureObject;
    public float sure = 300;
    float dakika = 2;
    float saniye = 60;
    float ozelguc_x, ozelguc_z;
    public bool is_there_any = false;
    int clone_count;
    public string kazanan;
    // Start is called before the first frame update
    Rigidbody Rb;
    [SerializeField] Vector3 top_hizi;
    void Start()
    {
        ScoreRedObject = GameObject.Find("score_red");
        ScoreBlueObject = GameObject.Find("score_blue");
        sureObject = GameObject.Find("sure");
        score_blue = 0; score_red = 0;
        Rb = transform.GetComponent<Rigidbody>();
        top_hizi = Rb.velocity;
        clone_count = 0;
    }

    // Update is called once per frame
    void Update()
    {
        sure -= Time.deltaTime;
        saniye -= Time.deltaTime;
        if(saniye <= 0.5f)
        {
            dakika--;
            saniye = 60f;
            if(dakika < 0)
            {
                kazanan = score_red > score_blue ? "red wins" : (score_red < score_blue ? "blue wins" : "Scoreless");
                
                SceneManager.LoadScene("OyunSonu");
            }
        }
        
        if (!is_there_any)
        {
            is_there_any = true;
            createOzelGuc();
        }
        sureObject.GetComponent<TextMeshProUGUI>().text = "sure" + dakika + ": " + Mathf.Ceil(saniye).ToString();
        if(transform.position.x > 11.85 && transform.position.z < 3  && transform.position.z > -3)
        {
            //createOzelGuc(clone_count);
            transform.position = new Vector3( 0, transform.position.y, 0);
            Rb.velocity = Vector3.zero;
            Rb.angularVelocity = Vector3.zero;
            score_blue++;
            ScoreBlueObject.GetComponent<TextMeshProUGUI>().text = "blue:" + score_blue.ToString();
            //GameObject clone_red_player = Instantiate(GameObject.Find("SoccerPlayerRed"), new Vector3(1f, 0f, 1f), Quaternion.identity);
            //clone_ozelGuc = Instantiate(GameObject.Find("ozelGuc"), new Vector3(1, 2f, 1), Quaternion.identity);   
        }
        else if(transform.position.x < -12.35 && transform.position.z < 3 && transform.position.z > -3)
        {
            transform.position = new Vector3(0, transform.position.y, 0);
            Rb.velocity = Vector3.zero;
            Rb.angularVelocity = Vector3.zero;
            score_red++;    
            ScoreRedObject.GetComponent<TextMeshProUGUI>().text = "red:" + score_red.ToString();
        }
    }

    void createOzelGuc()
    {
        ozelguc_x = Random.Range(-5f, 5f);
        float a = Random.Range(0, 2);
        print("a : " + a);
        ozelguc_z = a <= 1f ? Mathf.Sqrt(25 - Mathf.Pow(ozelguc_x, 2)) : -Mathf.Sqrt(25 - Mathf.Pow(ozelguc_x, 2));
        print("ozel guc z coordinate : " + ozelguc_z);
        GameObject clone_ozelGuc = Instantiate(GameObject.Find("ozelGuc"), new Vector3(ozelguc_x, 2f, ozelguc_z), Quaternion.identity);
        print(clone_count);
    }

    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag.Equals("altduvar"))
        {
            this.GetComponent<Rigidbody>().AddForce(new Vector3(0, 0, Random.Range(-25f, -20f)));
            print("altduvar temas");
        }
        else if (collision.transform.tag.Equals("ustduvar"))
        {
            print("ust duvar temas");
            this.GetComponent<Rigidbody>().AddForce(new Vector3(0, 0, Random.Range(20f, 25f)));
        }
    }
}
