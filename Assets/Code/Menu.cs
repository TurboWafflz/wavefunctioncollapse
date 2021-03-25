using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
	private bool shown = false;
	private bool intro = true;
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
		if (intro){
			OldMode = cm.ControlModes[0];
			intro = false;
		}
		shown = false;
		Cursor.visible = false;
		Cursor.lockState = CursorLockMode.Locked;
		cm.SetMode(OldMode);
		GameObject.Find("Menu").GetComponent<Canvas>().enabled = false;
	}
	void Start(){
		cm = GameObject.Find("Player").GetComponent<ControlModeSwitcher>();
		shown=true;
		GameObject.Find("Menu").GetComponent<Canvas>().enabled = true;
	}
	public void Exit(){
		Application.Quit();
	}
	void Update(){
		if (Input.GetKeyDown("escape")){
			if (!shown){
				Show();
			} else {
				if (intro){
					OldMode = cm.ControlModes[0];
					intro = false;
				}
				Hide();
			}
		}
	}
	public void ChangeQuality(int value){
		QualitySettings.SetQualityLevel(value, true);
	}
}
