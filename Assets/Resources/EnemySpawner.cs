using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour
{
    public GameObject Field;
    public Transform Enemy;

    private void Awake()
    {
        Tempo = 4;
    }

    float tempo;
    public float Tempo
    {
        get
        {
            return tempo;
        }

        set
        {
            tempo = value;
        }
    }

    // Use this for initialization
    void OnEnable()
    {
        Debug.Log(Tempo);
        StartCoroutine("Spawn");
    }

    IEnumerator Spawn()
    {
        for(; ; )
        {
            Instantiate(Enemy,transform.position,Quaternion.identity, Field.transform);
            yield return new WaitForSeconds(Tempo);
        }

    }

}
