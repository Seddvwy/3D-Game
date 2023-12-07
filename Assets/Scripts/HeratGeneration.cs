using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeratGeneration : MonoBehaviour
{
    public GameObject Heart;
    public int xPos;
    public int zPos;

    public int HeartCount;

    void Start()
    {
        StartCoroutine(HeartDrop());
    }

    IEnumerator HeartDrop()
    {
        while (HeartCount < 5)
        {
            xPos = Random.Range(50, 91);
            zPos = Random.Range(22, 70);
            Instantiate(Heart, new Vector3(xPos, 23.5f, zPos), Quaternion.identity);
            yield return new WaitForSeconds(0.07f);
            HeartCount += 1;
        }
    }


}
