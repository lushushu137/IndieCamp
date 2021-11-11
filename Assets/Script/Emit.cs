using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Emit : MonoBehaviour
{
    public GameObject spiderMesh;
    public Transform spiderMuzzle;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("j")) {
            GameObject newMesh = Instantiate(spiderMesh, spiderMuzzle.position, spiderMuzzle.rotation);
        }
        
    }
}
