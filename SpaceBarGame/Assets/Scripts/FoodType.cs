using UnityEngine;
using System.Collections;

public class FoodType : MonoBehaviour {

    public enum spaceFoodType {
        spaceChicken,
        spaceBeer,
        spaceSoup,
        spacePizza,
        spaceEyeballPizza,
        spaceFries
    }

    public spaceFoodType thisFoodType;

    public Sprite foodSprite;
    public SpriteRenderer foodSpriteRen;

    void Awake() {
        //transform.GetComponentInChildren<SpriteRenderer>();
        foreach (Transform tf in transform) {
            if (tf.GetComponent<SpriteRenderer>() != null) {
                foodSpriteRen = tf.GetComponent<SpriteRenderer>();

                break;
            }
        }
        
    }
}
