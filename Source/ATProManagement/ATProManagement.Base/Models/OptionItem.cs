using System;
using System.Collections.Generic;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace ATPromanagement.Base;

public class OptionItem<T>
{
    public T Value { get; set; }

    public string Text { get; set; }

    public OptionItem(T value, string text)
    {
        Value = value;
        Text = text;
    }
}

