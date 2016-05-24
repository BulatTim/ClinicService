using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;

namespace Clinic.Bisuness.Services.Classes
{
    public static class Logger
    {
        private static readonly ILog errorLog =
             LogManager.GetLogger("ErrorAppender");
        private static readonly ILog infoLog =
            LogManager.GetLogger("InfoWarningAppender");
        public static void Error(Exception ex)
        {
            errorLog.Error(ex.Message);
        }
        public static void Info(Exception ex)
        {
            infoLog.Info(ex.Message);
        }
        public static void Warn(Exception ex)
        {
            infoLog.Warn(ex.Message);
        }
    }
}
