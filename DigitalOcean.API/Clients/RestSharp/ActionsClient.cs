using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using DOcean.API.Http;
using DOcean.API.Models.Responses;
using RestSharp;

namespace DOcean.API.Clients.RestSharp
{
    public class ActionsClient : IActionsClient
    {
        private readonly IConnection _connection;

        public ActionsClient(IConnection connection)
        {
            _connection = connection;
        }

        #region IActionsClient Members

        /// <inheritdoc />
        /// <summary>
        /// Retrieve all actions that have been executed on the current account.
        /// </summary>
        public Task<IReadOnlyList<Action>> GetAll(CancellationToken token = default)
        {
            return _connection.GetPaginated<Action>("actions", null, "actions", token);
        }

        /// <inheritdoc />
        /// <summary>
        /// Retrieve an existing Action
        /// </summary>
        public Task<Action> Get(int actionId, CancellationToken token = default)
        {
            var parameters = new List<Parameter>
            {
                new Parameter {Name = "id", Value = actionId, Type = ParameterType.UrlSegment}
            };
            return _connection.ExecuteRequest<Action>("actions/{id}", parameters, null, "action", token: token);
        }

        #endregion
    }
}