using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ballresetter : MonoBehaviour
{
    public GameObject Ball;
    public GameObject BallHolder;

    GameObject oldBall;
    GameObject oldHolder;

    bool BallExists;

    public void ResetBall()
    {
        if (BallExists == false)
        {
            BallExists = true;
            oldHolder = Instantiate(BallHolder, new Vector3(1.124f, 0.762499f, 0.544f), new Quaternion(0, 0, 0, 0));
            oldBall = Instantiate(Ball, new Vector3(1.124f, 0.808f, 0.544f), new Quaternion(0, 0, 0, 0));
        }
        else
        {
            Destroy(oldBall);
            Destroy(oldHolder);
            oldHolder = Instantiate(BallHolder, new Vector3(1.124f, 0.762499f, 0.544f), new Quaternion(0, 0, 0, 0));
            oldBall = Instantiate(Ball, new Vector3(1.124f, 0.808f, 0.544f), new Quaternion(0, 0, 0, 0));
        }
    }
}
