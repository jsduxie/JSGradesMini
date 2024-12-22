namespace JSGradesMini;

public partial class QualificationPage : ContentPage
{
	private Qualification _qualification;
	public QualificationPage(Qualification qualification)
	{
		InitializeComponent();
		_qualification = qualification;
		BindingContext = _qualification;
		levelCollectionView.ItemsSource = _qualification.Levels;
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();

		levelCollectionView.ItemsSource = null;
		levelCollectionView.ItemsSource = _qualification.Levels;
    }

    private void OnLevelSelected(object sender, SelectionChangedEventArgs e)
	{
		if (e.CurrentSelection.FirstOrDefault() is Level selectedLevel)
        {
			levelCollectionView.SelectedItem = null;
            Navigation.PushAsync(new LevelPage(selectedLevel));
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
	}

}