﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Swd.Bsp.Binding
{
    /// <summary>
    /// Interaction logic for fObjectBinding.xaml
    /// </summary>
    public partial class fCollectionBinding : Window
    {

        private Window _callerWindow;
        private ObservableCollection<Customer> _customerList;

        public ObservableCollection<Customer> CustomerList
        {
            get { return _customerList; }
            set { _customerList = value; }
        }


        public Window CallerWindow
        {
            get { return _callerWindow; }
            set { _callerWindow = value; }
        }
        public fCollectionBinding()
        {
            InitializeComponent();
        }

        public fCollectionBinding(Window callerWindow) : this()
        {
            CallerWindow = callerWindow;
            CustomerList = new ObservableCollection<Customer>
            {
            new Customer { Name = "Matthias", Email = "email1@net.com", PhoneNumber = "123", Id = 1 },
            new Customer { Name = "Gustav", Email = "email2@net.com", PhoneNumber = "456", Id = 2 },
            new Customer { Name = "Karl", Email = "email3@net.com", PhoneNumber = "789", Id = 3 }
            };

            lstCustomer.ItemsSource = _customerList;
            this.DataContext = CustomerList;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Customer newCustomer = new Customer { Name = "Johannes", Email = "email_xy@net.com", PhoneNumber = "3321", Id = 12 };
            CustomerList.Add(newCustomer);
        }
    }
}

