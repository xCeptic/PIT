﻿using System;
using System.ComponentModel;
using System.ComponentModel.Composition;
using Caliburn.Micro;
using PIT.WPF.Models.Projects;
using PIT.WPF.ViewModels.Header.Contracts;

namespace PIT.WPF.ViewModels.Header
{
    [Export(typeof(IHeaderAreaViewModel))]
    public class HeaderAreaViewModel : PropertyChangedBase, IHeaderAreaViewModel, IDisposable
    {
        private readonly ProjectSelection _projectSelection;

        [ImportingConstructor]
        public HeaderAreaViewModel(ProjectSelection projectSelection)
        {
            this._projectSelection = projectSelection;
            this._projectSelection.ProjectChanged += new EventHandler(OnProjectChanged);
        }

        private void OnProjectChanged(object sender, EventArgs e)
        {
            NotifyOfPropertyChange(() => SelectedProjectName);
        }

        public string SelectedProjectName 
        {
            get 
            {
                return _projectSelection.SelectedProject == null ? "" : _projectSelection.SelectedProject.Short;
            }
        }

        public void Dispose()
        {
            _projectSelection.ProjectChanged -= OnProjectChanged;
        }
    }
}
