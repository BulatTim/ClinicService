using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clinic.Bisuness.Services.Implementation;
using Clinic.DTO;
using log4net;




namespace Clinic.Bisuness.Services.Classes
{
    public static class Invoker
    {
        public static void InvokeAction<T1>(Action<T1> methodToInvoke, T1 t1)
        {
            var isLogEnable = false;
            try
            {

                var attributeArray = methodToInvoke.Method.GetCustomAttributes(typeof (HandleErrorAttribute), false);
                if (attributeArray.Length > 0)
                {
                    var loggerAttribute = attributeArray[0] as HandleErrorAttribute;
                    if (loggerAttribute != null)
                    {
                        isLogEnable = loggerAttribute.IsLogEnable;
                    }
                }
                methodToInvoke(t1);
            }
            catch (ArgumentException exception)
            {

                if (isLogEnable)
                {
                    Logger.Error(exception);
                }
                throw;
            }
            catch (NullReferenceException exception)
            {

                if (isLogEnable)
                {
                    Logger.Warn(exception);
                }
                throw;
            }
        }

        public static void InvokeAction<T1,T2>(Action<T1,T2> methodToInvoke, T1 t1,T2 t2)
        {
            var isLogEnable = false;
            try
            {

                var attributeArray = methodToInvoke.Method.GetCustomAttributes(typeof(HandleErrorAttribute), false);
                if (attributeArray.Length > 0)
                {
                    var loggerAttribute = attributeArray[0] as HandleErrorAttribute;
                    if (loggerAttribute != null)
                    {
                        isLogEnable = loggerAttribute.IsLogEnable;
                    }
                }
                methodToInvoke(t1,t2);
            }
            catch (ArgumentException exception)
            {

                if (isLogEnable)
                {
                    Logger.Error(exception);
                }
                throw;
            }
            catch (NullReferenceException exception)
            {

                if (isLogEnable)
                {
                    Logger.Warn(exception);
                }
                throw;
            }
        }
        public static T2 Invoke<T1,T2>(Func<T1,T2> methodToInvoke, T1 t1)
        {
            var isLogEnable = false;
            try
            {
                
                var attributeArray = methodToInvoke.Method.GetCustomAttributes(typeof(HandleErrorAttribute), false);
                if (attributeArray.Length > 0)
                {
                    var loggerAttribute = attributeArray[0] as HandleErrorAttribute;
                    if (loggerAttribute != null)
                    {
                        isLogEnable = loggerAttribute.IsLogEnable;
                    }
                }

                return methodToInvoke(t1);
            }
            catch (Exception exception)
            {
                
                if (isLogEnable)
                {
                    
                }
                throw;
            }            
        }

        public static T3 Invoke<T1, T2,T3>(Func<T1, T2, T3> methodToInvoke, T1 t1, T2 t2)
        {
            var isLogEnable = false;
            try
            {

                var attributeArray = methodToInvoke.Method.GetCustomAttributes(typeof(HandleErrorAttribute), false);
                if (attributeArray.Length > 0)
                {
                    var loggerAttribute = attributeArray[0] as HandleErrorAttribute;
                    if (loggerAttribute != null)
                    {
                        isLogEnable = loggerAttribute.IsLogEnable;
                    }
                }

                return methodToInvoke(t1,t2);
            }
            catch (Exception exception)
            {

                if (isLogEnable)
                {
                    Logger.Error(exception);
                }
                throw;
            }
        }

        public static T4 Invoke<T1, T2, T3,T4>(Func<T1, T2, T3,T4> methodToInvoke, T1 t1, T2 t2,T3 t3)
        {
            var isLogEnable = false;
            try
            {

                var attributeArray = methodToInvoke.Method.GetCustomAttributes(typeof(HandleErrorAttribute), false);
                if (attributeArray.Length > 0)
                {
                    var loggerAttribute = attributeArray[0] as HandleErrorAttribute;
                    if (loggerAttribute != null)
                    {
                        isLogEnable = loggerAttribute.IsLogEnable;
                    }
                }

                return methodToInvoke(t1, t2,t3);
            }
            catch (Exception exception)
            {

                if (isLogEnable)
                {
                    Logger.Error(exception);
                }
                throw;
            }
        }

        public static T5 Invoke<T1, T2, T3, T4,T5>(Func<T1, T2, T3, T4,T5> methodToInvoke, T1 t1, T2 t2, T3 t3,T4 t4)
        {
            var isLogEnable = false;
            try
            {

                var attributeArray = methodToInvoke.Method.GetCustomAttributes(typeof(HandleErrorAttribute), false);
                if (attributeArray.Length > 0)
                {
                    var loggerAttribute = attributeArray[0] as HandleErrorAttribute;
                    if (loggerAttribute != null)
                    {
                        isLogEnable = loggerAttribute.IsLogEnable;
                    }
                }

                return methodToInvoke(t1, t2, t3,t4);
            }
            catch (Exception exception)
            {

                if (isLogEnable)
                {
                    Logger.Error(exception);
                }
                throw;
            }
        }
    }
}
