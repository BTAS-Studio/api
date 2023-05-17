using BTAS.BlazorApp.Services.Interface;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using TableDependency.SqlClient;

namespace BTAS.BlazorApp.Services
{
    public class TableChangeBroadcastService<T> : ITableChangeBroadcastService<T> where T : class
    {
        private const string TableName = "Stocks";
        private SqlTableDependency<T> _notifier;
        private IConfiguration _configuration;
        private IHttpClientFactory _client;

        public event TChangeDelegate OnTChanged;

        public TableChangeBroadcastService(IHttpClientFactory client, IConfiguration configuration) : base(client)
        {
            _client = client;
            this._configuration = configuration;

            // SqlTableDependency will trigger an event 
            // for any record change on monitored table  
            _notifier = new SqlTableDependency<T>(
                 _configuration["ConnectionString"],
                 TableName);
            _notifier.OnChanged += this.TableDependency_Changed;
            _notifier.Start();
        }

        // This method will notify the Blazor component about the stock price change stock
        private void TableDependency_Changed(object sender, RecordChangedEventArgs<T> e)
        {
            this.OnTChanged(this, new TChangeEventArgs(e.Entity, e.EntityOldValues));
        }

        // This method is used to populate the HTML view 
        // when it is rendered for the first time
        public IList<T> GetCurrentValues()
        {
            var result = new List<T>();

            result = await 

            return result;
        }

        public void Dispose()
        {
            _notifier.Stop();
            _notifier.Dispose();
        }
    }
}
