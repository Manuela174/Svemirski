using UnityEngine;
using UnityEngine.UI;
using System.Collections;
public class PrikazRezultata : MonoBehaviour
{
    public static int rezultat = 0;
    private Text myText; void Start()
    {
        myText = GetComponent<Text>();
        Reset();
    }
public void Rezultat(int points)
    {
        Debug.Log("Rezultat");
        rezultat += points;
        myText.text = rezultat.ToString();
    }
public static void Reset()
    {
        rezultat = 0;
    }
}