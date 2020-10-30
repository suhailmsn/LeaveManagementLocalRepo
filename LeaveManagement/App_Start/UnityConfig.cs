using System;
using Unity;
using Unity.AspNet.Mvc;
using System.Web.Mvc;
using LeaveManagement.Repositories;
using Unity.Injection;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using LeaveManagement.ServiceLayer.Interfaces;
using LeaveManagement.ServiceLayer;
using LeaveManagement.Repository.Interfaces;

namespace LeaveManagement
{
    /// <summary>
    /// Specifies the Unity configuration for the main container.
    /// </summary>
    public static class UnityConfig
    {
        #region Unity Container
        private static Lazy<IUnityContainer> container =
          new Lazy<IUnityContainer>(() =>
          {
              var container = new UnityContainer();
              RegisterTypes(container);
              return container;
          });

        /// <summary>
        /// Configured Unity Container.
        /// </summary>
        public static IUnityContainer Container => container.Value;
        #endregion

       
        public static void RegisterTypes(IUnityContainer container)

        {
            container.RegisterType<IHRService, HRService>();
            container.RegisterType<IEmployeeService, EmployeeService>();
            container.RegisterType<IEmployeeRepository, EmployeeRepository>();

        }
    }
}