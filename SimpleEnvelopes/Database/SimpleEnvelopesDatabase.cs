using System.Collections.Generic;
using DnetIndexedDb.Models;

namespace SimpleEnvelopes.Database {
    public class AppDatabase : IndexedDbDatabaseModel
    {
        public AppDatabase()
        {
            Name = "Simple-Envelopes";
            Version = 1;
            
        }

        private List<IndexedDbStore> _stores => new List<IndexedDbStore>
        {
            _fundingScheduleStore
        };

        private IndexedDbStore _fundingScheduleStore => new TStore<FundingSchedule>("FundingSchedules");
    }
}