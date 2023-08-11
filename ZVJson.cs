using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
public static class ZVJson
{
    public static T[] FromJson<T>(string json, bool useJsonFixer)
    {
        if (useJsonFixer) json = FixJson(json);
        Wrapper<T> wrapper = JsonUtility.FromJson<Wrapper<T>>(json);
        return wrapper.Items;
    }
    public static string FixJson(string value)
    {
        value = "{\"Items\":" + value + "}";
        return value;
    }
    public static string ToJson<T>(T[] array)
    {
        Wrapper<T> wrapper = new Wrapper<T>();
        wrapper.Items = array;
        return JsonUtility.ToJson(wrapper);
    }

    public static string ToJson<T>(T[] array, bool prettyPrint)
    {
        Wrapper<T> wrapper = new Wrapper<T>();
        wrapper.Items = array;
        return JsonUtility.ToJson(wrapper, prettyPrint);
    }

    [System.Serializable]
    private class Wrapper<T>
    {
        public T[] Items;
    }
    public static IEnumerator GetRequest(string url, System.Action<int, string> callback)
    {

        using (UnityWebRequest www = UnityWebRequest.Get(url))
        {
            yield return www.SendWebRequest();
            if (www.result == UnityWebRequest.Result.ConnectionError)
                callback(1, null);
            if (www.result == UnityWebRequest.Result.DataProcessingError)
                callback(2, null);
            if (www.result == UnityWebRequest.Result.ProtocolError)
                callback(3, null);
            else
            {
                callback(4, www.downloadHandler.text);
            }
        }
    }
    public static IEnumerator GetImageFromUrl(string url, System.Action<int, Sprite> callback)
    {
        UnityWebRequest request = UnityWebRequestTexture.GetTexture(url);
        yield return request.SendWebRequest();
        if (request.result == UnityWebRequest.Result.ConnectionError)
            callback(1, null);
        if (request.result == UnityWebRequest.Result.DataProcessingError)
            callback(2, null);
        if (request.result == UnityWebRequest.Result.ProtocolError)
            callback(3, null);
        else
            callback(4, SpriteFromTexture2D(((DownloadHandlerTexture)request.downloadHandler).texture));
    }

    public static Sprite SpriteFromTexture2D(Texture2D texture)
    {
        return Sprite.Create(texture, new Rect(0.0f, 0.0f, texture.width, texture.height), new Vector2(0.5f, 0.5f), 100.0f);
    }
}