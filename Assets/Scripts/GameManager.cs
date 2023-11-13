using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public TMP_Text posText;
    public TMP_Text obPointsText;
    public TMP_Text bestWeightText;
    public TMP_Text selectedText;

    
    public Transform nextObstacle;

    public int selectedAI = 0;
    public int maxAIs = 16;
    public AI ai;
    public List<AI> ais = new List<AI>();
    public List<AI> allAis = new List<AI>();
    public AI_Preset preset;

    public string path;



    
    private void Awake() {
        Instance = this;
    }

    private void Start() {
        path = Application.dataPath + "/log.txt";

        for(int i=0;i<maxAIs;i++)
        {
            AI tmp = Instantiate(ai,transform.parent);
            if(!preset.firstCycle) tmp.weighths = preset.wighths;
            ais.Add(tmp);
            allAis.Add(tmp);
        }

        bestWeightText.text = "Best Weight > " + preset.wighths;

        if(preset.firstCycle) preset.firstCycle = false;
    }

    public void AddObs()
    {
        for(int i=0;i<ais.Count;i++)
        {
            ais[i].obsticlePoints++;
        }
    }

    private void Update() {

        selectedText.text = "Selected AI: " + selectedAI;

        if(Input.GetAxisRaw("Mouse ScrollWheel") > 0)
        {
            selectedAI--;
            if(selectedAI<0) selectedAI = ais.Count-1;
        } 
        else if(Input.GetAxisRaw("Mouse ScrollWheel") < 0)
        {
            selectedAI++;
            if(selectedAI>ais.Count-1) selectedAI = 0;
        } 


        if(ais.Count>0){
            posText.text = "Pos > " + ais[selectedAI].posPoints;
            obPointsText.text = "Obs > " + ais[selectedAI].obsticlePoints;
        }

    
        

    }

    public void CheckForDeath()
    {
        if(ais.Count==1)
        {
            int bestScore = 0;
            float bestWeight = preset.wighths;
            for(int i=0;i<allAis.Count;i++)
            {
                if(allAis[i].obsticlePoints > bestScore) 
                {
                    bestScore = allAis[i].obsticlePoints;
                    bestWeight = allAis[i].weighths;
                }
            }
            if(preset.bestObs < bestScore) preset.bestObs = bestScore;
            preset.wighths = bestWeight;
            preset.cycle++;

            string dataToStore = "";
            string tmp = File.ReadAllText(path);
            dataToStore = tmp + bestScore + "\n";

            File.WriteAllText(path,dataToStore);

            UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        }
    }

}
