using DoorData.Domain;
using DoorData.Data;
using System.Text.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Security.Cryptography.X509Certificates;
using Microsoft.Extensions.Configuration;

namespace DoorData.FrontEnd.Services
{
    public class MilleniumHistoryService
    {
        private readonly MilleniumHistoryRepository _repository;


        public MilleniumHistoryService(IConfiguration Configuration)
        {
            this._repository = new MilleniumHistoryRepository(Configuration.GetConnectionString("Millenium"));
        }

        public IEnumerable<MilleniumHistoryEntry> Get(int Max)
        {
            return _repository.Get(Max);
        }

        public IEnumerable<MilleniumHistoryEntry> Get(DateTime SinceDate)
        {
            return _repository.Get(SinceDate);
        }


    }
}