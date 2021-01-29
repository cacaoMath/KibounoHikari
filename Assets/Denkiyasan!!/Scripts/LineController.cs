using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineController : MonoBehaviour
{
    public PlayerController player;
    GameObject[] Hikari;
    LineRenderer line;
    // Start is called before the first frame update
    void Start()
    {
        Hikari = player.GetTouchedHikari();
        line = GetComponent<LineRenderer>();
        line.startWidth = 0.1f;
        line.endWidth = 0.1f;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Hikari = player.GetTouchedHikari();
        if (Hikari[0] != null && Hikari[1] != null)
        {
            line.SetPosition(0, Hikari[0].transform.position);
            line.SetPosition(1, Hikari[1].transform.position);
        }
    }
}
