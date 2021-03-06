﻿using Domin.Common;
using Domin.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ViewModels.Infrastructure.Services;
using ViewModels.ViewModels.Home;

namespace ViewModels.ViewModels.Shell
{
    public class MainShellViewModel : ShellViewModel
    {
        private readonly NavigationItem DashboardItem = new NavigationItem(0xE80F, "Dashboard", typeof(HomePageViewModel));
        //private readonly NavigationItem SettingsItem = new NavigationItem(0x0000, "Settings", typeof(SettingsViewModel));

        public MainShellViewModel(ILoginService loginService, ICommonServices commonServices) : base(loginService, commonServices)
        {
        }

        private object _selectedItem;
        public object SelectedItem
        {
            get => _selectedItem;
            set => Set(ref _selectedItem, value);
        }

        private bool _isPaneOpen = true;
        public bool IsPaneOpen
        {
            get => _isPaneOpen;
            set => Set(ref _isPaneOpen, value);
        }

        private IEnumerable<NavigationItem> _items;
        public IEnumerable<NavigationItem> Items
        {
            get => _items;
            set => Set(ref _items, value);
        }

        public override async Task LoadAsync(ShellArgs args)
        {
            Items = GetItems().ToArray();
            await UpdateAppLogBadge();
            await base.LoadAsync(args);
        }

        override public void Subscribe()
        {
            MessageService.Subscribe<ILogService, AppLog>(this, OnLogServiceMessage);
            base.Subscribe();
        }

        override public void Unsubscribe()
        {
            base.Unsubscribe();
        }

        public override void Unload()
        {
            base.Unload();
        }

        public async void NavigateTo(Type viewModel)
        {
            switch (viewModel.Name)
            {
                case "DashboardViewModel":
                    NavigationService.Navigate(viewModel);
                    break;
                    //case "CustomersViewModel":
                    //    NavigationService.Navigate(viewModel, new CustomerListArgs());
                    //    break;
                    //case "OrdersViewModel":
                    //    NavigationService.Navigate(viewModel, new OrderListArgs());
                    //    break;
                    //case "ProductsViewModel":
                    //    NavigationService.Navigate(viewModel, new ProductListArgs());
                    //    break;
                    //case "AppLogsViewModel":
                    //    NavigationService.Navigate(viewModel, new AppLogListArgs());
                    //    await LogService.MarkAllAsReadAsync();
                    //    await UpdateAppLogBadge();
                    //    break;
                    //case "SettingsViewModel":
                    //    NavigationService.Navigate(viewModel, new SettingsArgs());
                    //    break;
                    //default:
                    //    throw new NotImplementedException();
            }
        }

        private IEnumerable<NavigationItem> GetItems()
        {
            yield return DashboardItem;
            //yield return CustomersItem;
            //yield return OrdersItem;
            //yield return ProductsItem;
            //yield return AppLogsItem;
        }

        private async void OnLogServiceMessage(ILogService logService, string message, AppLog log)
        {
            if (message == "LogAdded")
            {
                await ContextService.RunAsync(async () =>
                {
                    await UpdateAppLogBadge();
                });
            }
        }

        private async Task UpdateAppLogBadge()
        {
            int count = await LogService.GetLogsCountAsync(new DataRequest<AppLog> { Where = r => !r.IsRead });
            //AppLogsItem.Badge = count > 0 ? count.ToString() : null;
        }

    }
}
