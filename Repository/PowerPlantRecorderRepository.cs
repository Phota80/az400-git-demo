using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using PowerPlantSampleApi.Models;
using Dapper;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Collections.Generic;
using System;

namespace PowerPlantSampleApi.Repository
{
    public class PowerPlantRecorderRepository : IPowerPlantRecorderRepository
    {
        private readonly IConfiguration _config;
        public PowerPlantRecorderRepository(IConfiguration config)
        {
            _config = config;
        }

        public IDbConnection connection => new SqlConnection(_config.GetConnectionString("mySqlConnection"));
        public async Task<List<MeasurementInfo>> GetInstrumentMeasurements()
        {
            try
            {
                using (IDbConnection con = connection)
                {
                    string Query = "USP_GetInstrumentMeasurements";
                    con.Open();
                    //DynamicParameters param = new DynamicParameters();
                    //param.Add("@ACTION", "ALL");
                    var result = await con.QueryAsync<MeasurementInfo>(Query, commandType: CommandType.StoredProcedure);
                    return result.ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<MeasurementInfo> GetInstrumentMeasurementById(int measurementId)
        {
            try
            {
                using (IDbConnection con = connection)
                {
                    string Query = "USP_GetInstrumentMeasurementById";
                    con.Open();
                    DynamicParameters param = new DynamicParameters();                    
                    param.Add("@MEASUREMENTID", measurementId);

                    var result = await con.QueryAsync<MeasurementInfo>(Query, param, commandType: CommandType.StoredProcedure);
                    return result.FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public string InsertInstumentMeasument(MeasurementInfo recDetail)
        {
            try
            {
                using (IDbConnection con = connection)
                {
                    string Query = "USP_InsertInstumentMeasument";
                    con.Open();
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@Speed", recDetail.Speed);
                    param.Add("@Vibration", recDetail.Vibration);
                    param.Add("@Acceleration", recDetail.Acceleration);
                    param.Add("@Temperature", recDetail.Temperature);
                    param.Add("@State", recDetail.State);
                    param.Add("@RecordedBy", recDetail.RecordedBy);
                    param.Add("@RecordedByEmail", recDetail.RecordedByEmail);
                    var rowAffected = con.Execute(Query, param, commandType: CommandType.StoredProcedure);
                    if (rowAffected == 0)
                    {
                        return "No records were Inserted";
                    }

                    return "";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
