﻿using CommonServiceLocator;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using UWP.Services;
using UWP.Views.Products;

namespace UWP.ViewModels
{
    public class ViewModelLocator
    {
        public enum Pages
        {
            ProductPage,
            ComputerPage,
            PhonePage,
            TabletPage,
            TVPage
        }

        /// <summary>
        /// Initializes a new instance of the ViewModelLocator class.
        /// </summary>
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            SimpleIoc.Default.Register<INavigationService>(() =>
            {
                var navigationService = new NavigationService();
                navigationService.Configure(Pages.ProductPage.ToString(), typeof(ProductPage));
                navigationService.Configure(Pages.ComputerPage.ToString(), typeof(ComputerPage));
                navigationService.Configure(Pages.PhonePage.ToString(), typeof(PhonePage));
                navigationService.Configure(Pages.TabletPage.ToString(), typeof(TabletPage));
                navigationService.Configure(Pages.TVPage.ToString(), typeof(TVPage));
                return navigationService;
            });

            SimpleIoc.Default.Register<ProductPageViewModel>();
            SimpleIoc.Default.Register<ComputerPageViewModel>();
            SimpleIoc.Default.Register<PhonePageViewModel>();
            SimpleIoc.Default.Register<TabletPageViewModel>();
            SimpleIoc.Default.Register<TVPageViewModel>();

            SimpleIoc.Default.Register<DatabaseService>(() =>
            {
                return new DatabaseService();
            }, true);
        }

        public ProductPageViewModel ProductPageInstance
        {
            get { return ServiceLocator.Current.GetInstance<ProductPageViewModel>(); }
        }

        public ComputerPageViewModel ComputerPageInstance
        {
            get { return ServiceLocator.Current.GetInstance<ComputerPageViewModel>(); }
        }

        public PhonePageViewModel PhonePageInstance
        {
            get { return ServiceLocator.Current.GetInstance<PhonePageViewModel>(); }
        }

        public TabletPageViewModel TabletPageInstance
        {
            get { return ServiceLocator.Current.GetInstance<TabletPageViewModel>(); }
        }

        public TVPageViewModel TVPageInstance
        {
            get { return ServiceLocator.Current.GetInstance<TVPageViewModel>(); }
        }
    }
}
