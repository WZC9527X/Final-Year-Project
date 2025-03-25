using UnityEngine;


public class LoopS : MonoBehaviour
{
   
    //public GameObject nextScenePrefab;  //test
    public int nextSpawnPoint = 20;
    private Vector3 spawnPoint;
    private GameObject[] _allScene;
    private LoopScene _csLoopScene;

    private void Start()
    {

        _csLoopScene = GameObject.FindGameObjectWithTag("GameManager").GetComponent<LoopScene>();

        //Debug.Log("LoopS s: " + _csLoopScene._allScenePrefab.Length);

    }

    private void OnTriggerEnter(Collider other)
    {

        //Debug.Log("==========test==========");
        if (other.tag == "Player")
        {
            spawnPoint = gameObject.transform.parent.parent.position;
            //Debug.Log(gameObject.transform.parent.parent);

            _allScene = GameObject.FindGameObjectsWithTag("Scene");
            spawnPoint.y += nextSpawnPoint;

            if (VSPosition())
            {
                _csLoopScene.NextLevel();

                GameObject sceneOBJ = Instantiate(_csLoopScene._allScenePrefab[LoopScene._LevelCount - 1], spawnPoint, Quaternion.identity);

                //GameObject sceneOBJ = Instantiate(nextScenePrefab, spawnPoint, Quaternion.identity);

                //sceneCount.Enqueue(sceneOBJ_UP);
                //gameObject.SetActive(false);
                //Debug.Log("spawnPoint: " + sceneOBJ.transform.position + " Scene name: " + sceneOBJ.name);

            }


            spawnPoint.y -= nextSpawnPoint + nextSpawnPoint;
            
            if (VSPosition())
            {
                _csLoopScene.NextLevel();

                GameObject sceneOBJ = Instantiate(_csLoopScene._allScenePrefab[LoopScene._LevelCount - 1], spawnPoint, Quaternion.identity);
                //sceneCount.Enqueue(sceneOBJ_UP);
                //gameObject.SetActive(false);
                //Debug.Log("spawnPoint: " + sceneOBJ.transform.position + " Scene name: " + sceneOBJ.name);

            }





            //if (sceneCount.Count >= 4)
            //{
            //    Destroy(sceneCount.Dequeue());
            //    Destroy(sceneCount.Dequeue());
            //}


            //Debug.Log(sceneCount.Dequeue());


            //Debug.Log(sceneCount.Peek());
            //_sceneCount++;

            //Debug.Log(_sceneCount);


        }
    }

    public bool VSPosition()
    {
        bool cheakSceneUP = true;
        //Debug.Log("_allScene.Length: " + _allScene.Length);

        for (int i = 0; i < _allScene.Length; i++)
        {
            //Debug.Log(i + ": " +  _allScene[i].name + " position: " + _allScene[i].transform.position + " spawnPoint: " + spawnPoint.y);
            if (_allScene[i].transform.position.y == spawnPoint.y)
            {
                //Debug.Log("y");
                cheakSceneUP = false;
            }
        }
        return cheakSceneUP;
    }
}
