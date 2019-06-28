using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class results_manager : MonoBehaviour
{
    [SerializeField] dataStorage data;
    [SerializeField] GameObject time;
    [SerializeField] GameObject rounds;
    [SerializeField] GameObject zombiesKilled;
    [SerializeField] GameObject score;
    [SerializeField] GameObject backButton;

    void Start()
    {
        Cursor.visible = true;
        time.GetComponent<Text>().text = "TIME: " + data.time;
        rounds.GetComponent<Text>().text = "ROUNDS SURVIVED: " + data.rounds;
        zombiesKilled.GetComponent<Text>().text = "ZOMBIES KILLED: " + data.zombiesKilled;
        backButton.GetComponent<Button>().onClick.AddListener(TaskOnClick);
    }
    void TaskOnClick()
    {
        SceneManager.LoadScene("mainMenu");
    }

}
