using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float jumpForce = 12;
    private Rigidbody rb;
    private float timer;
    private float timerCd = 0.2f;


    private void Start() {
        rb = GetComponent<Rigidbody>();
    }

    private void Update() {
        if(Input.GetKeyDown(KeyCode.Space)) Jump();

        if(timer>0) timer-=Time.deltaTime;

    }

    private void OnTriggerEnter(Collider other) {
        if(!other.GetComponent<Obstacle>()) 
        {
            Invoke(nameof(RemoveThis),.001f);
        }
    }

    private void RemoveThis()
    {
        GameManager gm = GameManager.Instance;
        gm.ais.Remove(this.GetComponent<AI>());
        gm.CheckForDeath();
        Destroy(gameObject);

    }

    public void Jump(){
        if(timer>0) return;
        timer = timerCd;
        rb.velocity = Vector3.zero;
        rb.AddForce(Vector3.up*jumpForce);

    }
}
