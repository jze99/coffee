using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ray : MonoBehaviour
{
    public static ray r1;
    public GameObject play_object;
    GameObject play_finger;
    Slider slider1;
    public LayerMask ray_layer_mask;
    Material game_mat;
    public Material play_mat;
    public bool predmet;
    bool arm;
    bool bro;
    float time;
    float Distantion=4;
    float TurnSpead=350;
    int predmet_isp;
    public void delit()
    {
        play_object.transform.SetParent(null);
        predmet = false;
        play_object.GetComponent<id>().isp = false;
        Destroy(play_object);
        play_object = null;
        bro = false;
    }
    public void dobavit()
    {
        play_object.transform.SetParent(play_finger.transform);
        play_object.transform.position = play_finger.transform.position;
    }
	void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        play_finger = transform.GetChild(0).gameObject;
        slider1 = transform.GetChild(1).GetChild(0).GetComponent<Slider>();
    }

    private void FixedUpdate()
    {
        slider1.transform.LookAt(gameObject.transform);
    }

    public void Update()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;
        Debug.DrawRay(transform.position, transform.forward * 4f, Color.black);
        if (Physics.Raycast(ray, out hit, Distantion, ray_layer_mask))
        {
            if (Input.GetKey(KeyCode.E) && predmet == false)
            {
                slider1.transform.position = hit.point;
                time += Time.deltaTime;
                slider1.value = time;
                if (slider1.maxValue <= slider1.value)
                {
                    slider1.transform.position = new Vector3(0, -4, 0);
                    play_object = hit.collider.gameObject;
                    play_object.GetComponent<Collider>().isTrigger = true;
                    play_object.transform.SetParent(play_finger.transform);
                    play_object.transform.position = play_finger.transform.position;
                    game_mat = play_object.transform.GetChild(0).GetComponent<MeshRenderer>().material;
                    play_object.transform.Rotate(0, 0, 0);
                    predmet = true;
                    play_object.layer = 1;
                    play_object.GetComponent<id>().isp = true;
                    if (play_object.GetComponent<Rigidbody>())
                    {
                        play_object.GetComponent<Rigidbody>().isKinematic = true;
                    }
                }
            }
            else
            {
                slider1.transform.position = new Vector3(0, -4, 0);
                time = 0;
            }
            if (predmet == true)
            {
                switch (play_object.GetComponent<id>().Id)
                {
                    case 1:
                        play_object.transform.SetParent(null);
                        play_object.transform.GetChild(0).GetComponent<MeshRenderer>().material = play_mat;
                        arm = true;
                        break;
                    case 2:
                        bro = true;
                        predmet_isp = hit.collider.gameObject.GetComponent<id>().predmet_isp;
                        switch (predmet_isp)
                        {
                            case 1:
                                if (Input.GetKeyDown(KeyCode.F))
                                {
                                    hit.collider.gameObject.GetComponent<kran>().on_off();
                                }
                                break;
                            case 2:
                                if (Input.GetKey(KeyCode.F))
                                {
                                    if (play_object.GetComponent<id>().predmet_isp == 1) 
                                    {
                                        hit.collider.gameObject.transform.GetChild(0).GetComponent<moloko>().vzbit();
                                    }
                                    if (play_object.GetComponent<id>().predmet_isp == 2)
                                    {
                                        hit.collider.gameObject.transform.GetChild(0).GetComponent<moloko>().molokoko();
                                    }
                                }
                               
                                break;
                            case 3:
                                
                                if (Input.GetKeyDown(KeyCode.F) && play_object.GetComponent<id>().molot_ili_net == false)
                                {
                                    hit.collider.gameObject.transform.GetChild(0).GetComponent<coffe_molka>().molit();
                                }
                                break;
                            case 4:
                                if (Input.GetKeyDown(KeyCode.F))
                                {
                                    hit.collider.gameObject.transform.GetChild(0).GetComponent<tura_ka>().dobavi_coffe();
                                    predmet = false;
                                }
                                break;
                        }

                        break;
                }
            }
            if (arm == true)
            {
                play_object.transform.position = hit.point += new Vector3(0, 0.5f, 0);
                if (Input.GetKey(KeyCode.R) && predmet == true && arm == true)
                {
                    play_object.transform.Rotate(Vector3.up, -TurnSpead * Time.deltaTime);
                }
                if (Input.GetKey(KeyCode.Q) && predmet == true && arm == true)
                {
                    play_object.transform.Rotate(Vector3.up, TurnSpead * Time.deltaTime);
                }
                if (Input.GetKeyDown(KeyCode.E) && predmet == true)
                {
                    play_object.transform.GetChild(0).GetComponent<MeshRenderer>().material = game_mat;
                    play_object.GetComponent<Collider>().isTrigger = false;
                    predmet = false;
                    play_object.layer = 0;
                    play_object = null;
                    arm = false;
                }
            }
        }
        if (bro == true && Input.GetKeyDown(KeyCode.G))
        {
            if (play_object.GetComponent<Rigidbody>())
            {
                play_object.GetComponent<Rigidbody>().isKinematic = false;
                play_object.GetComponent<Rigidbody>().AddForce(transform.forward * 180f);
            }
            play_object.GetComponent<id>().isp = false;
            play_object.transform.SetParent(null);
            play_object.GetComponent<Collider>().isTrigger = false;
            predmet = false;
            play_object.layer = 0;
            play_object = null;
            bro = false;
        }
    }  
}
