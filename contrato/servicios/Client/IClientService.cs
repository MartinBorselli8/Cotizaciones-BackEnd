using contrato.servicios.Client.Request;
using contrato.servicios.Client.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace contrato.servicios.Client
{
    public interface IClientService
    {
        Task <GetClientResponse> getClients(GetClientRequest request); 
        Task <DeleteClientResponse> deleteClients(DeleteClientRequest request);
        Task<AddClientResponse> addClients(AddClientRequest request);
        Task<PutClientResponse> putClient(PutClientRequest request);

    }
}
