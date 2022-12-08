using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ObjectManager : MonoBehaviour
{
    public GameManager gameManager;
    // Stage 별 생성할 Object 배열
    public List<StageObject> stages;
    // Prefab 스폰 위치 ( 위, 중앙, 아래 )
    public GameObject[] spawnPoints;
    // Prefab 종료
    public GameObject[] PrefabList;
    // 현재 스폰된 순서
    public int spawnIndex;
    
    public float curSpawnDelay;
    public float nextSpwanDelay;

    public int stageNum;
    // Stage 종료여부 체크
    public bool spawnEnd;

    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        ReadSpawnFile();
    }
    void ReadSpawnFile()
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
            0 = 장애물(바닥) tag : block
            1 = 장애물(위)   tag : block
            2 = 아이템       tag : Item
            3 = 범인         tag : Enemy
            4 = 심볼         tag : ?
                
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
        nextSpwanDelay = stages[0].delay;
        Debug.Log("total Obejct : " + stages.Count);
    }


    public void spawn() {
        // int index = 0;
        int hurdleNum = 0;
        switch(stages[spawnIndex].PrefabObject) {
            case 0:
            // 장애물 하단
                hurdleNum = 0;
                break; 
            case 1:
            // 장애물 상단
                hurdleNum = 1;
                break; 
            case 2:
            // 아이템
                hurdleNum = 2;
                break;
            case 3:
            // todo 범인 스폰 GAMEMANAGER와 연동해서 체크
                hurdleNum = 3;
                break;
            case 4:
            // todo 심볼 스폰
                hurdleNum = 4;
                break;
        }
        int spawnNum = (int) stages[spawnIndex].pos;
        GameObject spawnObejct = Instantiate(PrefabList[hurdleNum], spawnPoints[spawnNum].transform.position, Quaternion.identity);
        hurdle hurdle = spawnObejct.GetComponent<hurdle>();
        hurdle.speed = (int) stages[spawnIndex].speed;
        if(hurdleNum == 3) {
            gameManager.isEenmy = true;
        }
        spawnIndex++;
        // index++;
        if(spawnIndex >= stages.Count) {
            spawnEnd = true;
            return;
        }
        nextSpwanDelay = stages[spawnIndex].delay;

    }

    void Update() {
        curSpawnDelay += Time.deltaTime;
        if(curSpawnDelay > nextSpwanDelay && !spawnEnd && !gameManager.isEenmy && !gameManager.isOpening) {
            spawn();    
            curSpawnDelay = 0;
        }

    }
}
