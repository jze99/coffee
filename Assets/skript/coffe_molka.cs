using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class coffe_molka : MonoBehaviour
{
	public GameObject play_cmera;
	public GameObject[] koffe;
	GameObject inst;
	Slider slid2;
	Animator ryka;
	Animator kofe;
	public float time;
	int f;
	bool molot;
	private void Awake()
	{
		play_cmera = GameObject.Find("PlayerCamera");
		ryka = transform.GetChild(1).GetComponent<Animator>();
		kofe = transform.GetChild(0).GetComponent<Animator>();
		inst = transform.GetChild(2).gameObject;
		slid2 = transform.GetChild(3).GetChild(0).GetComponent<Slider>();

	}
	private void Update()
	{
	}
	private void FixedUpdate()
	{
		if (molot==true)
		{
			time += Time.deltaTime;
			slid2.value = time;
			if (slid2.value == slid2.maxValue)
			{
				ryka.Play("stop");
				kofe.Play("stop");
				time = 0;
				molot = false;
				kofe.gameObject.SetActive(false);
				switch (f)
				{
					case 1:
						Instantiate(koffe[0], inst.transform.position, Quaternion.identity);
						break;
					case 2:
						Instantiate(koffe[1], inst.transform.position, Quaternion.identity);
						break;
				}
			}
		}
	}
	public void molit()
    {
		if (play_cmera.gameObject.GetComponent<ray>().play_object != null)
		{
			f = play_cmera.gameObject.GetComponent<ray>().play_object.GetComponent<id>().vid_koffe;
		}
		if (f <= 10 && f != 0)
		{
				play_cmera.GetComponent<ray>().delit();
				ryka.Play("ruka");
				kofe.gameObject.SetActive(true);
				kofe.Play("Cofe_kryt");
				molot = true;
		}
	}
	
}
