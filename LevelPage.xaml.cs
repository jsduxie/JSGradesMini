namespace JSGradesMini;

public partial class LevelPage : ContentPage
{
	private Level _level;
	public LevelPage(Level level)
	{
		InitializeComponent();
		_level = level;
		BindingContext = _level;
		moduleCollectionView.ItemsSource = _level.Modules;
	}

	protected override void OnAppearing()
    {
        base.OnAppearing();

		moduleCollectionView.ItemsSource = null;
		moduleCollectionView.ItemsSource = _level.Modules;
    }

    private void OnModuleSelected(object sender, SelectionChangedEventArgs e)
	{
		if (e.CurrentSelection.FirstOrDefault() is Modules selectedModule)
        {
			moduleCollectionView.SelectedItem = null;
            Navigation.PushAsync(new ModulePage(selectedModule));
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
	}
}