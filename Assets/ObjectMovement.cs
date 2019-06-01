using UnityEngine;
using System.Collections;

public class ObjectMovement : MonoBehaviour
{

    [SerializeField] bool xMovement;
    [SerializeField] bool yMovement;
    [SerializeField] bool zMovement;
    //public Vector3 startPos;
    //public Vector3 endPos;
    //public GameObject gameObjectOne;
    //float angleT;
    //float distanceH;
    //Vector3 pointThree;
    //float x;
    //bool moveObjectPosOne, moveObjectPosTwo;

    //public int speed;
    //IEnumerator Start()
    //{
    //    moveObjectPosOne = false;
    //    moveObjectPosTwo = false;
    //    yield return StartCoroutine(CalculateVariables());
    //}

    //double DistanceBetweenPoints(Vector3 vectorOne, Vector3 vectorTwo)
    //{
    //    double distance = Vector3.Distance(vectorOne, vectorTwo);
    //    return distance;
    //}


    //float GetAngleBetweenPoints(Vector3 vectorOne, Vector3 vectorTwo)
    //{
    //    float xDiff = vectorTwo.x - vectorOne.x;
    //    float yDiff = vectorTwo.z - vectorOne.z;
    //    return Mathf.Atan2(yDiff, xDiff) * (180 / Mathf.PI);
    //}

    //float CalculateX(float angle, float distance)
    //{
    //    float x = distance * Mathf.Cos(angle);
    //    return x;
    //}

    //IEnumerator CalculateVariables()
    //{
    //    gameObjectOne.transform.position = startPos;
    //    angleT = GetAngleBetweenPoints(startPos, endPos);
    //    distanceH = (float)DistanceBetweenPoints(startPos, endPos);
    //    x = CalculateX(angleT, distanceH);
    //    pointThree = new Vector3(startPos.x - x, startPos.y, startPos.z);
    //    yield return null;
    //}

    //// Update is called once per frame
    //float VecOne;
    //float VecTwo;
    //void Update()
    //{
    //    VecOne = Vector3.Distance(gameObjectOne.transform.position, pointThree);
    //    if (moveObjectPosOne)
    //    {
    //        gameObjectOne.transform.position = Vector3.MoveTowards(gameObjectOne.transform.position, pointThree, speed * Time.deltaTime);
    //        if (VecOne <= 0)
    //        {
    //            moveObjectPosOne = false;
    //            moveObjectPosTwo = true;
    //        }
    //    }
    //    if (moveObjectPosTwo)
    //    {
    //        gameObjectOne.transform.position = Vector3.MoveTowards(gameObjectOne.transform.position, endPos, speed * Time.deltaTime);

    //    }

    //}


    private Vector3 pos1 = new Vector3(4, 1, 0);
    private Vector3 pos2 = new Vector3(-4, 1, 0);
    private Vector3 pos3 = new Vector3(4, 1, 0);
    private Vector3 pos4 = new Vector3(4, 4, 0);
    private Vector3 pos5 = new Vector3(4, 1, 0);
    private Vector3 pos6 = new Vector3(4, 1, 4);

    public float speed = 3.0f;

    void Update()
    {
        if (xMovement)
            transform.position = new Vector3(Mathf.PingPong(Time.time * speed, 4), transform.position.y, transform.position.z);
        if (yMovement)
            transform.position = new Vector3(transform.position.x, Mathf.PingPong(Time.time * speed, 4) + 0.7f, transform.position.z);
        if (zMovement)
            transform.position = new Vector3(transform.position.x, transform.position.y, Mathf.PingPong(Time.time * speed, 4));
        if (xMovement && yMovement)
            transform.position = new Vector3(Mathf.PingPong(Time.time * speed, 4), Mathf.PingPong(Time.time * speed, 4) + 1, transform.position.z);
        if (xMovement && zMovement)
            transform.position = new Vector3(Mathf.PingPong(Time.time * speed, 4), 1, Mathf.PingPong(Time.time * speed, 4));
        if (yMovement && zMovement)
            transform.position = new Vector3(transform.position.x, Mathf.PingPong(Time.time * speed, 4) + 1, Mathf.PingPong(Time.time * speed, 4));
        if (xMovement && zMovement && yMovement)
        {
            transform.position = new Vector3(Mathf.PingPong(Time.time * speed, 4), Mathf.PingPong(Time.time * speed, 4) + 1, Mathf.PingPong(Time.time * speed, 4));
            transform.position = new Vector3(Mathf.PingPong(Time.time * speed, 4), Mathf.PingPong(Time.time * speed, 4) + 1, transform.position.z);
        }

    }


}
