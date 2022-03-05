using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockManager : MonoBehaviour {
    [SerializeField] GameObject blockPrefab = null;
    [SerializeField] Vector2 beginPos = new Vector2(-9.5f, 5.5f);
    [Header("--- offset ---")]
    [SerializeField] bool offsetAutoInit = true;
    [SerializeField] float offsetX;
    [SerializeField] float offsetY;
    [Header("--- num ---")]
    [SerializeField] int numX = 3;
    [SerializeField] int numY = 2;

    // Start is called before the first frame update
    void Start() {
        if (offsetAutoInit) {
            this.offsetX = this.blockPrefab.transform.lossyScale.x;
            this.offsetY = -this.blockPrefab.transform.lossyScale.y;
        }
        SetBlock();
    }

    // Update is called once per frame
    void Update() {

    }

    void OnDrawGizmos() {
        Gizmos.color = Color.green;
        Vector2 pos = beginPos;
        Vector2 p0 = -(Vector2)(this.blockPrefab.transform.lossyScale / 2f) + pos;
        Vector2 p1 = (Vector2)(this.blockPrefab.transform.lossyScale / 2f) + pos;
        Gizmos.DrawLine(p0, new Vector2(p0.x, p1.y));
        Gizmos.DrawLine(p0, new Vector2(p1.x, p0.y));
        Gizmos.DrawLine(p1, new Vector2(p0.x, p1.y));
        Gizmos.DrawLine(p1, new Vector2(p1.x, p0.y));
    }

    public void SetBlock() {
        for (int v = 0; v < this.numY; v++) {
            for (int u = 0; u < this.numX; u++) {
                GameObject block = GameObject.Instantiate(this.blockPrefab);
                block.transform.position = beginPos + new Vector2(offsetX * u, offsetY * v);
            }
        }
    }
}
