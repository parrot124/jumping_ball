using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using static UnityEngine.Mathf;

public class PlayerFollow : MonoBehaviour
{
    private GameObject player;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        if (player == null) throw new UnityException();
    }

    void Update()
    {
        float delta = transform.position.y;
        if (Abs(player.transform.position.y - transform.position.y) > 2.3f || transform.position.y != player.transform.position.y)
            delta = Lerp(transform.position.y, player.transform.position.y, Time.deltaTime * 10);

        transform.position = new Vector3(transform.position.x, delta, transform.position.z);
    }
}
