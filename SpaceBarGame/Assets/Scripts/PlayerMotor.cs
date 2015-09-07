using UnityEngine;
using System.Collections;

public class PlayerMotor : Motor {

    public Vector3 mousePoint;

    private Plane playerPlane;

    protected override void Update() {//perform all inputs before we run the motor
        //base.Update();

        CalculatePlayerPlane();

        CalcMousePoint();
        InputPos(mousePoint);

        //Debug.DrawLine(tf.position, mousePoint);

        base.Update();
    }

    private void CalculatePlayerPlane() {
        //Vector3 planeNorm = Camera.main.transform.rotation * Vector3.one;
        Vector3 planeNorm = Vector3.up;
        playerPlane = new Plane(planeNorm, tf.position);
    }

    private void CalcMousePoint() {
        Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        float dist;
        if (playerPlane.Raycast(camRay, out dist)) {
            mousePoint = camRay.GetPoint(dist);
        }
    }

}
