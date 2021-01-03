using Domin.Models;
using System;

namespace UwpApp.ViewModel.SettingsViewModelfolder
{
    public class CollectionSiteViewModel : BindableBase

    {
        public CollectionSiteViewModel(CollectionSite collectionSite = null)
        {
            CollectionSite = collectionSite ?? new CollectionSite();
        }


        public CollectionSite CollectionSite { get; set; }

        public int CollectionSIteId
        {
            get => CollectionSite.CollectionSIteID;
            set
            {
                if (CollectionSite.CollectionSIteID != value)
                {
                    CollectionSite.CollectionSIteID = value;
                    OnPropertyChanged();
                }
            }
        }
        public String CollectionSiteName
        {
            get => CollectionSite.CollectionSiteName;
            set
            {


                if (CollectionSite.CollectionSiteName != value)
                {
                    CollectionSite.CollectionSiteName = value;
                    OnPropertyChanged();
                }
            }
        }
    }
}

