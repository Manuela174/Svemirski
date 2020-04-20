using System.Collections;
using UnityEngine;
public class PonasanjeNeprijatelja : MonoBehaviour
{
    public GameObject projektil;
    public float snaga = 150;
    public float PucanjuSekundi = 4f;
    public float brzinaProjektila = 10;
    public int rezultatValue = 150;
    private PrikazRezultata prikazRezultata;
    public AudioClip zvukPucnja;
    public AudioClip zvukUnistenja;


    void Start()
    {
        prikazRezultata = GameObject.Find("Rezultat").GetComponent<PrikazRezultata>();
    }
void Update()
    {
        float vjerojatnost = PucanjuSekundi * Time.deltaTime; if (Random.value < vjerojatnost)
        {
            Fire();
        }
    }
void Fire()
    {
        Vector3 offset = new Vector3(0, -1.0f, 0);
        Vector3 polozajpucnja = transform.position + offset;
        GameObject missile = Instantiate(projektil, polozajpucnja, Quaternion.identity) as GameObject;
        missile.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -brzinaProjektila);
        AudioSource.PlayClipAtPoint(zvukPucnja, transform.position);
    }

void Die()
    {
        prikazRezultata.Rezultat(rezultatValue);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Projektil missle = collision.gameObject.GetComponent<Projektil>();
        if (missle) { missle.Hit();
            snaga -= missle.GetDamange();
            if (snaga <= 0)
            {
                AudioSource.PlayClipAtPoint(zvukUnistenja, transform.position);
            
                Die();
            }
        }
    }


}


