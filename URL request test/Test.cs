using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
public class Test : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(GetRequest());
    }

    IEnumerator GetRequest()
    {
        string url = "https://catfact.ninja/fact";

        UnityWebRequest webRequest = UnityWebRequest.Get(url);
        
        yield return webRequest.SendWebRequest();

        string resultado = webRequest.downloadHandler.text;

        Debug.Log(resultado);

        CatFact catFact = JsonUtility.FromJson<CatFact>(resultado);

        Debug.Log(catFact.fact);
    }
}

class CatFact
{
    public string fact;
    public int length;
}