using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using static UnityEngine.Mathf;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private GameObject PolePrefab;
    [SerializeField] private List<GameObject> PlanePrefab;
    [SerializeField] private GameObject FinishPrefab;
    [SerializeField] private GameObject SpikePrefab;

    private static LevelManager manager;
    private int _planesInLevel;
    private GameObject[] plane;
    private GameObject pole;
    private float rotationFactor = 360f;
    private int planesPassed;


    public static LevelManager levelManager => manager;
    public  GameObject Pole => pole;
    public void OnLevelFinished()
    {
        GameManager.NextLevel();
    }

    public int PlanesInLevel => _planesInLevel;
    public int PlanesPassed => planesPassed;

    void Start()
    {
        manager = GetComponent<LevelManager>();

        pole = Instantiate(PolePrefab, Vector3.zero, Quaternion.identity);

        //инициализация платформочек вот вот этих вот вот
        int planesCount = FloorToInt(Log(GameManager.Level*GameManager.Level + 2, 2));
        plane = new GameObject[planesCount+1];

        pole.transform.localScale = new Vector3(pole.transform.localScale.x, planesCount * 2,
            pole.transform.localScale.z);

        //заполним массив плиточек
        for (int i = 0; i != planesCount; i++)
        {
            plane[i] = Instantiate(PlanePrefab[Random.Range(0, PlanePrefab.Capacity)],
                       new Vector3(0,-i<<1,0), Quaternion.Euler(0,Random.Range(0,360), 0));

            //ебучая хуйня изза которой всё ломается
            /*if (Random.Range(0f, 1f) > 0.5f)
            {
                print("SPIKE!!");
                GameObject spike = Instantiate(SpikePrefab, 
                    new Vector3(0, (-i << 1) + 0.25f, 0),
                    Quaternion.Euler(0, Random.Range(0, 360), 0));
            }*/

            plane[i].transform.parent = pole.transform;
        }
        plane[planesCount - 1] = Instantiate(FinishPrefab, new Vector3(0, - planesCount << 1, 0), Quaternion.identity);
        

        _planesInLevel = plane.Length;

    }

    private void FixedUpdate()
    {
        if (planesPassed < _planesInLevel && Player.p.transform.position.y < plane[planesPassed].transform.position.y)
        {
            planesPassed++;
            pole.GetComponent<PoleFade>().PlanePassed();
        }
    }

    public void RotatePole(float k)
    {
        pole.transform.rotation = Quaternion.Euler(0,
            rotationFactor * k * Time.deltaTime + pole.transform.rotation.eulerAngles.y,
            0);
    }
}
