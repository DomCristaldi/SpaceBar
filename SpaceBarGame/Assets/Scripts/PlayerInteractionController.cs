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

    public Transform foodAnchor;

    public InteractMode curInteractMode;

    public GameObject foodInHand = null;

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
                /*
                foodInHand = trig.gameObject.GetComponent<Barfood>().pickup(trig, foodInHand);

                if (foodInHand != null) {
                    hasFoodItem = true;
                }
                else {
                    hasFoodItem = false;
                }
                */
                
                //if (hasFoodItem == true) {
            //CALL OUTSIDE FUNCTION FOR SWAPPING FOOD ITEM
                if (foodInHand != null) {
                    
                    foodInHand.transform.parent = null;//unparent
                    GameObject oldFood = foodInHand;
                    
                    foodInHand = trig.transform.root.GetComponent<Barfood>().pickup(trig, foodInHand);

                    oldFood.transform.position = foodInHand.transform.position;
                }
            //CALL OUTSIDE FUNCTION FOR GRABBING FROM BAR
                else {
                    
                    foodInHand = trig.transform.root.GetComponent<Barfood>().pickup(trig);
                }

                if (foodInHand != null) {
                    ParentFoodToHand();
                }
            }
            else if (curInteractMode == InteractMode.putDown) {
                //CALL OUTSIDE FUNCTION FOR PLACING FOOD AT TABLE
                trig.transform.root.gameObject.GetComponent<Customer>().served(foodInHand);
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
            else if (trig.tag == "Customer" && foodInHand != null) {
                curInteractMode = InteractMode.putDown;
            }
            else {
                curInteractMode = InteractMode.neutral;
            }
        }
    }

    private void ParentFoodToHand() {
        foodInHand.transform.position = foodAnchor.position;
        foodInHand.transform.parent = foodAnchor;
    }
}
