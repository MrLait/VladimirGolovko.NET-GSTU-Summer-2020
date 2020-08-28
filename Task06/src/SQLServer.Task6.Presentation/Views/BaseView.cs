using DAO.DataAccess.Singleton;
using SQLServer.Task6.Domain.Models;
using SQLServer.Task6.Presentation.Interfaces;
using System.Collections.Generic;

namespace SQLServer.Task6.Presentation.Views
{
    public abstract class BaseView
    {
        protected SingletonDboAccess SingletonDboAccess { get; private set; }
        protected IView View;

        public BaseView() { }

        public BaseView(IView view) : this() => View = view;

        public BaseView(SingletonDboAccess singletonDboAccess, IView view) : this(view) => SingletonDboAccess = singletonDboAccess;
    }
}
