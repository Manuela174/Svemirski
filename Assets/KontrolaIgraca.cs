using UnityEngine;
using System.Collections; 

public class KontrolaIgraca: MonoBehaviour
{
    public float speed = 15.0f;
    float xmin;
    float xmax;
    public GameObject projektil;
    public float brzinaProjektila;
    public float snaga = 250f;
    public AudioClip zvukPucnja;


    void OnTriggerEnter2D(Collider2D collider)
    {
        
        Projektil missile = collider.gameObject.GetComponent<Projektil>();
        if (missile)
        {
            snaga -= missile.GetDamage();
            missile.Hit(); if (snaga <= 0)
            {
                Die();
            }
        }
        if (snaga <= 0)
        {
            Die();
        }
    }
    void Die()
    {
        LevelManager man = GameObject.Find("LevelManager").GetComponent<LevelManager>();
        man.LoadLevel("Win");
        Die();
    }




    void Start()
    {
        float distance = transform.position.z - Camera.main.transform.position.z;
        Vector3 krajnjelijevo = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distance));
        Vector3 krajnjedesno = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, distance));
        xmin = krajnjelijevo.x; xmax = krajnjedesno.x; }
void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            GameObject laser = Instantiate(projektil, transform.position, Quaternion.identity) as GameObject;
            laser.GetComponent<Rigidbody2D>().velocity = new Vector3(0, brzinaProjektila, 0);
            AudioSource.PlayClipAtPoint(zvukPucnja, transform.position);
        }
        if (Input.GetKey(KeyCode.LeftArrow)) { transform.position += Vector3.left * speed * Time.deltaTime;
        }
        else if(Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
        } 
        // Ograničava kretanje Svemirskog broda izvan scene

        float newX = Mathf.Clamp(transform.position.x, xmin, xmax);
        transform.position = new Vector3(newX, transform.position.y, transform.position.z);
    }
}