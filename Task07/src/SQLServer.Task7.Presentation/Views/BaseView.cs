﻿using DAO.DataAccess.Singleton;
using SQLServer.Task7.Presentation.Interfaces;

namespace SQLServer.Task7.Presentation.Views
{
    /// <summary>
    /// Base class for view.
    /// </summary>
    public abstract class BaseView
    {
        /// <summary>
        /// Acceess to database.
        /// </summary>
        protected SingletonLinqToSql SingletonDboAccess { get; private set; }

        /// <summary>
        /// Tables for view.
        /// </summary>
        protected IView View;

        /// <summary>
        /// Empty constructor.
        /// </summary>
        public BaseView() { }

        /// <summary>
        /// Initial view.
        /// </summary>
        /// <param name="view">View property.</param>
        public BaseView(IView view) : this() => View = view;

        /// <summary>
        /// Iitialazing access to database and view.
        /// </summary>
        /// <param name="singletonDboAccess">SingletonDboAccess parameter.</param>
        /// <param name="view">View parameter.</param>
        public BaseView(SingletonLinqToSql singletonDboAccess, IView view) : this(view) => SingletonDboAccess = singletonDboAccess;
    }
}
