using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class ButtonTempo : MonoBehaviour
{
    public GameObject[] Spawners = new GameObject[4];
    public GameObject Player;

    public void TempPlus()
    {
        if (Player.GetComponent<Player>().Score >= 60)
        {
            Player.GetComponent<Player>().Score -= 60;
            Player.GetComponent<Player>().Tempo *= 0.8f;
        }
    }

    public void SpawnPlus()
    {
        Debug.Log("aaa");

        if (Player.GetComponent<Player>().Score >= 30)
        {
             Player.GetComponent<Player>().Score -= 30;

            foreach (GameObject spawner in Spawners)
            {
                spawner.GetComponent<EnemySpawner>().Tempo *= 0.8f;
                Debug.Log(spawner.GetComponent<EnemySpawner>().Tempo);
            }
        }

    }

    public void StartGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void ToMenu()
    {
        SceneManager.LoadScene("Menu");
    }


}
