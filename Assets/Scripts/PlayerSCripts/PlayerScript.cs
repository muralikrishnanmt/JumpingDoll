using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerScript : MonoBehaviour {

	private Rigidbody2D myBody;
	private Button jumpBtn;
	private GameObject parent;

	private bool hasJumped;


	// Use this for initialization
	void Awake () {

		jumpBtn = GameObject.Find ("JumpButton").GetComponent<Button> ();
		jumpBtn.onClick.AddListener (() => Jump());
		myBody = GetComponent<Rigidbody2D> ();
	
	}
	
	// Update is called once per frame
	void Update () {
		if (hasJumped && myBody.velocity.y == 0) {
			hasJumped = false;
			transform.SetParent (parent.transform);
		} else if (parent != null) {
			transform.SetParent (parent.transform);
		}
	
	}

	public void Jump(){
		if (myBody.velocity.y == 0) {
			myBody.velocity = new Vector2 (0, 10);
			hasJumped = true;
		}
	}
	void OnCollisionEnter2D(Collision2D target){
		if (target.gameObject.tag == "Platform") {
			parent = target.gameObject;
		}
	}
	void OnCollisionExit2D(Collision2D target){
		if(target.gameObject.tag=="Platform"){
			parent=null;


		}
	}

}
