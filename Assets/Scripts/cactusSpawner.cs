
using UnityEngine;

public class cactusSpawner : MonoBehaviour
{
    public float maxTime =5;
    private float timer=0;
    public GameObject[] cactus;
    // Start is called before the first frame update
    void Start()
    {
        GameObject newcactus = Instantiate(cactus[Random.Range(0,cactus.Length)]);
        newcactus.transform.position= transform.position+new Vector3(0,0,0);
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > maxTime)
        {
             GameObject newcactus = Instantiate(cactus[Random.Range(0,cactus.Length)]);
        newcactus.transform.position= transform.position+new Vector3(0,0,0);
        Destroy(newcactus,18);
        timer=0;
        }
        timer+=Time.deltaTime;
    }
}
