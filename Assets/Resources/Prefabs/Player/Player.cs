using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Player : MonoBehaviour
{
    public static Player p;

    private Rigidbody rigidbody;
    void Start()
    {
        if (p != null) throw new UnityException();
        rigidbody = GetComponent<Rigidbody>();
        p = this;

        rigidbody.AddForce(new Vector3(0,-1,0) * 320);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (Mathf.Abs(transform.position.y - collision.transform.position.y) <= 0.25f) return;
        rigidbody.AddForce(Vector3.up * 320);
        if (collision.gameObject.tag == "Finish")
            LevelManager.levelManager.OnLevelFinished();
    }


    void Update()
    {
        float rotY = Input.GetAxis("Horizontal");

        LevelManager.levelManager.RotatePole(rotY);
    }
}
