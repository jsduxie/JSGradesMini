namespace JSGradesMini;

public partial class QualificationPage : ContentPage
{
	private Qualification _qualification;
	private Action _saveQualifications;
	public QualificationPage(Qualification qualification, Action saveQualifications)
	{
		InitializeComponent();
		_qualification = qualification;
		_saveQualifications = saveQualifications;
		BindingContext = _qualification;
		levelCollectionView.ItemsSource = _qualification.Levels;
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();

		levelCollectionView.ItemsSource = null;
		levelCollectionView.ItemsSource = _qualification.Levels;
    }

	protected override void OnDisappearing()
    {
        base.OnDisappearing();
		_saveQualifications();
    }

    private void OnLevelSelected(object sender, SelectionChangedEventArgs e)
	{
		if (e.CurrentSelection.FirstOrDefault() is Level selectedLevel)
        {
			levelCollectionView.SelectedItem = null;
            Navigation.PushAsync(new LevelPage(selectedLevel, _saveQualifications));
        }
	}

	private void OnAddLevelClicked(object sender, EventArgs e)
	{
		var newLevel = new Level
		{
			LevelInt = _qualification.Levels.Count + 1,
			StartDate = DateTime.Now,
			EndDate = DateTime.Now.AddMonths(12),
			Weighting = 0.0f
		};

		_qualification.Levels.Add(newLevel);

		levelCollectionView.ItemsSource = null;
		levelCollectionView.ItemsSource = _qualification.Levels;

		_saveQualifications();
	}

}