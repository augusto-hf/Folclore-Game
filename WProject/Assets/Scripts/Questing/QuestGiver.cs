using UnityEngine;
using UnityEngine.UI;

public class QuestGiver : PauseMenu
{
    public Quest quest;

    public Player player;

    public GameObject questWindow;

    public Text titleText;
    public Text descriptionText;
    public Text goldText;
    public Text itemText;

    public void OpenQuestWindow()
    {
        GameIsPaused = true;
        Time.timeScale = 0f;
        questWindow.SetActive(true);
        titleText.text = quest.title;
        descriptionText.text = quest.description;
        goldText.text = quest.goldReward.ToString();
        itemText.text = quest.itemName;
    }

    public void AcceptQuest()
    {
        questWindow.SetActive(false);
        quest.isActive = true;
        player.quest = quest;
        GameIsPaused = false;
        Time.timeScale = 1f;
    }

    public void DeclineQuest()
    {
        questWindow.SetActive(false);
        quest.isActive = false;
        GameIsPaused = false;
        Time.timeScale = 1f;
    }
}
