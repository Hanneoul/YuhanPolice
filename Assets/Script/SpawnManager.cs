using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SpawnManager : MonoBehaviour
{
    public List<Stage> stages;
    public GameObject[] spawnPoints;
    public GameObject[] hurdles;
    public int spawnIndex;
    public bool spawnEnd;

    public float curSpawnDelay;
    public float nextSpwanDelay;
    private void Awake()
    {
        stages = new List<Stage>();
        ReadSpawnFile();
    }

    void ReadSpawnFile()
    {
        stages.Clear();
        spawnIndex = 0;
        spawnEnd = false;

        TextAsset stageData = Resources.Load("stage0") as TextAsset;
        StringReader stringReader = new StringReader(stageData.text);
        
        while(stringReader != null)
        {
            string line = stringReader.ReadLine();
            if (line == null)
            {
                break;
            }

            Debug.Log(line);

            Stage stage = new Stage();
            stage.delay = float.Parse(line.Split(',')[0]);
            stage.type = line.Split(',')[1];
            stage.pos = float.Parse(line.Split(',')[2]);

            //Debug.Log(stage.SpawnDelay + " " + stage.SpawnSpeed + " " + stage.SpawnPoint);
            //Debug.Log(stage);
            stages.Add(stage);
        }
        stringReader.Close();

        nextSpwanDelay = stages[0].delay;

    }

    public void spawn() {
        // int index = 0;
        int hurdleNum = 0;
        switch(stages[spawnIndex].type) {
            case "S":
            hurdleNum = 0;
                break; 
            case "M":
            hurdleNum = 1;
                break; 
        }
        int spawnNum = (int) stages[spawnIndex].pos -1;
        GameObject temp = Instantiate(hurdles[hurdleNum], spawnPoints[spawnNum].transform.position, Quaternion.identity);
        
        // Rigidbody rb = test1.GetComponent<Rigidbody>();
        // Player player = test1.GetComponent<Player>();
        // player.speed = stages[spawnIndex].SpawnSpeed;
        // player.point = stages[spawnIndex].SpawnPoint;

        spawnIndex++;
        // index++;
        if(spawnIndex >= stages.Count) {
            spawnEnd = true;
            return;
        }
        nextSpwanDelay = stages[spawnIndex].delay;

    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        curSpawnDelay += Time.deltaTime;
        if(curSpawnDelay > nextSpwanDelay && !spawnEnd) {
            spawn();    
            curSpawnDelay = 0;
        }
        
    }
}
