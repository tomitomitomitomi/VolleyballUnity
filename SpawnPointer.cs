using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Spawns Power-Ups.
/// </summary>

public class SpawnPointer : MonoBehaviour
{
    [SerializeField]
    private GameObject PowerUp;
    public Vector2 spawnValues;
    private PowerUp1 PowerUp1;

    [SerializeField]
    private int powerUpCount;
    [SerializeField]
    private float spawnWait = 1f;
    [SerializeField]
    private float startWait = 1f;
    [SerializeField]
    private float waveWait;
    private float lenX;
    private float lenY;
    [SerializeField]
    private float maxY;
    [SerializeField]
    private float minY;
    private int random;
    [SerializeField]
    private float spawnKill;
    private GameObject clone;



    void Start()
    {
        StartCoroutine(SpawnPowerUps());
        lenX = Random.Range(-spawnValues.x, spawnValues.x);
        lenY = Random.Range(minY, maxY);

    }

    IEnumerator SpawnPowerUps() //coroutine so startwait won't pause whole game = not void
    {
        
       /* random = (int)Random.Range(0, 1); //miskan juttu
        print("random value:" + random);
        
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            for (int i = 0; i < powerUpCount; i++)
            {
               
                {
                    
                    Vector2 spawnPosition = new Vector3(lenX, lenY, 0);
                   clone = Instantiate(PowerUp, spawnPosition, Quaternion.identity);
                    yield return new WaitForSeconds(spawnKill);
                    Destroy(clone);
                }
                
                yield return new WaitForSeconds(spawnWait);
               
            }
            yield return new WaitForSeconds(waveWait);
           

        }
        */
       yield return new WaitForSeconds(startWait); //pause before spawning starts
        while (true) //infinite loop
        {
            for (int i = 0; i < powerUpCount; i++) //every time cycling thru loop, spawn new
            {
                if (random == 0)
                {
                    Vector2 spawnPosition = new Vector3(lenX, lenY, 0);
                    Instantiate(PowerUp, spawnPosition, Quaternion.identity);

                }

                yield return new WaitForSeconds(spawnWait); //how often power-ups spawn

            }
            yield return new WaitForSeconds(waveWait);
         

        }
        
      
    }
    private void Update()
    {
        lenX = Random.Range(-spawnValues.x, spawnValues.x);
        lenY = Random.Range(minY, maxY);
    
        SpawnPowerUps();
        
        
       

      
     
    }
}