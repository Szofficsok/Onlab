using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonGenerator : MonoBehaviour
{
    public class Cella
    {
        public bool latogatott = false;
        public bool[] stat = new bool[4];
    }

    public Vector2 meret;
    public int kezdoPont = 0;
    public GameObject[] szobak;
    public Vector2 leptek;

    List<Cella> palya;

    // Start is called before the first frame update
    void Start()
    {
        LabitintusGenerator();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void PalyaGenerator()
    {
        for (int i = 0; i < meret.x; i++)
        {
            for (int j = 0; j < meret.y; j++)
            {
                Cella aktualisCella = palya[Mathf.FloorToInt(i + j * meret.x)];
                if (aktualisCella.latogatott)
                {
                    int randomSzoba = Random.Range(0, szobak.Length);
                    var ujSzoba = Instantiate(szobak[randomSzoba], new Vector3(i * leptek.x, 0, -(j * leptek.y)), Quaternion.identity, transform).GetComponent<RoomBehavior>();
                    ujSzoba.UpdateRoom(aktualisCella.stat);

                    ujSzoba.name += " " + i + "-" + j;
                }
            }
        }
    }

    void LabitintusGenerator()
    {
        palya = new List<Cella>();

        for (int i = 0; i < meret.x; i++)
        {
            for (int j = 0; j < meret.y; j++)
            {
                palya.Add(new Cella());
            }
        }
        int aktualisCella = kezdoPont;

        Stack<int> utvonal = new Stack<int>();

        int seged = 0;

        while (seged < 1000)
        {
            seged++;

            palya[aktualisCella].latogatott = true;

            if (aktualisCella == palya.Count - 1)
            {
                break;
            }

            List<int> szomszedok = SzomszedVizsgalo(aktualisCella);

            if (szomszedok.Count == 0)
            {
                if (utvonal.Count == 0)
                {
                    break;
                }
                else
                {
                    aktualisCella = utvonal.Pop();
                }
            }
            else
            {
                utvonal.Push(aktualisCella);

                int ujCella = szomszedok[Random.Range(0, szomszedok.Count)];

                if (ujCella > aktualisCella)
                {
                    //also, jobb
                    if (ujCella - 1 == aktualisCella)
                    {
                        palya[aktualisCella].stat[2] = true;
                        aktualisCella = ujCella;
                        palya[aktualisCella].stat[3] = true;
                    }
                    else
                    {
                        palya[aktualisCella].stat[1] = true;
                        aktualisCella = ujCella;
                        palya[aktualisCella].stat[0] = true;
                    }
                }
                else
                {
                    //felso, bal
                    if (ujCella + 1 == aktualisCella)
                    {
                        palya[aktualisCella].stat[3] = true;
                        aktualisCella = ujCella;
                        palya[aktualisCella].stat[2] = true;
                    }
                    else
                    {
                        palya[aktualisCella].stat[0] = true;
                        aktualisCella = ujCella;
                        palya[aktualisCella].stat[1] = true;
                    }
                }
            }

        }
        PalyaGenerator();
    }

    List<int> SzomszedVizsgalo(int cella) 
    {
        List<int> szomszedok = new List<int>();
        //felso
        if (cella - meret.x >= 0 && !palya[Mathf.FloorToInt(cella-meret.x)].latogatott)
        {
            szomszedok.Add(Mathf.FloorToInt(cella - meret.x));
        }
        //also
        if (cella + meret.x < palya.Count && !palya[Mathf.FloorToInt(cella + meret.x)].latogatott)
        {
            szomszedok.Add(Mathf.FloorToInt(cella + meret.x));
        }
        //jobb
        if ((cella + 1) % meret.x != 0 && !palya[Mathf.FloorToInt(cella + 1)].latogatott)
        {
            szomszedok.Add(Mathf.FloorToInt(cella + 1));
        }
        //bal
        if (cella % meret.x != 0 && !palya[Mathf.FloorToInt(cella - 1)].latogatott)
        {
            szomszedok.Add(Mathf.FloorToInt(cella - 1));
        }

        return szomszedok;
    }
}
