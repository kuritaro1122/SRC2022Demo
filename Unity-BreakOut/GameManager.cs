using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    [SerializeField] PlayerBarCon playerBarCon;
    [SerializeField] BallCon ballCon;
    private bool play = false;

    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        if (play) {
            this.ballCon.enabled = true;
        } else {
            this.ballCon.enabled = false;
            Vector2 playerBarPos = this.playerBarCon.transform.position;
            float ballHeight = this.ballCon.transform.lossyScale.y;
            float barHeight = this.playerBarCon.transform.lossyScale.y;
            float y = (ballHeight + barHeight) / 2f;
            this.ballCon.transform.position = playerBarPos + new Vector2(0, y);
        }
        if (!play && Input.GetKeyDown(KeyCode.Space)) {
            play = true;
        }
    }

    public void GameOver() {
        SceneManager.LoadScene("GameScene");
    }
}
