using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerInteractionController : MonoBehaviour {

    public enum InteractMode {
        neutral,
        pickUp,
        putDown,
    }

    Transform tf;
    Rigidbody rigBod;

    public InteractMode curInteractMode;

    public bool hasFoodItem = false;
    public GameObject foodInHand;

    public KeyCode interactionKey = KeyCode.Space;

    public Collider trig;

    void Awake() {
        tf = GetComponent<Transform>();
        rigBod = GetComponent<Rigidbody>();
    }

    void OnTriggerEnter(Collider other) {
        trig = other;
    }

    void OnTriggerExit(Collider other) {
        trig = null;
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    CheckInteractMode();

        HandleFood();
	}

    private void HandleFood() {
        if (Input.GetKeyDown(interactionKey)) {
            if (curInteractMode == InteractMode.pickUp) {
                if (hasFoodItem == true) {
                    //CALL OUTSIDE FUNCTION FOR SWAPPING FOOD ITEM
                }
                else {
                    //CALL OUTSIDE FUNCTION FOR GRABBING FROM BAR
                    foodInHand = trig.gameObject.GetComponent<Barfood>().pickup(trig);
                }
            }
            else if (curInteractMode == InteractMode.putDown) {
                //CALL OUTSIDE FUNCTION FOR PLACING FOOD AT TABLE
                //trig.transform.parent.GetComponent<Customer>().served(
            }
        }
    }

    private void CheckInteractMode() {
        if (trig == null) {
            curInteractMode = InteractMode.neutral;
        }
        else {
            if (trig.tag == "Bar") {
                curInteractMode = InteractMode.pickUp;
            }
            else if (trig.tag == "Customer" && hasFoodItem == true) {
                curInteractMode = InteractMode.putDown;
            }
            else {
                curInteractMode = InteractMode.neutral;
            }
        }
    }
}
