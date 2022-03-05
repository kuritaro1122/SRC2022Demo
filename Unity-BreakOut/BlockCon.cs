using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockCon : MonoBehaviour {

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }

    void OnTriggerEnter(Collider other) {
        GameObject obj = other.gameObject;
        BallCon ball = obj.GetComponent<BallCon>();
        if (ball != null) {
            (float vd1, float vd2) = VerticalDistanceFromDiagonal(ball.transform.position);
            Vector2 velocity = ball.GetVelocity();
            if (vd1 > 0 && vd2 > 0 && velocity.y < 0) {
                ball.ReverseVelocityY();
                Destroy(this.gameObject);
            }
            if (vd1 < 0 && vd2 < 0 && velocity.y > 0) {
                ball.ReverseVelocityY();
                Destroy(this.gameObject);
            }
            if (vd1 > 0 && vd2 < 0 && velocity.x > 0) {
                ball.ReverseVelocityX();
                Destroy(this.gameObject);
            }
            if (vd1 < 0 && vd2 > 0 && velocity.x < 0) {
                ball.ReverseVelocityX();
                Destroy(this.gameObject);
            }
        }
    }

    private (float, float) VerticalDistanceFromDiagonal(Vector3 worldPos) {
        Vector2 localRightUp = this.transform.lossyScale / 2f;
        float a1 = localRightUp.y / localRightUp.x;
        Vector2 targetLocalPos = worldPos - this.transform.position;
        float y1 = targetLocalPos.y - a1 * targetLocalPos.x;
        float y2 = targetLocalPos.y + a1 * targetLocalPos.x;
        return (y1, y2);
    }
}
