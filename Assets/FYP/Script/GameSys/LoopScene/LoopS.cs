using UnityEditor;
using UnityEngine;


public class LoopS : CheckScene
{
   
    //public GameObject nextScenePrefab;  //test
    public int nextSpawnPoint = 20;
    private Vector3 spawnPoint;
    private LoopScene _LoopScene;
    //public static GameObject[] sceneOBJ1;
    //public static GameObject[] sceneOBJ2;

    private void Start()
    {

        _LoopScene = GameObject.FindGameObjectWithTag("GameManager").GetComponent<LoopScene>();
        
        //Debug.Log("LoopS s: " + _csLoopScene._allScenePrefab.Length);

    }

    private void OnTriggerEnter(Collider other)
    {

        //Debug.Log("==========test==========");
        if (other.tag == "Player")
        {
            spawnPoint = gameObject.transform.parent.parent.position;
            //Debug.Log(gameObject.transform.parent.parent);

            _LoopScene.NextLevel();

            spawnPoint.y += nextSpawnPoint;
            if (VSPosition(spawnPoint.y))
            {
                Instantiate(_LoopScene._allScenePrefab[LoopScene._LevelCount - 1], spawnPoint, Quaternion.identity);
                //sceneOBJ1[LoopScene._LevelCount] = Instantiate(_LoopScene._allScenePrefab[LoopScene._LevelCount - 1], spawnPoint, Quaternion.identity);

                //GameObject sceneOBJ = Instantiate(nextScenePrefab, spawnPoint, Quaternion.identity);

                //sceneCount.Enqueue(sceneOBJ_UP);
                //gameObject.SetActive(false);
                //Debug.Log("spawnPoint: " + sceneOBJ.transform.position + " Scene name: " + sceneOBJ.name);

            }

            _LoopScene.NextLevel();

            spawnPoint.y -= nextSpawnPoint + nextSpawnPoint;
            if (VSPosition(spawnPoint.y))
            {
                Instantiate(_LoopScene._allScenePrefab[LoopScene._LevelCount - 1], spawnPoint, Quaternion.identity);
                //sceneOBJ2[LoopScene._LevelCount] = Instantiate(_LoopScene._allScenePrefab[LoopScene._LevelCount - 1], spawnPoint, Quaternion.identity);
                
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


}
