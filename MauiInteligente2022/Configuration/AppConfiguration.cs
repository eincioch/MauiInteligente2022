namespace MauiInteligente2022.Configuration {
    public static class AppConfiguration {
        const string APP_HAS_LANGUAGE_SELECTION = nameof(APP_HAS_LANGUAGE_SELECTION);
        const string APP_LANGUAGE = nameof(APP_LANGUAGE);
        const string USER_ACCEPT_TERMS = nameof(USER_ACCEPT_TERMS);
        const string USER_TOKEN = nameof(USER_TOKEN);

        public static string UserToken {
            get => Preferences.Get(USER_TOKEN, null);
            set => Preferences.Set(USER_TOKEN, value);
        }

        public static bool HasLanguageSelection {
            get => Preferences.Get(APP_HAS_LANGUAGE_SELECTION, false);
            set => Preferences.Set(APP_HAS_LANGUAGE_SELECTION, value);
        }

        public static Languages AppLanguage {
            get => (Languages)Preferences.Get(APP_LANGUAGE, (int)Languages.English);
            set => Preferences.Set(APP_LANGUAGE, (int)value);
        }

        public static bool UserAcceptTerms {
            get => Preferences.Get(USER_ACCEPT_TERMS, false);
            set => Preferences.Set(USER_ACCEPT_TERMS, value);
        }
    }
}