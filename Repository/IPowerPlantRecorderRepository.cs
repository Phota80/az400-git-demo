using PowerPlantSampleApi.Models;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace PowerPlantSampleApi.Repository
{
    public interface IPowerPlantRecorderRepository
    {
        IDbConnection connection { get; }

        Task<List<MeasurementInfo>> GetInstrumentMeasurements();
        string InsertInstumentMeasument(MeasurementInfo recDetail);
        Task<MeasurementInfo> GetInstrumentMeasurementById(int measurementId);
    }
}