namespace JSGradesMini;

public partial class ModulePage : ContentPage
{
	private Modules _module;
	public ModulePage(Modules module)
	{
		InitializeComponent();
		_module = module;
		BindingContext = _module;
		assessmentCollectionView.ItemsSource = _module.Assessments;
	}

	protected override void OnAppearing()
    {
        base.OnAppearing();

		assessmentCollectionView.ItemsSource = null;
		assessmentCollectionView.ItemsSource = _module.Assessments;
    }

    private void OnAssessmentSelected(object sender, SelectionChangedEventArgs e)
	{
		if (e.CurrentSelection.FirstOrDefault() is ModuleAssessment selectedAssessment)
        {
			assessmentCollectionView.SelectedItem = null;
            Navigation.PushAsync(new AssessmentPage(selectedAssessment));
        }
	}

	private void OnAddAssessmentClicked(object sender, EventArgs e)
	{
		var newAssessment = new ModuleAssessment
		{
			AssessmentType = AssessmentType.Coursework,
			AssessmentName = "New Assessment",
			DueDate = DateTime.Now,
			Weighting = 0.0f,
			Grade = 0.0f,
			IsComplete = false

		};
		_module.Assessments.Add(newAssessment);

		assessmentCollectionView.ItemsSource = null;
		assessmentCollectionView.ItemsSource = _module.Assessments;
	}
}