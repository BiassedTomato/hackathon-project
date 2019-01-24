using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class ShopHandler : MonoBehaviour
{
    public List<string> TipsList;
    public GameObject GameField;
    public GameObject Shop;
    public Text Tips;

    private void Awake()
    {
        TipsList = new List<string>();

        TipsList.Add("Если чистить зубы два раза в день, то изо рта всегда будет пахнуть приятно, а также никогда не будут болеть зубы.");
        TipsList.Add("За день на коже накапливается большое количество бактерий. Чтобы от них избавиться, необходимо ежедневно мыться с мылом, и тогда никакие заболевания кожи не страшны.");
        TipsList.Add("Как говорил Мойдодыр, <<Надо, надо умываться по утрам и вечерам, а  нечистым трубочистам - Стыд и срам! Стыд и срам!>>");
        TipsList.Add("После туалета, а также до и после приема пищи необходимо мыть руки, и тогда никакая грязь и зараза не попадет в организм!");
        TipsList.Add("Стоит менять постельное белье каждую неделю, чтобы не позволить появиться пылевым клещам и клопам.");
        TipsList.Add("Кариес может развиться, если есть много сладкого и не чистить зубы. От кариеса очень болят зубы и плохой запах изо рта.");
    }

    void SetTip()
    {
        Tips.text = TipsList[Random.Range(0, 6)];
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameField.activeSelf)
            {
                GameField.SetActive(false);
                Shop.SetActive(true);
                SetTip();
            }
            else
            {
                GameField.SetActive(true);
                Shop.SetActive(false);
            }
        }
    }
}
