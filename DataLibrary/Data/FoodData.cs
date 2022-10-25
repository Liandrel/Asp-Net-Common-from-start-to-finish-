using DataLibrary.Db;
using DataLibrary.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.Data
{
    public class FoodData : IFoodData
    {
        private readonly IDataAccess _dataAccess;
        private readonly IConfiguration _config;
        private readonly string _sqlConnectionName;

        public FoodData(IDataAccess dataAccess, IConfiguration config)
        {
            _dataAccess = dataAccess;
            _config = config;
            _sqlConnectionName = _config.GetValue<string>("ConnectionStringName");
        }

        public Task<List<FoodModel>> GetFood()
        {
            return _dataAccess.LoadData<FoodModel, dynamic>("spFood_GetAll", new { }, _sqlConnectionName);
        }
    }
}
