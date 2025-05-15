using UnityEditor;
using UnityEngine;


public class LoopS : CheckScene
{
    public static int level;
    public static GameObject[] allScene;
    public static GameObject sceneP;
    //public GameObject nextScenePrefab;  //test
    public int _nextSpawnPoint = 20;
    public static int nextSpawnPoint;
    private Vector3 spawnPoint;
    private LoopScene _LoopScene;

    private void Start()
    {

        _LoopScene = GameObject.FindGameObjectWithTag("GameManager").GetComponent<LoopScene>();
        nextSpawnPoint = _nextSpawnPoint;
        //Debug.Log("LoopS s: " + _csLoopScene._allScenePrefab.Length);

    }

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("==========test==========");
        if (other.tag == "Player")
        {
            sceneP = gameObject.transform.parent.parent.gameObject;
            spawnPoint = sceneP.transform.position;
            allScene = GameObject.FindGameObjectsWithTag("Scene");

            //Debug.Log(sceneP);
            TagManager(sceneP);
            _LoopScene.NextLevel();

            CheckSpawnPoint(spawnPoint);

            //if (allScene.Length > 3)
            //{
            //    DestroyScene(allScene);
            //}


            //Destroy(sceneCount.Dequeue());
            //Debug.Log(sceneCount.Peek());
        }
    }

    public void CheckSpawnPoint(Vector3 spawnPoint)
    {
        spawnPoint.y += nextSpawnPoint;
        Debug.Log("this ScenenName: " + sceneP);
        if (VSPosition(spawnPoint))
        {
            InstantiateScene(spawnPoint);
        }

        //spawnPoint.y -= nextSpawnPoint + nextSpawnPoint;
        //Debug.Log("this ScenenName: " + sceneP);

        //if (VSPosition(spawnPoint))
        //{
        //    InstantiateScene(spawnPoint);
        //}
    }

    public void InstantiateScene(Vector3 spawnPoint)
    {
        Debug.Log("Instantiate Scene Name: " + Instantiate(_LoopScene._allScenePrefab[LoopScene._LevelCount - 1], spawnPoint, Quaternion.identity));
    }

    public static int TagManager(GameObject sceneOBJ)
    {
        if (sceneOBJ.GetComponent<Level_1>() != null)
        {
            level = 1;
        }
        else
        if (sceneOBJ.GetComponent<Level_2>() != null)
        {
            level = 2;
        }
        else
        if (sceneOBJ.GetComponent<Level_3>() != null)
        {
            level = 3;
        }
        else
        if (sceneOBJ.GetComponent<Level_3>() != null)
        {
            level = 4;
        }
        else
        {
            Debug.Log("no level!!!");

        }
        Debug.Log("level: " + level);

        return level;
    }


    public bool VSPosition(Vector3 spawnPoint)
    {

        bool _cheakScene = true;
        //Debug.Log("_allScene.Length: " + _allScene.Length);

        for (int i = 0; i < allScene.Length; i++)
        {
            Debug.Log(" SceneSpawnPoint Y: " + spawnPoint);
            //Debug.Log(i + ": " +  _allScene[i].name + " position: " + _allScene[i].transform.position + " spawnPoint: " + spawnPoint.y);
            if (allScene[i].transform.position.y == spawnPoint.y)
            {
                Debug.Log(LoopScene._LevelCount);
                Debug.Log(level);
                Debug.Log("Scene name: " + allScene[i] + " Scene level : " + TagManager(allScene[i]));
                if (level != LoopScene._LevelCount)
                {
                    if (level == TagManager(allScene[i]))
                    {
                        Destroy(allScene[i]);
                        Debug.Log("Destroy Scene: " + allScene[i]);

                        Instantiate(_LoopScene._allScenePrefab[LoopScene._LevelCount - 1], spawnPoint, Quaternion.identity);

                    }
                }
                _cheakScene = false;
            }

        }
        return _cheakScene;
    }

    //public void DestroyScene(GameObject[] allScene)
    //{
        
    //    Debug.Log(allScene.Length);
    //    for (int i = 0; i < allScene.Length; i++)
    //    {
    //        //
    //        var _playerScene = sceneP.transform.position.y;
    //        var _VSpointUP = _playerScene + nextSpawnPoint;
    //        var _VSpointDOWN = _playerScene - (nextSpawnPoint + nextSpawnPoint);

    //        if ((allScene[i].transform.position.y != _playerScene) &&(allScene[i].transform.position.y != _VSpointUP) &&(allScene[i].transform.position.y != _VSpointDOWN))
    //        {
    //            Debug.Log(allScene[i]);
    //            Destroy(allScene[i]);
    //        }

    //    }
    //}
}
