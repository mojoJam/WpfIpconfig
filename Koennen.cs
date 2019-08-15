using System;
using System.ComponentModel;
using System.Linq.Expressions;
 

namespace WpfAzubi.Models
{
    public class Koennen      : INotifyPropertyChanged
    {

        public Koennen()
        {
          
        }

        public int id
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
                RaisePropertyChanged(() => this.id);
            }
        }
        private int _id  ;

        public bool IsSelected
        {
            get
            {
                return _IsSelected;
            }
            set
            {
                _IsSelected = value;
                RaisePropertyChanged(() => this.IsSelected);
            }
        }

        private bool _IsSelected = false;


        public string name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                RaisePropertyChanged(() => this.name);
            }
        }

        private string _name = string.Empty;





        public event PropertyChangedEventHandler PropertyChanged;


        protected void RaisePropertyChanged<T>(Expression<Func<T>> x)
        {
            var body = x.Body as MemberExpression;
            if (body != null)
            {

                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(body.Member.Name));



                }


            }
        }

        public string GetPropertyName<T>(Expression<Func<T>> expression)
        {
            MemberExpression memberExpression = (MemberExpression)expression.Body;
            return memberExpression.Member.Name;
        }



    }
}
