using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Sample01.ViewModels;

/// <summary>
/// MVVMパターンにおけるViewModelに相当する。
/// INotifyPropertyChangedを実装して、プロパティの変更をViewに伝える役割を持つ
/// </summary>
public class SimpleViewModel : INotifyPropertyChanged
{
	public event PropertyChangedEventHandler? PropertyChanged;

	protected void RaisePropertyChanged([CallerMemberName] string? propertyName = null)
	{
		PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}

	private string? _name;

	public string? Name
	{
		get { return _name; }
		set
		{
			if (_name != value)
			{
				// UIに変更を通知するためにRaisePropertyChangedを呼ぶ
				// その後、Greetingプロパティの変更も通知する
				// MEMO: これ、原始的なReactivePropertyじゃね？R3導入したら、一発で解決しそう
				_name = value;
				RaisePropertyChanged();
				RaisePropertyChanged(nameof(Greeting));
			}
		}
	}
	public string Greeting
	{
		get
		{
			if (string.IsNullOrEmpty(Name))
			{
				// If no Name is provided, use a default Greeting
				return "Hello World from Avalonia.Samples";
			}
			else
			{
				// else greet the User.
				return $"Hello {Name}";
			}
		}
	}

}