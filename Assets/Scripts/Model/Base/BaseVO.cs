using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;

public class BaseVO
{
    private JSONNode data;
    protected JSONNode Data
    {
        get { return data; }
    }

    public void LoadData(string dataName)
    {
        data = JSON.Parse(Resources.Load<TextAsset>("Data/" + dataName).text)["data"];
    }
}
