using Domin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UwpApp.ViewModel.SettingsViewModelfolder
{
   public class CollectionSiteViewModel: BindableBase

    {
        public CollectionSiteViewModel( CollectionSite collectionSite=null)
        {
            CollectionSite = collectionSite ?? new CollectionSite();
        }


        public CollectionSite CollectionSite { get; set; }

        public int CollectionSIteId 
        { get=>CollectionSite.CollectionSIteID;
            set
            {
                if (CollectionSite.CollectionSIteID!=value)
                {
                    CollectionSite.CollectionSIteID = value;
                    OnPropertyChanged();
                } } }
        public String CollectionSiteName 
        { get=>CollectionSite.CollectionSiteName;
            set {


                if (CollectionSite.CollectionSiteName!=value)
                {
                    CollectionSite.CollectionSiteName = value;
                    OnPropertyChanged();
                }
            } }
    }
}

