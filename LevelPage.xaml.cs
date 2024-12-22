namespace JSGradesMini;

public partial class LevelPage : ContentPage
{
	private Level _level;
	private Action _saveQualifications;
	public LevelPage(Level level, Action saveQualifications)
	{
		InitializeComponent();
		_level = level;
		_saveQualifications = saveQualifications;
		_level.CalculateLevelGrade();
		BindingContext = _level;
		moduleCollectionView.ItemsSource = _level.Modules;
	}

	protected override void OnAppearing()
    {
        base.OnAppearing();
		_level.CalculateLevelGrade();
		moduleCollectionView.ItemsSource = null;
		moduleCollectionView.ItemsSource = _level.Modules;
    }

    protected override void OnDisappearing()
    {
        base.OnDisappearing();
		_level.CalculateLevelGrade();
		_saveQualifications();

    }

    private void OnModuleSelected(object sender, SelectionChangedEventArgs e)
	{
		if (e.CurrentSelection.FirstOrDefault() is Modules selectedModule)
        {
			moduleCollectionView.SelectedItem = null;
            Navigation.PushAsync(new ModulePage(selectedModule, _saveQualifications));
        }
	}

	private void OnAddModuleClicked(object sender, EventArgs e)
	{
		var newModule = new Modules
		{
			ModuleName = "New Module",
			ModuleCode = "XXXX",
			Credits = 10,
			StartDate = DateTime.Now,
			EndDate = DateTime.Now.AddMonths(12),
			ModuleGrade = 0.0f
		};
		_level.Modules.Add(newModule);

		moduleCollectionView.ItemsSource = null;
		moduleCollectionView.ItemsSource = _level.Modules;

		_saveQualifications();
	}
}