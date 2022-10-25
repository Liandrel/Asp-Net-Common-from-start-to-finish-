using Dapper;
using DataLibrary.Db;
using DataLibrary.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.Data
{
    public class OrderData : IOrderData
    {

        private readonly IDataAccess _dataAccess;
        private readonly IConfiguration _config;
        private readonly string _sqlConnectionName;

        public OrderData(IDataAccess dataAccess, IConfiguration config)
        {
            _dataAccess = dataAccess;
            _config = config;
            _sqlConnectionName = _config.GetValue<string>("ConnectionStringName");
        }

        public async Task<int> CreateOrder(OrderModel order)
        {
            DynamicParameters p = new();

            p.Add("OrderName", order.OrderName);
            p.Add("OrderDate", order.OrderDate);
            p.Add("FoodId", order.FoodId);
            p.Add("Quantity", order.Quantity);
            p.Add("Total", order.Total);
            p.Add("Id", DbType.Int32, direction: ParameterDirection.Output);

            await _dataAccess.SaveData("spOrders_Insert", p, _sqlConnectionName);

            return p.Get<int>("Id");
        }

        public async Task<OrderModel> GetOrderById(int orderId)
        {
            var recs = await _dataAccess.LoadData<OrderModel, dynamic>("spOrders_GetById", new { Id = orderId },
                                                                       _sqlConnectionName);

            return recs.FirstOrDefault();
        }

        public Task<int> UpdateOrderName(int orderId, string newOrderName)
        {
            return _dataAccess.SaveData("spOrders_UpdateName", new { Id = orderId, OrderName = newOrderName },
                                        _sqlConnectionName);
        }

        public Task<int> DeleteOrder(int orderId)
        {
            return _dataAccess.SaveData("spOrders_Delete", new { Id = orderId }, _sqlConnectionName);
        }
    }
}
