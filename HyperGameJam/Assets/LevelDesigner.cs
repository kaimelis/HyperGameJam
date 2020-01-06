using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LevelDesigner : MonoBehaviour
{
    public int pieCount;

    private const int pieSlicesPerPie = 14;
    const float degreePerSlice = (float)360 / (float)pieSlicesPerPie;

    private const float gap = -5f;

    private List<List<Slice>> level;
    private GameObject goal;
    private GameObject pole;
    private Transform parent;

    //svoriai - koks sansas tokiam tie
    private const int rewardTileWeight = 10;
    private const int stoneTileWeight = 20;
    private const int normalTileWeight = 100;

    private const int deadlyTileMinWeight = 30;
    private const int deadlyTileMaxWeight = 70;

    const int minGapCount = 1;
    const int maxGapCount = 2;


    public List<GameObject> prefs;
    public GameObject centerPolePref;
    public GameObject goalPrefab; 
    public void Generate()
    {
        if (parent != null)
            DestroyImmediate(parent.gameObject);

        parent = new GameObject().transform;
        parent.gameObject.name = "Level";

        level = new List<List<Slice>>();


        for (int i = 0; i < pieCount-1; i++)
        {

            CreatePie(i);
        }

        CreateGoal(pieCount-1);
        CreateMidPole(pieCount, centerPolePref);
    }

    void CreateGoal(int pieId)
    {
        Vector3 pos = new Vector3(0, pieId * gap, 0);

        goal = Instantiate(goalPrefab, pos, Quaternion.identity,parent);
    }
    void CreatePie(int pieId)
    {
        level.Add(new List<Slice>());
        int emptyPosCount = Random.Range(minGapCount, maxGapCount+1);
        int emptyCounter = 0;
        List<int> scrambledPos = GetEmptyPos(pieSlicesPerPie);

        GameObject pie = new GameObject();
        pie.name = "pie";
        pie.transform.parent = parent;

        for (int i = 0; i < pieSlicesPerPie; i++)
        {
            if (!CheckIfSkipSlice(ref emptyCounter, emptyPosCount, scrambledPos, i))
            {
                Vector3 pos = new Vector3(0, pieId * gap, 0);
                Quaternion rot = Quaternion.Euler(new Vector3(0, i * degreePerSlice, 0));

                Slice slice;
                SliceType sliceType = GetSliceType(pieCount,pieId);
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

                slice = slice.Create(pos, rot, pie.transform, slice.GetType(),prefs[(int) sliceType]);

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

    SliceType GetSliceType(int totalCount, int currentCount)
    {
       int r = Random.Range(0, normalTileWeight+1);

        float deadlyTileWeight = Mathf.Lerp((float)deadlyTileMinWeight, (float)deadlyTileMaxWeight,
             (float) currentCount/ (float)totalCount);
   
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

    void CreateMidPole(int pieCount,GameObject centerPolePref)
    {
        Vector3 scale = new Vector3(3, (((pieCount - 1) * Mathf.Abs(gap)) / 2) + 2, 3);
        Vector3 pos = new Vector3(0, (pieCount - 1) * gap / 2, 0);

        pole = Instantiate(centerPolePref, pos,Quaternion.identity);
        pole.transform.localScale = scale;
        pole.transform.parent = parent;
        pole.name = "Pole";
    }
}
