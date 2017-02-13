using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TableTennisTournament.DAL
{
    public class DataServiceProvider
    {
        private static readonly Lazy<IDataService> DefaultHolder = new Lazy<IDataService>();
        private static IDataService _dataService;

        internal static IDataService Default => DefaultHolder.Value;

        public static IDataService Current
        {
            get { return _dataService ?? Default; }
            set { _dataService = value; }
        }
    }
}
