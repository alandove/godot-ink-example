using Godot;
using System;

public class WithLoop : Control
{
    private InkStory story;
    private StoryContainer container;

    private Timer timer;

    public override void _Ready()
    {
        // Retrieve or create some Nodes we know we'll need quite often
        story = GetNode<InkStory>("Story");
        container = GetNode<StoryContainer>("Container");

        timer = new Timer();
        timer.Autostart = false;
        timer.WaitTime = 0.3f;
        timer.OneShot = true;
        AddChild(timer);
    }

    public override void _Process(float delta)
    {
        // If the time is running, we want to wait
        if (timer.TimeLeft > 0) return;

        // Check if we have anything to consume
        if (story.CanContinue)
        {
            string text = story.Continue().Trim();
            if (text.Length > 0)
                container.Add(container.CreateText(text));

            // Maybe we have choices now that we moved on?
            if (story.HasChoices)
            {
                container.Add(container.CreateSeparation(), 0.2f);
                // Add a button for each choice
                for (int i = 0; i < story.CurrentChoices.Length; ++i)
                    container.Add(container.CreateChoice(story.CurrentChoices[i], i), 0.4f);
            }
            timer.Start();
        }
        else if (!story.HasChoices)
        {
            container.Add(container.CreateSeparation(), 0.4f);
            container.Add(container.CreateSeparation(), 0.5f);
            container.Add(container.CreateSeparation(), 0.6f);
        }
    }

    protected void OnChoiceClick(int choiceIndex)
    {
        container.CleanChoices();
        // Choose the clicked choice
        story.ChooseChoiceIndex(choiceIndex);
    }
}
