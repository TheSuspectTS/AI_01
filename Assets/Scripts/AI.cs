using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour
{
    public float weighths;
    

    public float posPoints;
    public int obsticlePoints;
    

    public PlayerController pc;
    public GameManager gm;

    private void Awake() {
        gm = GameManager.Instance;
        if(gm.preset.firstCycle) { weighths = Random.Range(-15f,15f); print("First");}

    }

    private void Start() {
        float addic = Random.Range(-5f,5f);
        weighths = (weighths + addic)/gm.preset.cycle;
        
    }

    private void Update() {

        posPoints = pc.transform.position.y - gm.nextObstacle.position.y;

        

        if(posPoints < weighths) pc.Jump();

    }

}
