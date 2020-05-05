using CrazyElephant.Models;
using CrazyElephant.Services;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CrazyElephant.ViewModels
{
    class MainWindowViewModel : ViewModelBase
    {
        public MainWindowViewModel()
        {
            LoadRestaurant();
            LoadDishMenu();
            PlaceOrderCommand = new RelayCommand(PlaceOrder);
            SelectCommand = new RelayCommand(Select);

        }
        public RelayCommand PlaceOrderCommand { get; set; }
        public RelayCommand SelectCommand { get; set; }

        private int _count;

        public int Count
        {
            get { return _count; }
            set
            {
                _count = value;
                this.RaisePropertyChanged("Count");
            }
        }

        private Restaurant _restaurant;

        public Restaurant Restaurant
        {
            get { return _restaurant; }
            set
            {
                _restaurant = value;
                this.RaisePropertyChanged("Restaurant");
            }
        }

        private ObservableCollection<DishMenuItemViewModel> _dishMenu;

        public ObservableCollection<DishMenuItemViewModel> DishMenu
        {
            get { return _dishMenu; }
            set
            {
                _dishMenu = value;
                this.RaisePropertyChanged("DishMenu");
            }
        }

        private void LoadRestaurant()
        {
            Restaurant = new Restaurant()
            {
                Name = "悦来客栈",
                Address = "上海市杨浦区军工路516号",
                PhoneNumber = "7758521 or 1545155451"
            };
        }

        private void LoadDishMenu()
        {
            IDataService xmlDataService = new XmlDataService();
            var dishList = xmlDataService.GetAllDishes();
            DishMenu = new ObservableCollection<DishMenuItemViewModel>();
            foreach (var item in dishList)
            {
                DishMenuItemViewModel itemViewModel = new DishMenuItemViewModel()
                {
                    Dish = item,
                };
                DishMenu.Add(itemViewModel);
            }
        }

        private void PlaceOrder()
        {
            var selectedDishes = DishMenu.Where(p => p.IsSelected == true).Select(p => p.Dish.Name).ToList();
            IOrderService orderService = new MockOrderService();
            orderService.PlaceOrder(selectedDishes);
            MessageBox.Show("订餐成功");
        }

        private void Select()
        {
            Count = DishMenu.Count(p => p.IsSelected == true);
        }
    }
}
