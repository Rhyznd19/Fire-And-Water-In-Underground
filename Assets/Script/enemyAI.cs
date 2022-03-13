using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// mengambil compenent 
[RequireComponent(typeof(BoxCollider2D))]
public class enemyAI : MonoBehaviour
{

    //waypoint referance
    public List<Transform> points;
    //value untuk index baru
    public int nextID = 0;
    //nilai agar Id berubah
    int idChangeValue = 1;
    public float speed = 2f;


    private void Reset()
    {
        Init();
    }

    //method inisiasi agar langsung bisa dipake ketika mengambilnya
    void Init()
    {
        //membuat boxcollider2D
        GetComponent<BoxCollider2D>().isTrigger = true;

        //membuat root dari object yang dipakai
        GameObject root = new GameObject(name + "_Root");
        //mereset posisi root dari object
        root.transform.position = transform.position;
        //membuat object menjadi child
        transform.SetParent(root.transform);
        //membuat object waypoint baru
        GameObject waypoints = new GameObject("Waypoints");
        //membuat waypoint jadi child dari root
        waypoints.transform.SetParent(root.transform);
        waypoints.transform.position = root.transform.position;
        //membuat dua object baru dan menjadikannya child dari waypoint
        GameObject p1 = new GameObject("Point1"); p1.transform.SetParent(waypoints.transform); p1.transform.position = root.transform.position;
        GameObject p2 = new GameObject("Point2"); p2.transform.SetParent(waypoints.transform); p2.transform.position = root.transform.position;

        //memasukkan point waypoint ke list
        points = new List<Transform>();
        points.Add(p1.transform);
        points.Add(p2.transform);
    }

    private void Update()
    {
        Move();
    }

    //method pergerakan enemy
    private void Move()
    {
        //mengambil point perpindahan selanjutnya
        Transform goalPoint = points[nextID];
        //flip musuh 
        if (goalPoint.transform.position.x > transform.position.x)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else
        {
            transform.localScale = new Vector3(1, 1, 1);
        }

        //musuh bergerak ke waypoint yang ditentukan
        transform.position = Vector2.MoveTowards(transform.position, goalPoint.position, speed * Time.deltaTime);
        //jarak sebelum berpindah ke waypoint selanjutnya
        if (Vector2.Distance(transform.position, goalPoint.position) < 0.2f)
        {
            //jika di akhir garis ID  = -1
            if (nextID == points.Count - 1)
                idChangeValue = -1;
            //jika di awal garis ID = 1
            if (nextID == 0)
                idChangeValue = 1;
            nextID += idChangeValue;
        }
    }
}
