﻿using System;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace MVVMDemo
{
    public class ViewModel : ViewModelBase
    {
        private Student _student;
        private ObservableCollection<Student> _students;
        private ICommand _SubmitCommand;

        public Student Student
        {
            get => _student;
            set
            {
                _student = value;
                OnPropertyChanged("Student");
            }
        }

        public ObservableCollection<Student> Students
        {
            get => _students;
            set
            {
                _students = value;
                OnPropertyChanged("Students");
            }
        }

        public ICommand SubmitCommand
        {
            get
            {
                if (_SubmitCommand == null)
                {
                    _SubmitCommand = new RelayCommand(param => this.Submit(),
                        null);
                }
                return _SubmitCommand;
            }
        }

        public ViewModel()
        {
            Student = new Student();
            Students = new ObservableCollection<Student>();
            Students.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(Students_CollectionChanged);
        }

        private void Students_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) => OnPropertyChanged("Students");

        private void Submit()
        {
            Student.JoiningDate = DateTime.Today.Date;
            Students.Add(Student);
            Student = new Student();
        }
    }
}