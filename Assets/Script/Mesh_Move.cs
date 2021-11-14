using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mesh_Move : MonoBehaviour
{
      // Start is called before the first frame update
    public int speed = 5;
    public GameObject spiderMeshAfter;
    private Vector3 velocity;
    // private float destroyTime = 1.0f;
    private AudioSource audioSource;
    public AudioClip fx_shoot;
    
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.PlayOneShot(fx_shoot);

        velocity = transform.forward * speed;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position += velocity * Time.deltaTime;
    }

    void OnTriggerEnter(Collider other) {
        if (other.tag == "environment") {
            Debug.Log(other.name);
            GameObject newMesh = Instantiate(spiderMeshAfter);
            GameObject wall = GameObject.Find("wall");
            Vector3 pos = new Vector3(transform.position.x, transform.position.y, wall.transform.position.z);
            newMesh.transform.position = pos;
            Destroy(gameObject);
            
        }
    }
}
