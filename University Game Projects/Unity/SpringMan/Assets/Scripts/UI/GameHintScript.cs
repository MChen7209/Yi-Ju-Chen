using UnityEngine;
using System.Collections.Generic;

public class GameHintScript : MonoBehaviour
{
    public List<Color> primaryColors;
    public List<Color> secondaryColors;
    public List<Texture2D> skillsTextures;
    public static List<Hint> hints = new List<Hint>(){  new Hint("Get to the bottom of the level as quickly as possible.\n\nMETEOR!"), 
        new Hint("Stomping on enemies will increase your score and give you widgets, which you can use to upgrade Springman. \n\n" +
            "Killing enemies will also release energy, charging Springman and slowing the meteor's descent temporarily."),
        new Hint("The meteor kills you."),
        new Hint("Stepping on spikes will cause damage."),
        new Hint("This is a checkpoint. \n\nDying will return you here instead of to the beginning of the level.")};

    private bool hasUpdatedGui = false;

    private string HintText = "This is a game hint. These will appear every time there is something new to learn.";
    private bool IsOpen = false;
    private int height = 200;

    void Start()
    {

    }

    void OnGUI()
    {
        if (!hasUpdatedGui)
        {
            ColoredGUISkin.Instance.UpdateGuiColors(primaryColors[0], secondaryColors[0]);
            hasUpdatedGui = true;
        }
        GUI.skin = ColoredGUISkin.Skin;

        if (IsOpen)
        {
            Time.timeScale = 0;
            int boxHeight = height;
            int boxWidth = 400;
            GUI.BeginGroup(new Rect(Screen.width / 2 - 200, Screen.height / 2 - 100, boxWidth, boxHeight));
            GUI.Box(new Rect(0, 0, boxWidth, boxHeight), "");
            GUI.skin.label.fontSize = 16;
            GUI.Label(new Rect(35, 35, boxWidth - 70, boxHeight / 2), HintText);
            if (GUI.Button(new Rect(boxWidth - 120, boxHeight - 65, 100, 60), "OKAY"))
            {
                Close();
            }
            GUI.EndGroup();
        }
        else
        {
        }
    }

    public void SetText(string text)
    {
        HintText = text;
    }

    public void Open()
    {
        return;
        if (MenuScript.Hints && !HeroController.GameOver)
            IsOpen = true;
    }

    public void Close()
    {
        IsOpen = false;
        Time.timeScale = MenuScript.gameSpeed;
    }

    public void DisplayHint(int hintNum)
    {
        var hint = hints[hintNum];
        if (!hint.Activated)
        {
            SetText(hint.Text);
            height = hint.Height;
            Open();
            hint.Activated = true;
        }
    }
}

public class Hint
{
    public string  Text        { get; set; }
    public bool    Activated   { get; set; }
    public int     Height      { get; set; }
   
    public Hint(string str)
    {
        Text = str;
        if (str.Length > 100)
            Height = 275;
        else
            Height = 200;
    }
}