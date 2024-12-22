namespace JSGradesMini;

public partial class AssessmentPage : ContentPage
{
	private Action _saveQualifications;
	public AssessmentPage(ModuleAssessment assessment, Action saveQualifications)
	{
		InitializeComponent();
		BindingContext = assessment;
		_saveQualifications = saveQualifications;
	}

	protected override void OnDisappearing()
    {
        base.OnDisappearing();
		_saveQualifications();
    }

}