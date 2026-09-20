using CommunityToolkit.Mvvm.ComponentModel;
using MyProject.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace MyProject.ViewModels
{
    public partial class TovarViewModel: ViewModelBase
    {
        [ObservableProperty]
        public ObservableCollection<Tovar> tovarsList = new();
        [ObservableProperty]
        private Tovar selectedTovar;
        public TovarViewModel()
        {
            Load();
        }
        private void Load()
        {
            TovarsList.Clear();
            TovarsList = new ObservableCollection<Tovar>(getAll());
        }
        private List<Tovar> getAll()
        {
            using (PostgresContext db=new PostgresContext())
            {
                return db.Tovars.ToList();
            }
        }
    }
}
