using MauiInteligente2022.AppBase.Objects;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IdentityModel.Tokens.Jwt;
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
            BindedPage next = null!;

            if (AppConfiguration.UserToken is not null) {
                var securityToken = new JwtSecurityToken(AppConfiguration.UserToken);
                if (securityToken.ValidTo > DateTime.UtcNow
                    && securityToken.ValidFrom < DateTime.UtcNow) {
                    next = _sp.GetRequiredService<MainMenuPage>();
                } else {
                    AppConfiguration.UserToken = null;
                    next = _sp.GetRequiredService<LoginPage>();
                }
            } else {
                if (AppConfiguration.HasLanguageSelection) {
                    CultureInfo cultureInfo = AppConfiguration.AppLanguage switch {
                        Languages.Spanish => new("es-mx"),
                        Languages.English => new("en"),
                        _ => new("en")
                    };

                    Resources.Culture = cultureInfo;
                    Thread.CurrentThread.CurrentCulture = cultureInfo;
                    Thread.CurrentThread.CurrentUICulture = cultureInfo;
                }

                next = AppConfiguration.UserAcceptTerms
                    ? _sp.GetRequiredService<LoginPage>()
                    : _sp.GetRequiredService<LanguageSelectionPage>();
            }
            Application.Current.MainPage = new NavigationPage(next);
        }
    }
}
