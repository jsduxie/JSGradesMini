using System;
using System.Collections.ObjectModel;

namespace JSGradesMini;

// Currently targeting degrees similar to mine

// Overall Qualification
public class Qualification
{
    public QualificationType QualificationType { get; set; } = QualificationType.BachelorsDegree;
    public string Institution { get; set; } = string.Empty;
    public DateTime StartDate {get; set;} = DateTime.Now;
    public DateTime EndDate {get; set;} = DateTime.Now;
    public bool IsComplete {get; set;} = false;
    public float NumLevels {get; set;} = 0;
    public float CurrentLevel {get; set;} = 0;
    public float OverallGrade {get; set;} = 0.0f;
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
public class Level
{
    public int LevelInt {get; set;} = 0;
    public float Weighting {get; set;} = 0.0f;
    public DateTime StartDate {get; set;} = DateTime.Now;
    public DateTime EndDate {get; set;} = DateTime.Now;
    public bool IsComplete {get; set;} = false;
    public float Grade {get; set;} = 0.0f;
    public ObservableCollection<Modules> Modules {get; set;} = new ObservableCollection<Modules>();

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
    MastersDegree,
    BachelorsDegree
}