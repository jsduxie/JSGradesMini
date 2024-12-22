namespace JSGradesMini;

public partial class AssessmentPage : ContentPage
{
	public AssessmentPage(ModuleAssessment assessment)
	{
		InitializeComponent();
		BindingContext = assessment;
	}

}