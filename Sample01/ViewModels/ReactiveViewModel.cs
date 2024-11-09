using System;
using ReactiveUI;

namespace Sample01.ViewModels;

/// <summary>
/// ReactiveUI.ReactiveObjectを継承して、ViewModelを楽に実装する
/// </summary>
public class ReactiveViewModel : ReactiveObject
{
	public ReactiveViewModel()
	{
		// Nameプロパティの変更を監視して、Greetingプロパティの変更を通知する
		this.WhenAnyValue(x => x.Name)
			.Subscribe(_ => this.RaisePropertyChanged(nameof(Greeting)));
	}
	
	private string? name;
	public string? Name
	{
		get => name;
		set => this.RaiseAndSetIfChanged(ref name, value);
	}

	public string Greeting
	{
		get
		{
			return string.IsNullOrWhiteSpace(Name) ? "Hello from Avalonia.Samples" : $"Hello, {Name}!";
		}
	}
}