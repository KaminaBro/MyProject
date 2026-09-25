using CommunityToolkit.Mvvm.ComponentModel;
using MyProject.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.ViewModels
{
    public partial class TovarViewModel: ViewModelBase
    {
        public event Action<bool>? CloseRequest;
        [ObservableProperty]
        private ObservableCollection<Tovar> tovarsList;
        [ObservableProperty]
        private Tovar selectedTovar=null!;
        public TovarViewModel()
        {
            TovarsList = new ObservableCollection<Tovar>(getAll());
           // Load();
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
                Task<List<Tovar>> task = Task.Run(() => db.Tovars.ToList());
                return task.Result;
            }
        }
    }
}
