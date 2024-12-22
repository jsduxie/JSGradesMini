using System;
using Microsoft.Maui.Controls;

namespace JSGradesMini.Behaviors;

public class NumericEntryBehaviour : Behavior<Entry>
{
    protected override void OnAttachedTo(Entry bindable)
    {
        base.OnAttachedTo(bindable);
        bindable.TextChanged += OnEntryTextChanged;
    }

    protected override void OnDetachingFrom(Entry bindable)
    {
        base.OnDetachingFrom(bindable);
        bindable.TextChanged -= OnEntryTextChanged;
    }

    private void OnEntryTextChanged(object sender, TextChangedEventArgs e)
    {
        if (sender is Entry entry)
        {
            if (!string.IsNullOrEmpty(e.NewTextValue))
            {
                bool isValid = e.NewTextValue.ToCharArray().All(char.IsDigit);
                if (!isValid)
                {
                    entry.Text = e.OldTextValue;
                }
            }
        }
    }
}

