using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.VFX;

public class GameController : MonoBehaviour
{
    //Platform gameobject
    [Header("Platform Object")] 
    public GameObject platform;
    //Default position for platform
    float pos = 0;
    //Game over Canvas
    [Header("Game Over UI Canvas Object")]
    public GameObject gameOverCanvas;
    // Start is called before the first frame update
    [Header("position")]
    public float position;
    void Start()
    {
        //Interger i equls 1000
        for (int i = 0; i < 1000; i++)
        {
            //Execute SpawnPlatforms
            SpawnPlatforms();
        }
        //Spawn platforms function
        


    }
    void SpawnPlatforms()
    {
        pos += position;
        //Spawn platforms randomly on the X axisand place them on the Y axis every 2.5
        Instantiate(platform, new Vector3(Random.value * 10 - 5F, pos, 0.5f), Quaternion.identity);
        pos += 2.5f;
}

public void GameOver()
{
        //Game Over Canvas is active
        gameOverCanvas.SetActive(true);
}
}