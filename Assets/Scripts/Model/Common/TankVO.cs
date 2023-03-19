using System.Collections;
using System.Collections.Generic;
using Common;
using SimpleJSON;
using UnityEngine;

public class TankVO : BaseVO
{
    public TankInfo GetTankInfo(int level)
    {
        JSONArray dataArray = Data.AsArray;
        if (level > dataArray.Count)
        {
            level = dataArray.Count;
        }

        return JsonUtility.FromJson<TankInfo>(dataArray[level - 1].ToString());
    }
}
