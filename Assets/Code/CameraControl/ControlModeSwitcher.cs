using UnityEngine;
using System.Linq;
using System;

public class ControlModeSwitcher : MonoBehaviour {
	[System.Serializable]
	public class ControlMode {
		public KeyCode KeyCode;
		public MonoBehaviour Behaviour;
	}

	public ControlMode[] ControlModes;

	public KeyCode[] ModeSwitchKeys;

	private ControlMode currentMode;
	public ControlMode PubControlMode;

	void Start() {
		Cursor.visible = true;
		Cursor.lockState = CursorLockMode.None;
		if (this.ControlModes.Any()) {
			this.SetMode(this.ControlModes[2]);
		}
		foreach (var mode in this.ControlModes) {
			if (mode != this.currentMode) {
				mode.Behaviour.enabled = false;
			}
		}
	}

	void Update() {
		PubControlMode = this.currentMode;
		foreach (var mode in this.ControlModes) {
			if (Input.GetKeyDown(mode.KeyCode)) {
				this.SetMode(mode);
			}
		}
		if (this.currentMode != null && this.ModeSwitchKeys != null) {
			foreach (var keyCode in this.ModeSwitchKeys) {
				if (Input.GetKeyDown(keyCode)) {
					int currentIndex = Array.IndexOf(this.ControlModes, this.currentMode);
					this.SetMode(this.ControlModes[(currentIndex + 1) % this.ControlModes.Length]);
				}
			}
		}
	}

	public void SetMode(ControlMode mode) {
		if (this.currentMode == mode) {
			return;
		}
		if (this.currentMode != null) {
			this.currentMode.Behaviour.enabled = false;
		}
		this.currentMode = mode;
		this.currentMode.Behaviour.enabled = true;
	}
}
