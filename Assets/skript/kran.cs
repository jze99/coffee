using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class kran : MonoBehaviour
{
    public static kran k;
    GameObject tura;
    Slider slider5;
    bool n;
    bool poliv;
    float taim;
    private void Awake()
    {
        
    }
    public void on_off()
    {
        if (n==true)
        {
            gameObject.GetComponent<Animator>().Play("off");
            n = false;
        }
        else if (n==false)
        {
            gameObject.GetComponent<Animator>().Play("on");
            n = true;
        }
    }
    private void Update()
    {
        if (poliv==true)
        {
            taim += Time.deltaTime;
            if (taim == 5)
            {
                tura.GetComponent<id>().predmet_isp = 3;
                taim = 0;
                poliv = false;
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<id>().predmet_isp == 2&&poliv==false)
        {
            poliv = true;
            tura = other.gameObject;
        }
    }
}
