﻿using Microsoft.Maui;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.PlatformConfiguration.WindowsSpecific;
using Application = Microsoft.Maui.Controls.Application;

namespace AdventureLog
{
	public partial class App : Application
	{
		public App()
		{
			InitializeComponent();

			MainPage = new MainPage();
		}
	}
}
