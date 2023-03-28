using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckPoint : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            var p = other.gameObject.transform.position;
            string scene = SceneManager.GetActiveScene().name;
            other.GetComponent<PlayerRespawn>().ReachedCheckPoint(scene, p.x, p.y, p.z);
            this.gameObject.AddComponent<Rigidbody>();//This line adds a component on runtime
            Destroy(this, 1f);
        }
    }
}
