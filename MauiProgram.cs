using Microsoft.Extensions.Logging;

namespace JSGradesMini;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
				fonts.AddFont("Roboto-Bold.ttf", "RobotoBold");
				fonts.AddFont("Roboto-Regular.ttf", "RobotoRegular");
			});

#if DEBUG
		builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}
