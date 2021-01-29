using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageGenerator : MonoBehaviour
{
    const int StageTipSize = 15;

    int currentTipIndex;

    public Transform character;
    public GameObject[] StageTips;
    public int startTipIndex;
    public int preInstantiate;
    public List<GameObject> generatedStageList = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        currentTipIndex = startTipIndex - 1;
        UpdateStage(preInstantiate);
    }

    // Update is called once per frame
    void Update()
    {
        int characterPosIndex = (int)(character.position.z / StageTipSize);
        if(characterPosIndex+preInstantiate > currentTipIndex)
        {
            UpdateStage(characterPosIndex+preInstantiate);
        }
    }

    private void UpdateStage(int toTipIndex)
    {
        if (toTipIndex <= currentTipIndex) return;

        for(int i = currentTipIndex+1;i<=toTipIndex ;i++ )
        {
            GameObject stageObject = GenerateStage(i);
            generatedStageList.Add(stageObject);
        }
        while (generatedStageList.Count > preInstantiate + 2) DestroyOldestStage();
        currentTipIndex = toTipIndex;
    }

    GameObject GenerateStage(int tipIndex)
    {
        int nextStageTip = Random.Range(0, StageTips.Length);

        GameObject stageObj = (GameObject)Instantiate(
            StageTips[nextStageTip],
            new Vector3(0,0,tipIndex*StageTipSize),
            Quaternion.identity
            );
        return stageObj;
    }

    void DestroyOldestStage()
    {
        GameObject oldStage = generatedStageList[0];
        generatedStageList.RemoveAt(0);
        Destroy(oldStage);
    }
}
