using UnityEngine;


public static class DataExtensions
{
    public static string ToJson(this object obj)
    {
        return JsonUtility.ToJson(obj);
    }
    
    
    public static T ToDeserialize<T>(this string jsonProgress)
    {
        return JsonUtility.FromJson<T>(jsonProgress);
    }
}
