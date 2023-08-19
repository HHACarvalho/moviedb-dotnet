namespace moviedb_dotnet.Core
{
    public class Utils
    {
        public static string LogMessage(bool isSuccess, string methodName)
        {
            return (
                (isSuccess ? "SUCCESS | " : "FAILURE | ") +
                methodName + "() request received -> " +
                DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")
            );
        }
    }
}
