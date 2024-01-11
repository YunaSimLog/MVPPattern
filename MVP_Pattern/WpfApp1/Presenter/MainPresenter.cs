using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using MVPPattern.Models;
using MVPPattern.View;

namespace MVPPattern.Presenter
{
    public class MainPresenter
    {
        private readonly IMainView _view;
        private readonly IPersonRepository _personRepository;

        public MainPresenter(IMainView view, IPersonRepository personRepository)
        {
            _view = view;
            _personRepository = personRepository;

            AddEvents();
        }

        private void AddEvents()
        {
            _view.OnLoaded += OnLoaded;
            _view.OnSave += OnSave;
            _view.OnCancel += OnCancel;
            _view.OnDelete += OnDelete;
            _view.OnListItemSelected += OnListItemSelected;
        }

        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            RefreshView();
        }

        private void OnSave(object sender, RoutedEventArgs e)
        {
            var person = GetPersonFromView();
            if (_personRepository.SaveOne(person))
                RefreshView();
        }

        private void OnCancel(object sender, RoutedEventArgs e)
        {
            SetPersonInfo();
        }

        private void OnDelete(object sender, RoutedEventArgs e)
        {
            if (_personRepository.DeleteOne(_view.Id))
                RefreshView();
        }

        private void OnListItemSelected(object obj)
        {
            SetPersonInfo(obj as Person);
        }

        private Person GetPersonFromView()
        {
            return new Person
            {
                Id = _view.Id,
                Name = _view.Name,
                Sex = _view.Sex,
                Age = _view.Age
            };
        }

        private void SetPersonInfo(Person? person = null)
        {
            _view.Id = person?.Id ?? 0;
            _view.Name = person?.Name ?? "";
            _view.Sex = person?.Sex ?? "여자";
            _view.Age = person?.Age ?? 0;
        }

        private void RefreshView()
        {
            _view.ItemSource = _personRepository.GetAll();
        }
    }
}
