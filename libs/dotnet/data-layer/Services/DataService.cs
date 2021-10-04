using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfluxDB.Client;
using InfluxDB.Client.Api.Client;
using InfluxDB.Client.Api.Domain;
using InfluxDB.Client.Writes;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using WatchLog.Infra.Data.Abstract;
using WatchLog.Infra.Data.Entities;

namespace WatchLog.Infra.Data.Services
{
    public class DataService : IDataService
    {
        private readonly InfluxDBClient _dbClient;
        private readonly IPointDataCreatorProvider _pointDataCreatorProvider;
        private const string Bucket = "watchlog-dev";
        private const string Org = "F7";
        public DataService(IPointDataCreatorProvider pointDataCreatorProvider, IConfiguration configuration)
        {
            _pointDataCreatorProvider = pointDataCreatorProvider;
            string token = configuration["DOCKER_WATHCLOG_DB_TOKEN"];
            _dbClient = InfluxDBClientFactory.Create("http://influxdb:8086", token);
        }
        public void InsertData(Collectable collectable)
        {
            var point = BuildPointData(collectable);
            using var writeApi = _dbClient.GetWriteApi();
            writeApi.WritePoint(Bucket, Org, point);
        }

        public void InsertDataCollection(IEnumerable<Collectable> collection)
        {
            var points = collection.Select(BuildPointData).Where(p => p != null).ToList();
            using var writeApi = _dbClient.GetWriteApi();
            writeApi.WritePoints(Bucket, Org, points);
        }

        private PointData BuildPointData(Collectable collectable)
        {
            var pointDataCreator = _pointDataCreatorProvider.ProvidePointDataCreator(collectable.Type);
            return pointDataCreator?.CreatePointData(collectable);
        }
    }
}
