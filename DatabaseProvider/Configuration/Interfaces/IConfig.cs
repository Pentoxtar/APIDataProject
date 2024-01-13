using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseProvider.Configuration.Interfaces
{
    public interface IConfig
    {
        public string LogFilePath { get; set; }

        public string SqliteDbPath { get; set; }

    }
}
