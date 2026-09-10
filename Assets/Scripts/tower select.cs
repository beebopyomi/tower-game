using UnityEngine;

public class towerselect : MonoBehaviour
{
    public static GameObject selectedTowerprefanb;
    public void selectTower(GameObject towerPrefab)
    {
        if (towerPrefab == selectedTowerprefanb)
        {
            selectedTowerprefanb = null;
            return;
        }
        selectedTowerprefanb = towerPrefab;
    }
}
