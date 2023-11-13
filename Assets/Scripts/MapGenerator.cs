using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    
    public float speedMultiplier;
    public float currentSpeed;
    public float spawnOffset;
    public float spawnCd;
    private float timer;


    public Obstacle obstacle;
    public Transform spawnPos;

    public Obstacle lastObstacle;


    private void Start() {
        timer = spawnCd;
    }

    private void Update() {

        currentSpeed += speedMultiplier;
        
        if(timer<=0){
            timer = spawnCd;
            Vector3 _spawnOffset = new Vector3(0, Random.Range(-spawnOffset,spawnOffset));
            Obstacle newObst = Instantiate(obstacle,spawnPos.position + _spawnOffset,Quaternion.identity);
            newObst.speed = currentSpeed;
            lastObstacle.nextObst = newObst.transform;
            lastObstacle = newObst;
        }
        else timer-=Time.deltaTime;

    }

}
