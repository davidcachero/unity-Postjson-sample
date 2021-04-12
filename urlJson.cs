using System.Collections;
using System.IO;
using System.Net;
using UnityEngine;
using UnityEngine.UI;

public class urlJson : MonoBehaviour
{
    public GameObject button;
    private string meAPI = "c8986d01d046f289b7280a5efbf50b60";

    void Start()
    {
        Button btn = button.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    [System.Obsolete]
    void TaskOnClick()
    {
        doGet();
    }

    [System.Obsolete]
    void doGet()
    {
        string sURL;
        sURL = "https://api.openweathermap.org/data/2.5/weather?q=Madrid&lang=es&units=metric&appid=" + meAPI;

        WebRequest wrGETURL;
        wrGETURL = WebRequest.Create(sURL);

        WebProxy myProxy = new WebProxy("myproxy", 80);
        myProxy.BypassProxyOnLocal = true;

        wrGETURL.Proxy = WebProxy.GetDefaultProxy();

        Stream objStream;
        objStream = wrGETURL.GetResponse().GetResponseStream();

        StreamReader objReader = new StreamReader(objStream);

        StartCoroutine(LogConsole(objReader));
    }

    IEnumerator LogConsole(StreamReader objReader)
    {
        string sLine = "";
        while (sLine != null)
        {
            sLine = objReader.ReadLine();
            if (sLine != null)
                Debug.Log(sLine);
        }
        yield return null;
    }

}