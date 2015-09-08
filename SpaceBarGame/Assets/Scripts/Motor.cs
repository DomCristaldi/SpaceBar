using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class Motor : MonoBehaviour {

    public enum facingDirection {
        left,
        right,
    }

    protected Transform tf;
    protected Rigidbody rigBod;

    public facingDirection curFacingDirec;

    public float maxMoveSpeed = 1.0f;
    public float redirectSpeed = 0.25f;

    public Vector3 deliveredDirec;
    public Vector3 trueDirec;

    //private Vector3 

    void Awake() {
        tf = GetComponent<Transform>();
        rigBod = GetComponent<Rigidbody>();   
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	protected virtual void Update () {
        HandleFacingDirec();
        HandleMovement();
	}

    protected void HandleMovement() {
        Debug.DrawRay(tf.position, deliveredDirec, Color.red);

        Vector3 deliveredPoint = tf.position + deliveredDirec;
        Vector3 truePoint = tf.position + trueDirec;
        trueDirec = Vector3.MoveTowards(truePoint, deliveredPoint, redirectSpeed) - tf.position;
        //trueDirec = deliveredDirec;

        Debug.DrawRay(tf.position, trueDirec, Color.blue);

        rigBod.velocity = new Vector3(trueDirec.x, 0.0f, trueDirec.z);
    }

    protected void HandleFacingDirec() {
        //Debug.DrawRay(Camera.main.transform.position, Camera.main.transform.up);
        
        //Debug.Log(Vector3.Angle(Camera.main.transform.up, deliveredDirec));


    }

    public void InputPos(Vector3 pos) {
        InputDirec((pos - tf.position));
    }

    public void InputDirec(Vector3 direc) {
        deliveredDirec = Vector3.ClampMagnitude(direc, maxMoveSpeed);
    }
}
