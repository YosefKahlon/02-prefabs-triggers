using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class RandomShields : MonoBehaviour
{       

    [SerializeField] Mover prefabToSpawn;
    GameObject myPrefab;
    GameObject player;

    [SerializeField] Vector3 velocityOfSpawnedObject;
    [Tooltip("Minimum time between consecutive spawns, in seconds")][SerializeField] float minTimeBetweenSpawns = 1f;
    [Tooltip("Maximum time between consecutive spawns, in seconds")][SerializeField] float maxTimeBetweenSpawns = 3f;
    [Tooltip("Maximum distance in X between spawner and spawned objects, in meters")][SerializeField] float maxXDistance = 2;


    // Start is called before the first frame update
    void Start()
    {
        this.StartCoroutine(SpawnRoutine());    // co-routines

    }
    IEnumerator SpawnRoutine()
    {    // co-routines

        while (true)
        {
            myPrefab = GameObject.FindWithTag("Shield");
            player = GameObject.FindWithTag("Player");

            var destroyComponent = player.GetComponent<DestroyOnTrigger2D>();

            if (myPrefab == null && destroyComponent.enabled == false)
            {

                //wait for this commponnt 
                yield return new WaitUntil(() => destroyComponent.enabled);
            }
            if (myPrefab == null) {
                Debug.Log("Shield triggered by player");
                float timeBetweenSpawns = Random.Range(minTimeBetweenSpawns, maxTimeBetweenSpawns);
                
                
                yield return new WaitForSeconds(timeBetweenSpawns);
                Vector3 pos = new Vector3(transform.position.x + 4,
                   transform.position.y + 1,
                   transform.position.z
                   );
                Debug.Log("POS --> " + pos);

                GameObject newObject = Instantiate(prefabToSpawn.gameObject, pos, Quaternion.identity);



           }

            if (myPrefab != null)
            {
                myPrefab = GameObject.FindWithTag("Shield");
                myPrefab = null;
                yield return new WaitUntil(() => (myPrefab == null));

            }







            
        }



    }
}
