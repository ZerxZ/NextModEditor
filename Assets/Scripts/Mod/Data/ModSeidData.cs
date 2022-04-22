﻿using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;

public class ModSeidData : IModData
{
    public int ID { get; set; }
    public Dictionary<string, ModSeidToken> DataList { get; set; } = new Dictionary<string, ModSeidToken>();

    public static ModSeidData LoadSeidData(ModSeidMeta meta, JObject jObject)
    {
        var data = new ModSeidData();
        data.ID = jObject["id"]!.ToObject<int>();
        foreach (var seidProperty in meta.Properties)
        {
            JToken token = null;
            switch (seidProperty.Type)
            {
                case ModSeidPropertyType.Int:
                    var sInt = new ModSInt();
                    if (jObject.TryGetValue(seidProperty.ID, out token))
                        sInt.Value = token.ToObject<int>();
                    data.DataList.Add(seidProperty.ID,sInt);
                    break;
                case ModSeidPropertyType.IntArray:
                    var sIntArray = new ModSIntArray();
                    if (jObject.TryGetValue(seidProperty.ID, out token) && token is JArray jArray)
                    {
                        foreach (var item in jArray)
                        {
                            sIntArray.Value.Add(item.ToObject<int>());
                        }
                    }
                    data.DataList.Add(seidProperty.ID,sIntArray);
                    break;
                case ModSeidPropertyType.Float:
                    var sFloat = new ModSFloat();
                    if (jObject.TryGetValue(seidProperty.ID, out token))
                        sFloat.Value = token.ToObject<float>();
                    data.DataList.Add(seidProperty.ID,sFloat);
                    break;
                case ModSeidPropertyType.String:
                    var sString = new ModSString();
                    if (jObject.TryGetValue(seidProperty.ID, out token))
                        sString.Value = token.ToObject<string>();
                    data.DataList.Add(seidProperty.ID,sString);
                    break;
            }
        }

        return data;
    }

    public T GetToken<T>(string dataId) where T : ModSeidToken
    {
        return DataList[dataId] as T;
    }

    public static ModSeidData CreateSeidData(int ID,ModSeidMeta meta)
    {
        var data = new ModSeidData();
        data.ID = ID;
        foreach (var seidProperty in meta.Properties)
        {
            switch (seidProperty.Type)
            {
                case ModSeidPropertyType.Int:
                    var sInt = new ModSInt();
                    data.DataList.Add(seidProperty.ID,sInt);
                    break;
                case ModSeidPropertyType.IntArray:
                    var sIntArray = new ModSIntArray();
                    data.DataList.Add(seidProperty.ID,sIntArray);
                    break;
                case ModSeidPropertyType.Float:
                    var sFloat = new ModSFloat();
                    data.DataList.Add(seidProperty.ID,sFloat);
                    break;
                case ModSeidPropertyType.String:
                    var sString = new ModSString();
                    data.DataList.Add(seidProperty.ID,sString);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
        return data;
    }

    public static JObject SaveSeidData(ModSeidMeta meta, ModSeidData seidData)
    {
        var data = new JObject();
        data.Add(meta.IDName,seidData.ID);
        foreach (var seidProperty in meta.Properties)
        {
            switch (seidProperty.Type)
            {
                case ModSeidPropertyType.Int:
                    data.Add(seidProperty.ID, seidData.GetToken<ModSInt>(seidProperty.ID).Value);
                    break;
                case ModSeidPropertyType.IntArray:
                    var jArray = JArray.FromObject(seidData.GetToken<ModSIntArray>(seidProperty.ID).Value);
                    data.Add(seidProperty.ID, jArray);
                    break;
            }
        }

        return data;
    }
}