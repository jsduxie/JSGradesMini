namespace JSGradesMini;

public partial class QualDashboardPage : ContentPage
{
	public QualDashboardPage()
	{
		InitializeComponent();
		qualCollectionView.ItemsSource = GetQualifications();
	}

	public List<Qualification> GetQualifications()
	{
		return new List<Qualification>
		{
			new Qualification { QualCode = "COMPxxxx", QualName = "Computer Science", QualGrade = 72.4f},
			new Qualification { QualCode = "COMPyyyy", QualName = "Computer Science 2", QualGrade = 12.4f}
		};
	}
}