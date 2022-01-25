using Microsoft.AspNetCore.Components.WebView.Maui;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Maui;
using Microsoft.Maui.Hosting;
using Microsoft.Maui.Controls.Compatibility;
using Microsoft.Maui.Controls.Hosting;
using AdventureLog.Data;
using AdventureLog.Data.Factories;

namespace AdventureLog
{
	public static class MauiProgram
	{
		public static MauiApp CreateMauiApp()
		{
			var builder = MauiApp.CreateBuilder();
			builder
				.RegisterBlazorMauiWebView()
				.UseMauiApp<App>()
				.ConfigureFonts(fonts =>
				{
					fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				});

			builder.Services.AddBlazorWebView();
			builder.Services.AddSingleton<Repository>();
			builder.Services.AddSingleton<UserTaskFactory>();
			builder.Services.AddSingleton<RewardFactory>();

			return builder.Build();
		}
	}
}