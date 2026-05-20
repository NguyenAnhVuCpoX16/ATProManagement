using System;
using System.Collections.Generic;
using System.Text;

namespace ATProManagement.Base
{
    public interface ISweetAlertService
    {
        Task Success(string message, string title = "Success");

        Task Error(string message, string title = "Error");

        Task Warning(string message, string title = "Warning");

        Task<bool> Confirm(string message, string title = "Confirm");

        Task Loading(string title = "Loading...");

        Task Close();

        Task Toast(string message);
    }
}
