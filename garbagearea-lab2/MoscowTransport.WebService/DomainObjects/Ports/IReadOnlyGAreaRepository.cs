using System;

using System.Collections.Generic;

using System.Threading.Tasks;

using System.Linq.Expressions;

namespace TransferNode.DomainObjects.Ports

{

    public abstract class ReadOnlyTNodeRepositoryDecorator : IReadOnlyNodeRepository

    {

        private readonly IReadOnlyNodeRepository _TransferNodeRepository;

        public ReadOnlyTNodeRepositoryDecorator(IReadOnlyNodeRepository TNodeRepository)

        {

            _TransferNodeRepository = TNodeRepository;

        }

        public virtual async Task<IEnumerable<TransferNode>> GetAllNodes()

        {

            return await _TransferNodeRepository?.GetAllNodes();

        }

        public virtual async Task<TransferNode> GetNode(long id)

        {

            return await _TransferNodeRepository?.GetNode(id);

        }

        public virtual async Task<IEnumerable<TransferNode>> QueryNodes(ICriteria<TransferNode> criteria)

        {

            return await _TransferNodeRepository?.QueryNodes(criteria);

        }

    }

}

Листинг №4 – код