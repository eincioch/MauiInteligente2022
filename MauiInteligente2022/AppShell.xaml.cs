﻿namespace MauiInteligente2022;

public partial class AppShell : Shell {
	public AppShell() {
		InitializeComponent();

		Routing.RegisterRoute(ABOUT_PAGE_ID, typeof(AboutPage));
		Routing.RegisterRoute(BRANCH_DETAIL_ID, typeof(BranchDetailPage));
    }
}