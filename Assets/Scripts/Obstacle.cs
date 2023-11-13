using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float speed;
    public Transform nextObst;


    private void Start() {
        Destroy(gameObject,10f);
    }

    private void Update() {
        transform.Translate(0,0,-speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other) {
        if(other.GetComponent<PlayerController>()) {
            GameManager gm = GameManager.Instance;
            gm.nextObstacle = nextObst;
            gm.AddObs();
        }
    }
}
