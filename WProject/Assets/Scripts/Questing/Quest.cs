using UnityEngine;

[System.Serializable]
public class Quest
{
    public bool isActive;

    public string title;
    public string description;
    public string itemName;

    public int goldReward;

    public Item itemReward;

    public Sprite imageItem;

    public QuestGoal goal;

    public void Complete()
    {
        isActive = false;
        Debug.Log(title + " was completed!");
    }
}
