namespace JSGradesMini;

public partial class QualificationPage : ContentPage
{
	public QualificationPage(Qualification qualification)
	{
		InitializeComponent();
		BindingContext = qualification;
		levelCollectionView.ItemsSource = qualification.Levels;
	}

}