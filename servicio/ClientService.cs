using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using dominio.infraestructura;
using contrato.entidades;
using System.Linq;
using System.Linq.Expressions;
using dominio.entidades;
using contrato.servicios.Client;
using contrato.servicios.Client.Response;
using contrato.servicios.Client.Request;
using dominio;
using datos.Infraestructura;



/* Pasos: 1) Crear predicado(filtro) 2) Conectarse BD 3) Mapear de dominio a contrato 4) Devolver 
 * */
namespace servicio
{
    public class ClientService : IClientService
    {
        private readonly  IRepositorio<Clients> _RepositorioClients;

        public ClientService(IRepositorio<Clients> RepositorioClients)
        {
            _RepositorioClients = RepositorioClients;
        }

        public async Task<DeleteClientResponse> deleteClients(DeleteClientRequest request)
        {
            var response = new DeleteClientResponse();

            var ClientToDelete = await _RepositorioClients.Buscar(c=> c.Id == request.Id);

            await _RepositorioClients.Eliminar(ClientToDelete[0]);
            response.fueEliminado = true;

            return response;
        }

        public async Task<AddClientResponse> addClients(AddClientRequest request)
        {
            var response= new AddClientResponse();

            var newClient = new dominio.entidades.Clients
            {
                Name = request.Name,
                LastName = request.LastName,
                Dni = request.Dni,
                Phone = request.Phone,
                Email = request.Email
            };

            await _RepositorioClients.Crear(newClient);

            response.fueCreado = true;

            return response;
        }

        public async Task<GetClientResponse> getClients(GetClientRequest request)
        {
            var response= new GetClientResponse();

            var predicate = CrearPredicado.Verdadero<dominio.entidades.Clients>();

            if (request.Name != null) predicate = predicate.Y(c => c.Name == request.Name);
            if (request.LastName != null) predicate = predicate.Y(c => c.LastName == request.LastName);
            if (request.Dni > 0) predicate = predicate.Y(c => c.Dni == request.Dni);

            var repositoryResponse = await _RepositorioClients.Buscar(predicate);

            response.Clients = repositoryResponse.Select(c => new contrato.entidades.Client
            {
                Id = c.Id,
                Name = c.Name,
                LastName = c.LastName,
                Dni = c.Dni,
                Phone = c.Phone,
                Email = c.Email

            }).ToList();

            return response;
        }

        public async Task<PutClientResponse> putClient(PutClientRequest request)
        {
            var response = new PutClientResponse();

            var ClientToModify = await _RepositorioClients.Buscar(c => c.Id == request.Id);

            if (request.Dni > 0) ClientToModify[0].Dni = request.Dni;
            if (request.Name != null)  ClientToModify[0].Name = request.Name;
            if (request.LastName != null)  ClientToModify[0].LastName = request.LastName;
            if (request.Phone != null)  ClientToModify[0].Phone = request.Phone;
            if (request.Email != null)  ClientToModify[0].Email = request.Email;

            await _RepositorioClients.Actualizar(ClientToModify[0]);

            response.fueModificado = true;

            return response;
        }
    }
}
