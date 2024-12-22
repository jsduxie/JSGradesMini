using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Handlers;
using Microsoft.Maui.Handlers;
using UIKit;

namespace JSGradesMini;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();
		
	}

	protected override Window CreateWindow(IActivationState activationState)    
	{
		var window = new Window();        
		window.HandlerChanged += windowHandlerChanged;        
		var rootPage = new QualDashboardPage();        
		window.Page = rootPage;        
		return window;    
	}

	private void windowHandlerChanged(object sender, EventArgs e)    
	{        
		var win = sender as Microsoft.Maui.Controls.Window;        
		var uiWin = win.Handler.PlatformView as UIWindow;        
		if (uiWin != null)        
		{            
			uiWin.WindowScene.Titlebar.TitleVisibility = UITitlebarTitleVisibility.Hidden;        
		}   
	}

}
