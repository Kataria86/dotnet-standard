using RedisWPF_CRUD.Model;
using RedisWPF_CRUD.RedisDBOperations;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace RedisWPF_CRUD
{
    public class StudentVM : INotifyPropertyChanged
    {

        DBOperation _objDataSource = new DBOperation();

        public ObservableCollection<Student> StudentList
        {
            get;
            set;
        }


        public StudentVM()
        {

            var r = _objDataSource.GetStudentRecords();
            StudentList = new ObservableCollection<Student>(r);
        }
        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyOfPropertyChange(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
