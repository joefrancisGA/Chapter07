using System;
using System.Threading.Tasks;
using BusinessAssociates.Contracts;
using BusinessAssociates.Domain;
using BusinessAssociates.Framework;

namespace BusinessAssociates.Api
{
    // The application service is only used by the command API at the moment, but it can be used 
    public class InternalAssociatesApplicationService : IApplicationService
    {
        private readonly IInternalAssociateRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public InternalAssociatesApplicationService(IInternalAssociateRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(object command)
        {
            switch (command)
            {
                case InternalAssociates.V1.Create cmd:
                    if (_repository.Exists(cmd.DUNSNumber))
                        throw new InvalidOperationException($"Entity with DUNSNumber {cmd.DUNSNumber} already exists");

                    var internalAssociate = new InternalAssociate(new AssociateId(cmd.DUNSNumber), cmd.LongName, cmd.ShortName, cmd.IsParent, cmd.InternalAssociateType, cmd.Status);

                    _repository.Add(internalAssociate);
                    //await _unitOfWork.Commit();
                    break;

                case InternalAssociates.V1.UpdateText cmd:
                    await HandleUpdate(cmd.Id, c => c.UpdateText(InternalAssociateText.FromString(cmd.Text)));
                    break;

                default:
                    throw new InvalidOperationException($"Command type {command.GetType().FullName} is unknown");
            }
        }

        private async Task HandleUpdate(long internalAssociateId, Action<InternalAssociate> operation)
        {
            var internalAssociate = _repository.Load(internalAssociateId);
            if (internalAssociate == null)
                throw new InvalidOperationException($"Entity with id {internalAssociateId} cannot be found");

            operation(internalAssociate);

            await _unitOfWork.Commit();
        }
    }
}