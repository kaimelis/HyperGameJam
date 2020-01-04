using UnityEngine;

[CreateAssetMenu(fileName = "InGameUI", menuName = "ScriptableObjects/InGameUI", order = 1)]
public class InGameUIScriptable : ScriptableObject
{
    public int highScore;
    public int finalScore;
}
