using System.Collections.ObjectModel;
using JSGradesMini.Services;

namespace JSGradesMini;

public partial class QualDashboardPage : ContentPage
{
	private ObservableCollection<Qualification> _qualifications;
	public QualDashboardPage()
	{
		InitializeComponent();
		_qualifications = FileSystemService.LoadQualifications();
		qualCollectionView.ItemsSource = _qualifications;
	}

	private void OnQualificationSelected(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.FirstOrDefault() is Qualification selectedQualification)
        {
			qualCollectionView.SelectedItem = null;
            Navigation.PushAsync(new QualificationPage(selectedQualification, SaveQualifications));
        }
    }

	private void SaveQualifications()
	{
		FileSystemService.SaveQualifications(_qualifications);
	}

	private void OnAddQualificationClicked(object sender, EventArgs e)
	{
		var newQualification = new Qualification
		{
			QualificationType = QualificationType.BSc,
			Institution = "New University",
			CourseName = "New Qualification",
			OverallGrade = 0f,
			StartDate = DateTime.Now,
			EndDate = DateTime.Now.AddMonths(12),
			IsComplete = false,
			NumLevels = 0,
			CurrentLevel = 0
		};
		
		_qualifications.Add(newQualification);

		qualCollectionView.ItemsSource = null;
		qualCollectionView.ItemsSource = _qualifications;

		SaveQualifications();
	}

	/*
	public List<Qualification> GetQualifications()
	{
		return new List<Qualification>
		{
			new Qualification
			{
				QualificationType = QualificationType.MEng,
				Institution = "Durham University",
				CourseName = "Computer Science",
				OverallGrade = 71f,
				StartDate = new DateTime(2022, 10, 1),
				EndDate = new DateTime(2026, 7, 1),
				IsComplete = false,
				NumLevels = 4,
				CurrentLevel = 3,
				Levels = new ObservableCollection<Level>
				{
					new Level
					{
						LevelInt = 1,
						Weighting = 0f,
						Grade = 70f,
						StartDate = new DateTime(2022, 10, 1),
						EndDate = new DateTime(2023, 7, 1),
						IsComplete = true,
						Modules = new ObservableCollection<Modules>
						{
							new Modules
							{
								ModuleCode = "COMP1101",
								ModuleName = "Algorithms and Data Structures",
								ModuleGrade = 70f,
								IsComplete = true,
								Credits = 20,
								StartDate = new DateTime(2022, 10, 1),
								EndDate = new DateTime(2023, 7, 1),
								Assessments = new ObservableCollection<ModuleAssessment>
								{
									new ModuleAssessment
									{
										AssessmentType = AssessmentType.Coursework,
										AssessmentName = "ADS Coursework",
										Grade = 89f,
										Weighting = 34f,
										DueDate = new DateTime(2023, 1, 15),
										IsComplete = true
									}
								}
							}
						}
					}
				}
			}
		};
	}*/
}