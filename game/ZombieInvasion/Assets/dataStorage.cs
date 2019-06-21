using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "My Assets/dataStorage")]

public class dataStorage : ScriptableObject
{
    public string time { get; set; }
    public int rounds { get; set; }
    public int zombiesKilled { get; set; }
    public int score { get; set; }
}
