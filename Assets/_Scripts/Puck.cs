using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puck : MonoBehaviour {

	public GameObject collisionParticles;
	public GameObject explosionParticles;
	public AudioClip[] puckSounds;

	private AudioSource puckAudio;

	// Use this for initialization
	void Start () {
		puckAudio = GetComponent<AudioSource> ();
	}

	// Update is called once per frame
	void Update () {

	}

	void OnCollisionEnter(Collision collision){
		PuckSound(collision);
		if (collision.gameObject.tag == "Wall") {
			GameObject sparks = Instantiate (collisionParticles) as GameObject;
			sparks.transform.position = transform.position;
		}
	}

	public void DestroyPuck(){
		GameObject explosion = Instantiate (explosionParticles) as GameObject;
		explosion.transform.position = transform.position;
		Destroy (gameObject);
	}

	public void PuckSound(Collision collision){
		if (collision.gameObject.tag == "Wall")
		{
			puckSounds = new AudioClip[] {Resources.Load("AudioFX/puck_wall_impact_sound_1a") as AudioClip,
				Resources.Load("AudioFX/puck_wall_impact_sound_2a") as AudioClip,
				Resources.Load("AudioFX/puck_wall_impact_sound_3a") as AudioClip,
				Resources.Load("AudioFX/puck_wall_impact_sound_4a") as AudioClip};
		}
		else if (collision.gameObject.tag == "Bumper")
		{
			puckSounds = new AudioClip[] {Resources.Load("AudioFX/puck_bumper_impact_sound_1") as AudioClip,
				Resources.Load("AudioFX/puck_bumper_impact_sound_2") as AudioClip,
				Resources.Load("AudioFX/puck_bumper_impact_sound_3") as AudioClip,
				Resources.Load("AudioFX/puck_bumper_impact_sound_4") as AudioClip};
		}
		int randomIndex = Random.Range(0, puckSounds.Length);
		puckAudio.clip = puckSounds[randomIndex];
		puckAudio.Play ();
	}
}
