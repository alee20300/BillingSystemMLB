using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels.Infrastructure.Services
{
    public interface IContextService
    {

        int MainViewID { get; }

        int ContextID { get; }

        bool IsMainView { get; }

        void Initialize(object dispatcher, int contextID, bool isMainView);

        Task RunAsync(Action action);
    }
}
