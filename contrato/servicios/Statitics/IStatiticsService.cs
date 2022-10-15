using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace contrato.servicios.Statitics
{
    public interface IStatiticsService
    {
        Task<GetDataForStatiticsResponse> GetDataForStatitics();
    }
}
