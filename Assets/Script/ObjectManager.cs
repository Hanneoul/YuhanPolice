using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ObjectManager : MonoBehaviour
{

    // Stage 별 생성할 Object 배열
    public List<StageObject> stages;
    // Prefab 스폰 위치 ( 위, 중앙, 아래 )
    public GameObject[] spawnPoints;
    // Prefab 종료
    public GameObject[] PrefabList;
    // 현재 스폰된 순서
    public int spawnIndex;
    // Stage 종료여부 체크
    public bool spawnEnd;

    void Start()
    {
        List<StageObject> temp = ReadSpawnFile(1);
        Debug.Log("temp Count : " + temp.Count);
    }
    List<StageObject> ReadSpawnFile(int stageNum)
    {
        // 새로운 스테이지 생성
        stages = new List<StageObject>();

        stages.Clear();
        spawnIndex = 0;
        spawnEnd = false;

        TextAsset stageData = Resources.Load("stage" + stageNum ) as TextAsset;
        StringReader stringReader = new StringReader(stageData.text);

        while(stringReader != null)
        {
            string line = stringReader.ReadLine();
            if (line == null)
            {
                break;
            }

            StageObject stageObject = new StageObject();
            // 스폰할 프리팹 종류, speed, delay, pos값 지정 
            /* 
            Prefab 종류
            0 = 장애물(바닥)
            1 = 장애물(위)
            2 = 아이템
            3 = 범인
            4 = 심볼
                
            Pos 위치
            0 = 위
            1 = 중앙
            2 = 아래
            */
            stageObject.PrefabObject = float.Parse(line.Split(',')[0]);
            stageObject.speed = float.Parse(line.Split(',')[1]);
            stageObject.delay = float.Parse(line.Split(',')[2]);
            stageObject.pos = float.Parse(line.Split(',')[3]);
            Debug.Log(stageObject.PrefabObject + " " + stageObject.speed + " " + stageObject.delay + " " + stageObject.pos);
            Debug.Log(stageObject);
            stages.Add(stageObject);
        }
        stringReader.Close();
        
        Debug.Log("total Obejct : " + stages.Count);
        return stages;
    }
}
