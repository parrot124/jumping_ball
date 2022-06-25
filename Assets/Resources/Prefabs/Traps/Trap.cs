using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using static LevelManager;

public class Trap : MonoBehaviour
{
    //тут должна быть логика шипа но мне впадлу чёто делать
    private void Start()
    {
        return;
        //while (!Physics.SphereCast(new Ray(transform.position, Vector3.down), 0.25f))
        //    transform.rotation = Quaternion.Euler(new Vector3(0, Random.Range(0, 360), 0));

        //gameObject.tag = "Trap";
        //transform.parent = levelManager.Pole.transform;
    }
}
