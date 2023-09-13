using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanProgMgt.Application.Services.BackgroundService
{
    public interface IBackgroundServices
    {
        void tasksDueSoon();
        void test();
    }
}
