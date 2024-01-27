using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    public GameObject player, fish/*, shrimp, avocado*/;
    private int fishCount = 0, shrimpCount = 0, avocadoCount = 0;
    private float finalScore;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CountChild();
        ScoreCalculation();
    }

    //private void CountChild()
    //{
    //    Transform fishChild = player.transform.Find("Fish");
    //    if (fishChild != null)
    //    {
    //        fishCount++;
    //    }

    //    Transform shrimpChild = player.transform.Find("Shrimp");
    //    if (shrimpChild != null)
    //    {
    //        shrimpCount++;
    //    }

    //    Transform avocadoChild = player.transform.Find("Avocado");
    //    if (avocadoChild != null)
    //    {
    //        avocadoCount++;
    //    }
    //}

    private void CountChild()
    {
        fishCount = CountChildrenByName(player, "Fish");
        //shrimpCount = CountChildrenByName(player, "Shrimp");
        //avocadoCount = CountChildrenByName(player, "Avocado");

        Debug.Log("Fish count: " + fishCount);
        //Debug.Log("Shrimp count: " + shrimpCount);
        //Debug.Log("Avocado count: " + avocadoCount);
    }

    private int CountChildrenByName(GameObject player, string childName)
    {
        int count = 0;

        foreach (Transform child in player.transform)
        {
            if (child.name == childName)
            {
                count++;
            }
        }
        return count;
    }

    float GetIngredientScore(GameObject ingredient)
    {
        Ingredient score = ingredient.GetComponent<Ingredient>();

        if (score != null)
        {
            return score.score;
        }
        else
        {
            return 0f;
        }
    }

    private void ScoreCalculation()
    {
        finalScore = GetIngredientScore(fish) * fishCount /*+ GetIngredientScore(shrimp) * shrimpCount + GetIngredientScore(avocado) * avocadoCount*/;
        Debug.Log("Final score is now " + finalScore);
    }
}
