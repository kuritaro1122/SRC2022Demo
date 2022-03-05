using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCon : MonoBehaviour {
    [SerializeField] private float speed = 5;
    [SerializeField] private Vector2 p0 = new Vector2(-11, -4);
    [SerializeField] private Vector2 p1 = new Vector2(11, 6);
    private Vector3 velocity = Vector2.zero;
    [SerializeField] GameManager gameManager;

    // Start is called before the first frame update
    void Start() {
        Restart();
    }

    // Update is called once per frame
    void Update() {
        /// Cannot directly assign to transform.position.x
        /// x (this.transform.position.x = ...;)
        /// o (this.transform.position = ...;)
        this.transform.position += this.speed * this.velocity.normalized * Time.deltaTime;
        ReflectionOnTheWall();
    }

    public void ReverseVelocityX() {
        this.velocity.x *= -1;
    }
    public void ReverseVelocityY() {
        this.velocity.y *= -1;
    }
    public Vector3 GetVelocity() {
        return this.velocity.normalized;
    }

    private void ReflectionOnTheWall() {
        /// a = -a equal a *= -1
        Vector2 pos = this.transform.position;
        if (pos.x < this.p0.x && this.velocity.x < 0) this.velocity.x = -this.velocity.x;
        if (pos.x > this.p1.x && this.velocity.x > 0) this.velocity.x = -this.velocity.x;
        //if (pos.y < this.p0.y && this.velocity.y < 0) this.velocity.y *= -1;
        if (pos.y < this.p0.y && this.velocity.y < 0) this.gameManager.GameOver();
        if (pos.y > this.p1.y && this.velocity.y > 0) this.velocity.y *= -1;
    }
    private void Restart() {
        this.transform.position = Vector3.zero;
        this.velocity = new Vector3(1, 1, 0);
    }

    void OnDrawGizmos() {
        Gizmos.color = Color.white;
        Vector2 leftDown = this.p0;
        Vector2 leftUp = new Vector2(this.p0.x, this.p1.y);
        Vector2 rightDown = new Vector2(this.p1.x, this.p0.y);
        Vector2 rightUp = this.p1;
        if (p0.x < p1.x) Gizmos.color = Color.white;
        else Gizmos.color = Color.red;
        Gizmos.DrawLine(leftDown, leftUp);
        Gizmos.DrawLine(rightDown, rightUp);
        if (p0.y < p1.y) Gizmos.color = Color.white;
        else Gizmos.color = Color.red;
        Gizmos.DrawLine(leftDown, rightDown);
        Gizmos.DrawLine(leftUp, rightUp);
    }
}
