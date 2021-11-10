namespace DiagnosticSamples;

using System;
using System.Collections.Generic;
using System.Diagnostics;

public class DiagnosticObserver : IObserver<DiagnosticListener>, IObserver<KeyValuePair<string, object>>
{
    private readonly List<IDisposable> _subscriptions = new List<IDisposable>();

    public void OnCompleted()
    {
    }

    public void OnError(Exception error)
    {
    }

    public void OnNext(DiagnosticListener value)
    {
        Console.WriteLine($"Listener: {value.Name}");

        _subscriptions.Add(value.Subscribe(this));
    }

    public void OnNext(KeyValuePair<string, object> value)
    {
        Console.WriteLine($"{value.Key}: {value.Value}");
    }
}