using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using System.Runtime.CompilerServices;
using System.Globalization;
using Microsoft.Maui.Controls;

namespace JSGradesMini;

public class MainViewModel : INotifyPropertyChanged
{
    public ObservableCollection<Subject> Subjects { get; set; }

    public MainViewModel()
    {
        Subjects = new ObservableCollection<Subject>
        {
            new Subject
            {
                Name = "Human-AI Interaction Design",
                Percentage = 74,
                Assessments = new ObservableCollection<Assessment>
                {
                    new Assessment { Title = "Essay", DueDate = "2024-01-15", Weight = 40 },
                    new Assessment { Title = "Project", DueDate = "2024-03-10", Weight = 60 }
                }
            },
            new Subject
            {
                Name = "Algorithmic Game Theory",
                Percentage = 24,
                Assessments = new ObservableCollection<Assessment>
                {
                    new Assessment { Title = "Report", DueDate = "2024-02-20", Weight = 50 },
                    new Assessment { Title = "Exam", DueDate = "2024-04-25", Weight = 50 }
                }
            }
        };
    }

    public event PropertyChangedEventHandler PropertyChanged;
    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}

public class Subject
{
    public string Name { get; set; } = string.Empty;
    public int Percentage { get; set; }
    public ObservableCollection<Assessment>? Assessments { get; set; }

    private bool _isExpanded;
    public bool IsExpanded
    {
        get => _isExpanded;
        set
        {
            _isExpanded = value;
            OnPropertyChanged(nameof(IsExpanded));
        }
    }

    public ICommand ToggleExpandCommand { get; }

    public Subject()
    {
        ToggleExpandCommand = new Command(() =>
        {
            // Trigger the expand/collapse action
            IsExpanded = !IsExpanded;
            
            // Show a modal alert to confirm the command is firing
            Application.Current.MainPage.DisplayAlert("Expanded", IsExpanded ? "Expanded" : "Collapsed", "OK");
        });
    }

    public event PropertyChangedEventHandler PropertyChanged;
    protected void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}

public class Assessment
{
    public string Title { get; set; } = string.Empty;
    public string DueDate { get; set; } = string.Empty;
    public double Weight { get; set; } = 0.0;
}
