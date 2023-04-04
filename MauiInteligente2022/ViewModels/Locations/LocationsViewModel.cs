using Java.Util.Concurrent;
using MauiInteligente2022.RestServices;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Web;

namespace MauiInteligente2022.ViewModels; 
public class LocationsViewModel : BaseViewModel {
    private readonly BranchRestService _branchRestService;
    private int currentPage;

    public LocationsViewModel(BranchRestService branchRestService) {
        PageId = BRANCHES_ID;
        Title = Resources.LocationsTitle;
        _branchRestService = branchRestService;

        LoadNextItemsCommand = new(async () => await LoadNextItemsAsync());
    }

    public Command LoadNextItemsCommand { get; set; }
    private bool isRefreshing;
    public bool IsRefreshing {
        get => isRefreshing;
        set => SetProperty(ref isRefreshing, value);
    }

    private ObservableCollection<Branch> branches = new();
    public ObservableCollection<Branch> Branches {
        get => branches;
        set => SetProperty(ref branches, value);
    }

    private Branch selectedBranch;
    public Branch SelectedBranch {
        get => selectedBranch;
        set {
            SetProperty(ref selectedBranch, value);

            SelectedBranch = null;
        }
    }

    public override async Task OnAppearing() => await LoadNextItemsAsync();

    private async Task LoadNextItemsAsync() {
        if (!IsBusy) {
            IsBusy = true;

            currentPage++;
            NameValueCollection queryString = HttpUtility.ParseQueryString(string.Empty);

            queryString.Add("currentPage", currentPage.ToString());
            queryString.Add("pageSize", "20");

            var branchesResponse = await _branchRestService.GetAllAsync($"?{queryString}");
            if (branchesResponse.Status == BaseRestClientCore.Base.RestResponseStatus.Success)
                foreach (var branch in branchesResponse.ResponseContent)
                    Branches.Add(branch);

            IsBusy = false;
        }
    }
}
