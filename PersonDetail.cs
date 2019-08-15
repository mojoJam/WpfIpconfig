using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq.Expressions;
 

namespace WpfAzubi.Models
{
    public class PersonDetail : INotifyPropertyChanged
    {

        public PersonDetail()
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

        public string vorName
        {
            get
            {
                return _vorName;
            }
            set
            {
                _vorName = value;
                RaisePropertyChanged(() => this.vorName);
            }
        }
        private string _vorName = string.Empty;

        public List<Koennen> koennenObser
        {
            get { return _koennenObser; }
            set
            {
                _koennenObser = value;
                RaisePropertyChanged(() => this.koennenObser);
            }
        }
        private List<Koennen> _koennenObser = new List<Koennen>();


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
