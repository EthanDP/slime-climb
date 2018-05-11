using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserController : MonoBehaviour {

	public GameObject deathHandler;
	public int direction;  // 0 = left, 1 = up, 2 = right, 3 = down

	public Material laserMat;
	public Material preLaserMat;

	public AudioClip laserFireNoise;
	public AudioClip preLaserNoise;
	public GameObject laserNoise;
	AudioSource laserNoiseSource;

	LineRenderer laser;
	bool drawingLaser = false;

	void Start () {
		laser = GetComponent<LineRenderer> ();
		laser.SetPosition (0, transform.position);
		laserNoise = GameObject.FindGameObjectWithTag ("LaserNoise");
		laserNoiseSource = laserNoise.GetComponent<AudioSource> ();

		StartCoroutine (waitForLaser ());
	}

	void Update () {

		if (drawingLaser) {
			drawLaser (true);
			if (laserNoiseSource.clip != laserFireNoise) {
				laserNoiseSource.clip = laserFireNoise;
				laserNoiseSource.Play ();
			}
		} else {
			drawLaser (false);
			StartCoroutine (waitForLaser ());
			if (laserNoiseSource.clip != preLaserNoise) {
				laserNoiseSource.clip = preLaserNoise;
				laserNoiseSource.Play ();
			}

		}
	}

	IEnumerator waitForLaser() {
		drawingLaser = false;
		yield return new WaitForSeconds (3f);
		drawingLaser = true;
		yield return new WaitForSeconds (3f);
		drawingLaser = false;
	}

	void drawLaser (bool active) {
		RaycastHit2D hit;
		hit = Physics2D.Raycast (transform.position, Vector3.left, 50);
		if (active) {
			laser.material = laserMat;
		} else {
			laser.material = preLaserMat;
		}

		if (direction == 0) {
			if (hit) {
				laser.SetPosition (1, hit.point);
			} else {
				laser.SetPosition (1, new Vector2 (transform.position.x - 10, transform.position.y));
			}
		} else if (direction == 1) {
			hit = Physics2D.Raycast (transform.position, Vector3.up, 50);
			if (hit) {
				laser.SetPosition (1, hit.point);
			} else {
				laser.SetPosition (1, new Vector2 (transform.position.x, transform.position.y + 100));
			}
		} else if (direction == 2) {
			hit = Physics2D.Raycast (transform.position, Vector3.right, 50);
			if (hit) {
				laser.SetPosition (1, hit.point);
			} else {
				laser.SetPosition (1, new Vector2 (transform.position.x + 10, transform.position.y));
			}
		} else {
			hit = Physics2D.Raycast (transform.position, Vector3.down, 50);
			if (hit) {
				laser.SetPosition (1, hit.point);
			} else {
				laser.SetPosition (1, new Vector2 (transform.position.x, transform.position.y - 100));
			}
		}

		if (hit && hit.transform.gameObject.tag == "Player" && active) {
			print ("Hit player");
			deathHandler.GetComponent<DeathHandler> ().PlayerDeath ();
		} 
	}
}
