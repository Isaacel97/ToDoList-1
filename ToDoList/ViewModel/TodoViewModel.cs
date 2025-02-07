﻿using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.ObjectModel;
using ToDoList.Models;
using ToDoList.Pages;
using ToDoList.Services;

namespace ToDoList.ViewModel
{
    public partial class TodoViewModel : ObservableObject
    {
        public ObservableCollection<Tarea> Tareas { get; set; }
        private IDataService fakeService;

        [ObservableProperty]
        private Tarea TareaSeleccionada;
        [ObservableProperty]
        private bool isRefresh;
        public TodoViewModel(IDataService service)
        {
            Tareas = new();
            fakeService = service;
        }
        [RelayCommand]
        public void AgrearTarea()
        {
            IsRefresh = true;
            RefreshItems();
            IsRefresh = false;
        }

        void RefreshItems()
        {
            Tareas.Clear();
            fakeService.Tasks.ForEach(Tareas.Add);
        }

        [RelayCommand]
        public void AbrirRegistro()
        {
            Shell.Current.GoToAsync(nameof(RegistroTareaPage));
        }

        [RelayCommand]
        public void EditarRegistro()
        {
            if (TareaSeleccionada == null) 
            {
                return;
            }

            ShellNavigationQueryParameters parametros = new()
            {
                { "Tarea", TareaSeleccionada }
            };

            Shell.Current.GoToAsync(nameof(RegistroTareaPage), parametros);
        }


    }
}
