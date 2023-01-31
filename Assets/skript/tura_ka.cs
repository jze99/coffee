using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class tura_ka : MonoBehaviour
{
    public static tura_ka ka;
    public bool voda;
    public bool kofffe;//есть ли кофе в турке
    GameObject ray;
    GameObject Koffe_V_Kolaidore;
    Text Vid_Koffe;

    private void Awake()
    {
        Vid_Koffe = gameObject.transform.GetChild(0).GetChild(0).GetComponent<Text>();
        Vid_Koffe.gameObject.SetActive(false);
        ray = GameObject.Find("PlayerCamera");
    }
    private void FixedUpdate()
    {
        Vid_Koffe.transform.LookAt(ray.transform);
    }
    public void dobavi_coffe() 
    {
        Koffe_V_Kolaidore = GameObject.Find("PlayerCamera").GetComponent<ray>().play_object;
        if (Koffe_V_Kolaidore!=null&&Koffe_V_Kolaidore.GetComponent<id>().molot_ili_net==true&&kofffe==false)
        {
            switch (Koffe_V_Kolaidore.GetComponent<id>().vid_koffe)
            {
                case 1:
                    Vid_Koffe.gameObject.SetActive(true);
                    Vid_Koffe.text = "Arabika";
                    ray.GetComponent<ray>().delit();
                    kofffe = true;
                    break;
                case 2:
                    Vid_Koffe.gameObject.SetActive(true);
                    Vid_Koffe.text = "Liberika";
                    ray.GetComponent<ray>().delit();
                    kofffe = true;
                    break;
                default:
                    Vid_Koffe.gameObject.SetActive(false);
                    break;
            }

        }
    }
    
}
