using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateA : MonoBehaviour
{
    float maxTimer = 0.5f;
    float timer = 0.0f;

    RefactoredGameController rGameController;

    // Start is called before the first frame update
    void Start()
    {
        rGameController = GameObject.FindAnyObjectByType<RefactoredGameController>(); 
    }

    // Update is called once per frame
    void Update()
    {
        if (!Wait())
        {
            //Shoot();
            //Decal();
            //CalculateScore();
            CalculateGameOver();
        }
    }
    bool Wait()
    {
        if(timer >= maxTimer)
        {
            timer = 0.0f;
            return true;
        }
        else
        {
            timer += Time.deltaTime;
            return false;
        }
    }
    void ShootNDecalNCalculateScore()
    {    

        rGameController.ProcessShot(transform.position);
    }
    /*void Decal()
    {
        //rGameController.SetMark()
    }
    void CalculateScore()
    {

    }*/
    void CalculateGameOver()
    {

    }
}
