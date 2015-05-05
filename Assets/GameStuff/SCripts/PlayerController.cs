using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	public GameObject BulletType;
	public float playerspeed = 10;
	public int bulletsprayspeed = 10;
	public int bulletclustercount = 3;
	public bool canmove = true;
	public bool canshoot = true;

	Rigidbody2D rigidBody;

	float bulletcounter = 10;

	// Use this for initialization
	void Start () {
		rigidBody = GetComponent<Rigidbody2D> ();
	
	}
	
	// Update is called once per frame
	void Update () {
		bulletcounter -= Time.deltaTime*bulletsprayspeed;
		Vector3 pos = Camera.main.ScreenToWorldPoint (Input.mousePosition);

		transform.rotation = Quaternion.LookRotation(Vector3.forward, pos - transform.position);

		if (canmove & Input.GetMouseButton(0)) {
			rigidBody.AddForce(transform.up *Time.deltaTime *playerspeed * rigidBody.mass);
		}


		if ( canshoot ){
			if(bulletcounter <= 1){
				for(int i = 0; i<=bulletclustercount; i++){
					GameObject bullet = Instantiate(BulletType, transform.position+transform.up/10, new Quaternion(0,0,0,0)) as GameObject;
					SuperClassBullet BulletSettings = bullet.GetComponent<SuperClassBullet>();
					bullet.BroadcastMessage("init");
			
					Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
					float accuracy = BulletSettings.accuracy;
					Vector3 randVect = new Vector3(Random.Range(-accuracy, accuracy), Random.Range(-accuracy, accuracy), Random.Range(-accuracy, accuracy));
					rb.AddForce((transform.up+randVect) * BulletSettings.speed * BulletSettings.getMass());

				}

				bulletcounter = 10;

			}
		}
		
	}
}
