using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level01Manager : MonoBehaviour
{
    public Transform[] badSpaw;
    public GameObject  badPrefabs;

    public int badWaves = 3;

    public float waitTimeFirstWave = 2f;
    public float waitTimeBetweenWaves = 4f;

    
        void Start()
    {
        StartCoroutine(SpawnBad());
    }

   IEnumerator SpawnBad()
   {
       yield return new WaitForSeconds(waitTimeFirstWave);
             
       for(int i=0;i< badWaves; i++)
       {
           for (int j = 0; j< badSpaw.Length; j++)
           {
               Instantiate(badPrefabs, badSpaw[j].position, Quaternion.identity);
           }
           yield return new WaitForSeconds(waitTimeBetweenWaves);

       }
   }
}
