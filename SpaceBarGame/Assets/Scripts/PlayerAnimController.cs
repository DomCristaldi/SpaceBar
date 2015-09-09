using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Motor))]
[RequireComponent(typeof(Rigidbody))]
public class PlayerAnimController : MonoBehaviour {

    public enum facingDirection {
        left,
        right,
    }

    public Rigidbody rigbod;

    private Motor motor;

    public Transform playerModel;
    public Animator animator;

    public facingDirection curFacingDirec;

    private Plane facingPlane;

    void Awake() {
        rigbod = GetComponent<Rigidbody>();

        motor = GetComponent<Motor>();
    }

	// Use this for initialization
	void Start () {
        facingPlane = new Plane(playerModel.right, playerModel.position);
	}
	
	// Update is called once per frame
	void Update () {
        HandleFacingDirec();
        HandleAnimations();
	}

    private void HandleFacingDirec() {
        
        facingPlane.SetNormalAndPosition(playerModel.right, transform.position);

    //SET THE FACING DIRECTION SETTING
        if (motor.curMoveSpeedType == Motor.moveSpeedType.walking) {

            if (facingPlane.GetSide(transform.position + motor.deliveredDirec)) {
                curFacingDirec = facingDirection.right;
            }
            else {
                curFacingDirec = facingDirection.left;
            }
        }

    //FLIP THE CHARACTER MODEL IF THE NOT ALREADY FACINT THE CORRECT DIRECTION
        //RIGHT
        if (curFacingDirec == facingDirection.right && playerModel.localScale.x > 0.0f) {
            playerModel.localScale = new Vector3(playerModel.localScale.x * -1.0f,
                                                 playerModel.localScale.y,
                                                 playerModel.localScale.z);
        }
        //LEFT
        else if (curFacingDirec == facingDirection.left && playerModel.localScale.x < 0.0f) {
            playerModel.localScale = new Vector3(playerModel.localScale.x * -1.0f,
                                                 playerModel.localScale.y,
                                                 playerModel.localScale.z);
        }
    }

    private void HandleAnimations() {
        //if (motor.curMoveSpeedType == Motor.moveSpeedType.idling) {
        if (rigbod.velocity.magnitude < motor.slowDownDist) {
            animator.SetBool("Walking", false);
        }
        //if (motor.curMoveSpeedType == Motor.moveSpeedType.walking) {
        else {
            animator.SetBool("Walking", true);
        }

        //if (motor.trueDirec.magnitude > motor.slow
    }
}
