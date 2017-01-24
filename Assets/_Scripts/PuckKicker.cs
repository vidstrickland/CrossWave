using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuckKicker : MonoBehaviour {

	public float radius = 0.0F;
	public float power = 1500000000.0F;
	public AudioClip[] kickSounds;

	private AudioSource puckAudio;

	// Use this for initialization
	void Start () {
		puckAudio = GetComponent<AudioSource> ();
		PlayKickSound();
		//leftChargeMeter = GameObject.Find ("Left Charge Meter");
		//if (leftChargeMeter.barDisplay < .2f) {
		Invoke("Destroy", 0.25f);
		Vector3 explosionPos = transform.position;
		Collider[] colliders = Physics.OverlapSphere (explosionPos, radius);

		foreach (Collider hit in colliders) {
			Rigidbody rb = hit.GetComponent<Rigidbody> ();

			if (rb != null) {
				rb.AddExplosionForce (power, explosionPos, radius, 0.0F);
			}
		}
	}

	void PlayKickSound(){
		if (GameObject.FindWithTag("Puck"))
		{
			print ("oh no it's me");
			kickSounds = new AudioClip[] {Resources.Load("AudioFX/puck_touch_impact_sound_1a") as AudioClip,
				Resources.Load("AudioFX/puck_touch_impact_sound_2a") as AudioClip,
				Resources.Load("AudioFX/puck_touch_impact_sound_3a") as AudioClip,
				Resources.Load("AudioFX/puck_touch_impact_sound_4a") as AudioClip};
			int randomIndex = Random.Range(0, kickSounds.Length);
			//AudioSource.PlayClipAtPoint(kickSounds[randomIndex], transform.position);
			puckAudio.clip = kickSounds[randomIndex];
			puckAudio.Play ();
		}
	}

	void Destroy(){
		Destroy (gameObject);
	}
}
