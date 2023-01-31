using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class moloko : MonoBehaviour
{
    public static moloko mol;
    GameObject play_cmera;
    GameObject camera_game;
    GameObject molok;
    GameObject pena;
    bool cam;
    public Transform transform_kapucinator;
    Slider slider5;
    bool m;
    float vreme;

    private void Awake()
    {
        play_cmera = GameObject.Find("PlayerCamera");
        camera_game = gameObject.transform.GetChild(3).gameObject;
        camera_game.SetActive(false);
        transform_kapucinator = gameObject.transform.GetChild(2).GetChild(0).GetChild(2).GetChild(0).GetChild(0);
        slider5 = gameObject.transform.GetChild(2).GetChild(0).GetComponent<Slider>();
        molok = gameObject.transform.GetChild(0).gameObject;
        pena = gameObject.transform.GetChild(1).gameObject;
    }
    private void Update()
    {
        if (cam==true)
        {
            slider5.value -= Time.deltaTime*8;
            if (slider5.value>=70)
            {
                vreme += Time.deltaTime;
                if (vreme>=5)
                {
                    pena.SetActive(true);
                    molok.SetActive(false);
                }
            }
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                camera_game.SetActive(false);
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                play_cmera.GetComponent<ray>().play_object.transform.SetParent(play_cmera.transform.GetChild(0));
                play_cmera.GetComponent<ray>().play_object.transform.position = play_cmera.transform.GetChild(0).position;
                cam = false;
            }
        }
    }
    public void vzbit()
    {
        camera_game.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        play_cmera.GetComponent<ray>().play_object.transform.SetParent(transform_kapucinator);
        play_cmera.GetComponent<ray>().play_object.transform.position = transform_kapucinator.position;
        play_cmera.GetComponent<ray>().play_object.transform.rotation = Quaternion.Euler(-180, 0, 0);
        cam = true;
    }
    public void molokoko()
    {
        if (m == false)
        {
            m = true;
            molok.SetActive(true);
        }
    }
}
