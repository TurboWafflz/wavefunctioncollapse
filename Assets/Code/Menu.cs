using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
	public bool shown = false;
	private ControlModeSwitcher cm;
	private ControlModeSwitcher.ControlMode OldMode;
	public void Show(){
		shown = true;
		GameObject.Find("Menu").GetComponent<Canvas>().enabled = true;
		Cursor.visible = true;
		Cursor.lockState = CursorLockMode.None;
		OldMode = cm.PubControlMode;
		cm.SetMode(null);
	}
	public void Hide(){
		shown = false;
		Cursor.visible = false;
		Cursor.lockState = CursorLockMode.Locked;
		cm.SetMode(OldMode);
		GameObject.Find("Menu").GetComponent<Canvas>().enabled = false;
	}
	void Start(){
		cm = GameObject.Find("Player").GetComponent<ControlModeSwitcher>();
		shown=false;
		GameObject.Find("Menu").GetComponent<Canvas>().enabled = false;
	}
	public void Exit(){
		Application.Quit();
	}
	void Update(){
		if (Input.GetKeyDown("escape")){
			if (!shown){
				Show();
			} else {
				Hide();
			}
		}
	}
}
