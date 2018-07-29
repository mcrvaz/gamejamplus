using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour {

	private AudioMixer mixerBGM;
	private AudioMixer mixerFX;

	void Awake() {
		mixerBGM = Resources.Load("Mixers/MixerBGM") as AudioMixer;
		mixerFX = Resources.Load("Mixers/MixerFX") as AudioMixer;
	}

	public void ToggleEffects() {
		float currentVolume;
		mixerFX.GetFloat("volume", out currentVolume);
		mixerFX.SetFloat("volume", currentVolume > 0 ? 0 : 100);
	}

	public void ToggleBGM() {
		float currentVolume;
		mixerBGM.GetFloat("volume", out currentVolume);
		mixerBGM.SetFloat("volume", currentVolume > 0 ? 0 : 100);
	}
}
