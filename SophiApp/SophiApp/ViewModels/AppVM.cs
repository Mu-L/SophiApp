﻿using SophiApp.Commons;
using SophiApp.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace SophiApp.ViewModels
{
    internal class AppVM : INotifyPropertyChanged
    {
        private UILanguage appLocalization;
        private bool hamburgerIsEnabled = true;
        private string viewVisibilityByTag = Tags.ViewPrivacy;
        private uint uielementsChangedCounter = default;

        public AppVM()
        {
            UIElementClickedCommand = new RelayCommand(new Action<object>(UIElementClickedAsync));
            UIElementInListClickedCommand = new RelayCommand(new Action<object>(UIElementInListClickedAsync));
            HamburgerClickedCommand = new RelayCommand(new Action<object>(HamburgerClicked));
            SearchClickedCommand = new RelayCommand(new Action<object>(SearchClicked));

            AppLocalization = Localizator.Initializing();
            InitializingUIModelsAsync();
            SetUIModelsSystemStateAsync();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public string AppName => Application.Current.FindResource("CONST.AppName") as string;

        public UILanguage AppLocalization
        {
            get => appLocalization;
            private set
            {
                appLocalization = value;
                OnPropertyChanged("AppLocalization");
            }
        }

        public RelayCommand HamburgerClickedCommand { get; }

        //TODO: Deprecated?
        /// <summary>
        /// Determines the Hamburger state
        /// </summary>
        public bool HamburgerIsEnabled
        {
            get => hamburgerIsEnabled;
            private set
            {
                hamburgerIsEnabled = value;
                OnPropertyChanged("HamburgerIsEnabled");
            }
        }

        public uint UIElementsChangedCounter
        {
            get => uielementsChangedCounter;
            private set
            {
                uielementsChangedCounter = value;
#if DEBUG
                Debug.WriteLine($"UIElements Changed Counter:{uielementsChangedCounter}");
#endif
                OnPropertyChanged("UIElementsChangedCounter");
            }
        }

        public RelayCommand SearchClickedCommand { get; }
        public RelayCommand UIElementClickedCommand { get; }
        public RelayCommand UIElementInListClickedCommand { get; }
        public List<IUIElementModel> UIModels { get; set; }

        public string ViewVisibilityByTag
        {
            get => viewVisibilityByTag;
            private set
            {
                viewVisibilityByTag = value;
                OnPropertyChanged("ViewVisibilityByTag");
            }
        }

        private void HamburgerClicked(object args)
        {
            var tag = args as string;
            if (ViewVisibilityByTag == tag)
            {
                return;
            }
            ViewVisibilityByTag = tag;
        }

        private void InitializingUIModelsAsync()
        {
            var task = Task.Run(() =>
            {
                var parsedJsons = Parser.ParseJson(Properties.Resources.UIElementsData);
                UIModels = parsedJsons.Select(dto => Fabric.CreateElementModel(dto)).ToList();
                UIModels.ForEach(model => model.SetLocalizationTo(AppLocalization));
            });
            task.Wait();
        }

        private void OnPropertyChanged(string propertyChanged) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyChanged));

        private void SearchClicked(object args)
        {
            var searchString = args as string;
            //TODO : Search not implemented !!!
        }

        private void SetUIModelsSystemStateAsync()
        {
            var task = Task.Run(() =>
            {
                UIModels.ForEach(m =>
                {
                    if (m.Id % 2 == 0) m.SetSystemState();
                });
            });
            task.Wait();
        }

        private void UIElementClickedAsync(object args)
        {
            var task = Task.Run(() =>
            {
                var id = Convert.ToInt32(args);
                var element = UIModels.Where(m => m.Id == id).First();
                element.SetUserState();
                UIElementHasChangedAsync(element.UserState);
            });
            task.Wait();
        }

        private void UIElementHasChangedAsync(bool userState)
        {
            var task = Task.Run(() =>
            {
                if (userState)
                {
                    UIElementsChangedCounter++;
                    return;
                }

                UIElementsChangedCounter--;
            });
            task.Wait();
        }

        private void UIElementInListClickedAsync(object args)
        {
            var task = Task.Run(() =>
            {
                var ids = args as List<int>;
                var listId = ids.First();
                var elementId = ids.Last();
                var list = UIModels.Where(m => m.Id == listId).First() as IItemsListModel;

                if (list.SelectOnce)
                {
                    UIModels.Where(m => list.ChildId.Contains(m.Id)).ToList().ForEach(m =>
                    {
                        if (m.Id == elementId && m.IsChecked == false)
                        {
                            m.SystemState = false;
                            m.UserState = true;
                            m.IsChecked = true;
                            UIElementHasChangedAsync(m.UserState);
                        }
                        else if (m.Id != elementId)
                        {
                            m.SystemState = false;
                            m.UserState = false;
                            m.IsChecked = false;
                        }
                    });
                }
                else
                {
                    var element = UIModels.Where(m => m.Id == elementId).First();
                    element.SetUserState();
                    UIElementHasChangedAsync(element.UserState);
                }
            });
            task.Wait();
        }
    }
}