using UnityEngine;
using System.Collections;

public class MusicManager : MonoBehaviour {

	public AudioClip[] levelMusicChangeArray;

	private AudioSource musicSource;

	// Use this for initialization
	void Awake () {
		DontDestroyOnLoad (gameObject);
		Debug.Log ("Don't destroy on load: " + name);
	}

	void Start() {
		musicSource = GetComponent<AudioSource> ();
	}

	void OnLevelWasLoaded (int level) {

		AudioClip thisLevelMusic = levelMusicChangeArray [level];
		Debug.Log("Playing Clip: " + thisLevelMusic);

		if (thisLevelMusic) { // If there's some music attached
			musicSource.clip = thisLevelMusic;
			musicSource.loop = true;
			musicSource.Play ();
		}
	}

	public void ChangeVolume(float volume){
		musicSource.volume = volume;
	}
}
