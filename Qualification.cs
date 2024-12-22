using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace JSGradesMini;

// Currently targeting degrees similar to mine

// Overall Qualification
public class Qualification : INotifyPropertyChanged
{
    private QualificationType _qualificationType;
    private string _institution;
    private string _courseName;
    private DateTime _startDate;
    private DateTime _endDate;
    private bool _isComplete;
    private float _numLevels;
    private float _currentLevel;
    private float _overallGrade;
    private string _classification;
    
    public QualificationType QualificationType { get => _qualificationType; set => SetProperty(ref _qualificationType, value);}
    public string Institution { get => _institution; set => SetProperty(ref _institution, value);}
    public string CourseName { get => _courseName; set => SetProperty(ref _courseName, value);}
    public DateTime StartDate {get => _startDate; set => SetProperty(ref _startDate, value);}
    public DateTime EndDate {get => _endDate; set => SetProperty(ref _endDate, value);}
    public bool IsComplete {get => _isComplete; set => SetProperty(ref _isComplete, value);}
    public float NumLevels {get => _numLevels; set => SetProperty(ref _numLevels, value);}
    public float CurrentLevel {get => _currentLevel; set => SetProperty(ref _currentLevel, value);}
    public float OverallGrade {get => _overallGrade; set => SetProperty(ref _overallGrade, value);}
    public string Classification
    {
        get
        {
            if (OverallGrade >= 70.0f)
            {
                return "First Class Honours";
            }
            else if (OverallGrade >= 60.0f)
            {
                return "Upper Second Class Honours";
            }
            else if (OverallGrade >= 50.0f)
            {
                return "Lower Second Class Honours";
            }
            else if (OverallGrade >= 40.0f)
            {
                return "Third Class Honours";
            }
            else
            {
                return "Fail";
            }
        }
    }

    public ObservableCollection<Level> Levels {get; set;} = new ObservableCollection<Level>();

    public event PropertyChangedEventHandler PropertyChanged;

    protected bool SetProperty<T>(ref T backingStore, T value, [CallerMemberName] string propertyName = "")
    {
        if (EqualityComparer<T>.Default.Equals(backingStore, value))
            return false;
        
        backingStore = value;
        OnPropertyChanged(propertyName);
        return true;
    }

    protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void CalculateOverallGrade()
    {
        OverallGrade = 0.0f;
        foreach (Level level in Levels)
        {
            OverallGrade += level.Grade * level.Weighting;
        }
    }
}

// Each academic year of degree
public class Level : INotifyPropertyChanged
{
    public int LevelInt {get; set;} = 0;
    public float Weighting {get; set;} = 0.0f;
    public DateTime StartDate {get; set;} = DateTime.Now;
    public DateTime EndDate {get; set;} = DateTime.Now;
    public bool IsComplete {get; set;} = false;
    public float Grade {get; set;} = 0.0f;
    public ObservableCollection<Modules> Modules {get; set;} = new ObservableCollection<Modules>();

    public event PropertyChangedEventHandler PropertyChanged;

    protected bool SetProperty<T>(ref T backingStore, T value, [CallerMemberName] string propertyName = "")
    {
        if (EqualityComparer<T>.Default.Equals(backingStore, value))
            return false;
        
        backingStore = value;
        OnPropertyChanged(propertyName);
        return true;
    }

    protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void CalculateLevelGrade()
    {
        Grade = 0.0f;
        float totalCredits = 0.0f;
        foreach (Modules module in Modules)
        {
            Grade += module.ModuleGrade * module.Credits;
            totalCredits += module.Credits;
        }

        Grade = Grade / totalCredits;
    }
}

// Modules for each assessment year
public class Modules
{
    public string ModuleCode { get; set; } = string.Empty;
    public string ModuleName { get; set; } = string.Empty;
    public float Credits {get; set;} = 0.0f;
    public DateTime StartDate {get; set;} = DateTime.Now;
    public DateTime EndDate {get; set;} = DateTime.Now;
    public bool IsComplete {get; set;} = false;
    public float ModuleGrade {get; set;} = 0.0f;
    public ObservableCollection<ModuleAssessment> Assessments {get; set;} = new ObservableCollection<ModuleAssessment>();

    public void CalculateModuleGrade()
    {
        ModuleGrade = 0.0f;
        foreach (ModuleAssessment assessment in Assessments)
        {
            ModuleGrade += assessment.Grade * assessment.Weighting;
        }
    }
}

// Individal Assessments per module
public class ModuleAssessment
{
    public AssessmentType AssessmentType {get; set;} = AssessmentType.Coursework;
    public string AssessmentName {get; set;} = string.Empty;
    public DateTime DueDate {get; set;} = DateTime.Now;
    public float Weighting {get; set;} = 0.0f;
    public float Grade {get; set;} = 0.0f;
    public bool IsComplete {get; set;} = false;
}

public enum AssessmentType
{
    Examination,
    Coursework,
    BenchTest
}

public enum QualificationType
{
    MEng,
    MSc,
    MA,
    BSc,
    BA,
    LLB
}