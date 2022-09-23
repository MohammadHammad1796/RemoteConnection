using RemoteServices.Models;

namespace RemoteServices.Services
{
    public interface ISqlService
    {
        SqlResult ExecuteCommand(string sqlCommand);

        SqlResult ExecuteQuery(string sqlQuery);
    }
}
