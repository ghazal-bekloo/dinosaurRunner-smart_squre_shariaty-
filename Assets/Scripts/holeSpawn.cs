using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class holeSpawn : MonoBehaviour
{
    public float maxTime =1;
    private float timer=0;
    public GameObject[] hole;
    // Start is called before the first frame update
    void Start()
    {
        GameObject newhole = Instantiate(hole[Random.Range(0,hole.Length)]);
        newhole.transform.position= transform.position+new Vector3(0,0,0);
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > maxTime)
        {
        GameObject newhole = Instantiate(hole[Random.Range(0,hole.Length)]);
        newhole.transform.position= transform.position+new Vector3(0,0,0);
        Destroy(newhole,18);
        timer=0;
        }
        timer+=Time.deltaTime;
    }
}
