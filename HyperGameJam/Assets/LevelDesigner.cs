using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using UnityEngine;

public class LevelDesigner : MonoBehaviour
{
    public int pieCount;
    public GameObject pref;

    private const int pieSlicesPerPie = 8;
    const float degreePerSlice = 360 / pieSlicesPerPie;

    private const float gap = -5f;

    private List<List<Slice>> level;
    private GameObject pole;
    private Transform parent;

    //svoriai - koks sansas tokiam tie
    private const int rewardTileWeight = 10;
    private const int stoneTileWeight = 30;
    private const int deadlyTileWeight = 40;
    private const int normalTileWeight = 100;

    public List<GameObject> prefs;
    public void Generate()
    {
        if (parent != null)
            DestroyImmediate(parent.gameObject);

        if(pole != null)
            DestroyImmediate(pole);

        parent = new GameObject().transform;
        level = new List<List<Slice>>();


        for (int i = 0; i < pieCount; i++)
        {

            CreatePie(i);
        }

        CreateMidPole(pieCount);
    }

    void CreatePie(int pieId)
    {
        level.Add(new List<Slice>());
        int emptyPosCount = Random.Range(1, 4);
        int emptyCounter = 0;
        List<int> scrambledPos = GetEmptyPos(pieSlicesPerPie);

        for (int i = 0; i < pieSlicesPerPie; i++)
        {
            if (!CheckIfSkipSlice(ref emptyCounter, emptyPosCount, scrambledPos, i))
            {
                Vector3 pos = new Vector3(0, pieId * gap, 0);
                Quaternion rot = Quaternion.Euler(new Vector3(0, i * degreePerSlice, 0));

                Slice slice;
                SliceType sliceType = GetSliceType();
                switch (sliceType)
                {
                    case SliceType.NORMAL:
                        slice = new SliceNormal();
                        break;
                    case SliceType.DEADLY:
                        slice = new SliceDeadly();
                        break;
                    case SliceType.STONE:
                        slice = new SliceStone();
                        break;
                    case SliceType.REWARD:
                        slice = new SliceReward();
                        break;
                    default:
                        slice = new SliceNormal();
                        break;
                }

                slice.Create(pos, rot, parent, sliceType, prefs[(int) sliceType]);

                level[pieId].Add(slice);
            }
        }
    }

    bool CheckIfSkipSlice(ref int emptyCounter, int emptyPosCount,List<int> scrambledPos,int posToCheck)
    {

        if (emptyCounter < emptyPosCount)
        {
            for (int j = 0; j < emptyPosCount; j++)
            {
                if (posToCheck == scrambledPos[j])
                {
                    emptyCounter++;
                    return true;
                }

            }
        }
        return false;

    }

    SliceType GetSliceType()
    {
       int r = Random.Range(0, 101);
       if (r <= rewardTileWeight)
           return SliceType.STONE;
       else if (r > rewardTileWeight && r <= stoneTileWeight)
           return SliceType.REWARD;
       else if (r > stoneTileWeight && r <= deadlyTileWeight)
           return SliceType.DEADLY;
       else
           return SliceType.NORMAL;
    }

    List<int> GetEmptyPos(int pieCount)
    {
        List<int> pos = new List<int>();
        for (int x = 0; x < pieCount; x++)
        {
            pos.Add(x);
        }

        System.Random rnd = new System.Random();
        var randomizedList = (from item in pos
            orderby rnd.Next()
            select item).ToList<int>();

        return randomizedList;
    }

    void CreateMidPole(int pieCount )
    {
        pole = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        pole.transform.localScale =new Vector3(3, (((pieCount-1) * Mathf.Abs(gap))/2)+2,3);
        pole.transform.localPosition = new Vector3(0, (pieCount-1) * gap / 2, 0);

    }
}
