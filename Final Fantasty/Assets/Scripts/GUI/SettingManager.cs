using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingManager : MonoBehaviour {

	public Toggle fullscreenToggle;
	public Dropdown resolutionDropdown;
	public Dropdown textureQualityDropdown;
	public Dropdown antialiasingDropdown;
	public Dropdown vSyncDropdown;
	public Slider musicVolumeSlider;

	public AudioSource musicSource;
	public Resolution[] resolutions;
	public GameSetting gameSetting;

	void OnEnable(){

		gameSetting = new GameSetting ();

		fullscreenToggle.onValueChanged.AddListener (delegate {OnFullscreenToggle();});
		resolutionDropdown.onValueChanged.AddListener (delegate {OnResolutionChange();});
		textureQualityDropdown.onValueChanged.AddListener (delegate {OnTextureQualityChange();});
		antialiasingDropdown.onValueChanged.AddListener (delegate {OnAntialiasingChange();});
		vSyncDropdown.onValueChanged.AddListener (delegate {OnVSyncChange();});
		musicVolumeSlider.onValueChanged.AddListener (delegate {OnMusicVolumeChange();});



		resolutions = Screen.resolutions;
	}

	public void OnFullscreenToggle(){
		//gameSetting.fullscreen = Screen.fullScreen = fullscreenToggle.isOn;
	}

	public void OnResolutionChange (){
		
	}

	public void OnTextureQualityChange(){
		QualitySettings.masterTextureLimit = gameSetting.textureQuality = textureQualityDropdown.value;

	}

	public void OnAntialiasingChange(){
		QualitySettings.antiAliasing = gameSetting.antialiasing = (int)Mathf.Pow (2f, antialiasingDropdown.value);
	}

	public void OnVSyncChange(){
		QualitySettings.vSyncCount = gameSetting.vSync = vSyncDropdown.value;
	}


	public void OnMusicVolumeChange(){
		musicSource.volume = gameSetting.musicVolume = musicVolumeSlider.value;
	}

	public void SaveSettings(){
	}

	public void LoadSettings(){
		
	}



}
