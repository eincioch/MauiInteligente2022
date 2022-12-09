using MauiInteligente2022.AppBase.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiInteligente2022.ViewModels {
    public class SplashViewModel : BaseViewModel {
        private readonly IServiceProvider _sp;
        public SplashViewModel(IServiceProvider sp) {
            _sp = sp;
            PageId = SPLASH_PAGE_ID;
        }

        public override async Task OnAppearing() {
            await Task.Delay(3000);
            BindedPage next = _sp.GetRequiredService<LoginPage>();
            Application.Current.MainPage = new NavigationPage(next);
        }
    }
}
