using System.Diagnostics;

namespace moviedb_dotnet.Core
{
    public class Utils
    {
        public static string LogMessage(bool isSuccess)
        {
            return (
                (isSuccess ? "SUCCESS | " : "FAILURE | ") +
                new StackTrace().GetFrame(1).GetMethod().Name + "() request received -> " +
                DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")
            );
        }
    }
}
