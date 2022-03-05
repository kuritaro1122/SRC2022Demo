using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBarCon : MonoBehaviour {
    // By adding [SerializeField] to the variable, the value can be changed from the inspector.
    [SerializeField] private float speed = 10f;

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        /// Get stick input https://docs.unity3d.com/jp/current/ScriptReference/Input.html
        float stick = Input.GetAxisRaw("Horizontal"); 
        Movement(stick);
    }

    private void Movement(float stick) {
        /// Cannot directly assign to transform.position.x
        /// x (this.transform.position.x = ...;)
        /// o (this.transform.position = ...;)
        Vector3 pos = this.transform.position;
        pos.x = pos.x + this.speed * stick * Time.deltaTime;
        this.transform.position = pos;
    }

    void OnTriggerEnter(Collider other) {
        GameObject obj = other.gameObject;
        BallCon ball = obj.GetComponent<BallCon>(); //find BallCon component
        if (ball != null && ball.GetVelocity().y < 0) {
            ball.ReverseVelocityY();
        }
    }
}
