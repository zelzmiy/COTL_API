using HarmonyLib;
using System;

namespace COTL_API.Saves;

[HarmonyPatch]
internal static class APIDataManager
{
    internal static string DATA_PATH = "cotl_api_data.json";

    internal static COTLDataReadWriter<APIData> _dataReadWriter = new();

    internal static APIData apiData;

    static APIDataManager()
    {
        COTLDataReadWriter<APIData> dataFileReadWriter = _dataReadWriter;
        dataFileReadWriter.OnReadCompleted = (Action<APIData>)Delegate.Combine(dataFileReadWriter.OnReadCompleted, (Action<APIData>)delegate (APIData data)
        {
            apiData = data;
        });

        COTLDataReadWriter<APIData> dataFileReadWriter2 = _dataReadWriter;
        dataFileReadWriter2.OnCreateDefault = (Action)Delegate.Combine(dataFileReadWriter2.OnCreateDefault, (Action)delegate
        {
            apiData = new();
        });

        Load();
    }

    [HarmonyPatch(typeof(SaveAndLoad), "Save")]
    [HarmonyPostfix]
    internal static void Save()
    {
        _dataReadWriter.Write(apiData, DATA_PATH);
    }

    internal static void Load()
    {
        _dataReadWriter.Read(DATA_PATH);
    }

}