using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerStatUpgradeDisplay : MonoBehaviour
{
    public TMP_Text levelText;

    public GameObject upgradeButton;

    public void UpdateDisplay(float oldLevel, float newLevel)
    {
        levelText.text = "Level " + oldLevel + "->" + newLevel;
    }

    public void sortButtons()
    {
        RectTransform rectTransform1 = UIController.instance.attackPowerUpgradeDisplay.GetComponent<RectTransform>();
        RectTransform rectTransform2 = UIController.instance.attackSpeedUpgradeDisplay.GetComponent<RectTransform>();
        RectTransform rectTransform3 = UIController.instance.moveSpeedUpgradeDisplay.GetComponent<RectTransform>();
        RectTransform rectTransform4 = UIController.instance.healthUpgradeDisplay.GetComponent<RectTransform>();

        int attackPowerLevelInstance = PlayerStatController.instance.attackPowerLevel;
        int attackSpeedLevelInstance = PlayerStatController.instance.attackSpeedLevel;
        int moveSpeedLevelInstance = PlayerStatController.instance.moveSpeedLevel;
        int healthLevelInstance = PlayerStatController.instance.healthLevel;

        var tuple1 = (rectTransform1, attackPowerLevelInstance);
        var tuple2 = (rectTransform2, attackSpeedLevelInstance);
        var tuple3 = (rectTransform3, moveSpeedLevelInstance);
        var tuple4 = (rectTransform4, healthLevelInstance);

        // Put the tuples in a list
        var unsortedTuples = new System.Collections.Generic.List<(UnityEngine.RectTransform, int)>()
        {
            tuple1,
            tuple2,
            tuple3,
            tuple4
        };

        // Call the MergeSort function from the other script
        var sortedTuples = MergeSortScript.MergeSort(unsortedTuples);

        RectTransform sortedRectTransform1 = sortedTuples[0].Item1;
        sortedRectTransform1.anchoredPosition = new Vector2(-566, 202);
        RectTransform sortedRectTransform2 = sortedTuples[1].Item1;
        sortedRectTransform2.anchoredPosition = new Vector2(-187, 202);
        RectTransform sortedRectTransform3 = sortedTuples[2].Item1;
        sortedRectTransform3.anchoredPosition = new Vector2(196, 202);
        RectTransform sortedRectTransform4 = sortedTuples[3].Item1;
        sortedRectTransform4.anchoredPosition = new Vector2(574, 202);    
    }

    public void ShowMaxLevel(){
        levelText.text = "Max Level";
        upgradeButton.SetActive(false);
    }
}
