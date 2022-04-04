using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    private const int NumOfMusic = 3;
    
    [SerializeField]
    private AudioSource[] music;

    [SerializeField]
    private string[] rhythmFiles;

    private static string rhythmFile; 

    private float timeElapsed;
    private int index;

    // Start is called before the first frame update

    private void Awake()
    {
        index = Random.Range(0, NumOfMusic);
        rhythmFile = rhythmFiles[index];
        timeElapsed = 0f;
    }

    void Start()
    {
        music[index].Play();
    }

    void Update()
    {
        timeElapsed += Time.deltaTime * 1000;
    }

    public static List<int> GetRhythms()
    {
        List<int> rhythms = new List<int>();

        string text = System.IO.File.ReadAllText(rhythmFile);

        string[] times = text.Split(' '); 
        foreach(string time in times)
        {
            string[] items = time.Split('.');
            if(items.Length == 2)
            {
                rhythms.Add(1000 * int.Parse(items[0]) + 40 * int.Parse(items[1]));
            }

            else
            {
                rhythms.Add(60 * 1000 * int.Parse(items[0]) + 1000 * int.Parse(items[1]) + 40 * int.Parse(items[2]));
            }
        }

        return rhythms;
    }

}
