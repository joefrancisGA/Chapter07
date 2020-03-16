using System;
using System.Threading.Tasks;
using BusinessAssociates.Contracts;
using BusinessAssociates.Domain;
using BusinessAssociates.Domain.ValueObjects;
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

                    InternalAssociate internalAssociate = new InternalAssociate(new AssociateId(cmd.DUNSNumber), cmd.LongName, cmd.ShortName, cmd.IsParent, cmd.InternalAssociateType, cmd.Status);

                    _repository.Add(internalAssociate);

                    // We don't need a unit of work pattern until we move to entity framework
                    //await _unitOfWork.Commit();
                    break;

                case InternalAssociates.V1.UpdateDUNSNumber cmd:
                    await HandleUpdate(cmd.Id, c => c.UpdateDUNSNumber(DUNSNumber.Create(cmd.DUNSNumber)));
                    break;

                case InternalAssociates.V1.UpdateInternalAssociateType cmd:
                    await HandleUpdate(cmd.Id, c => c.UpdateInternalAssociateType(cmd.InternalAssociateType));
                    break;

                case InternalAssociates.V1.UpdateLongName cmd:
                    await HandleUpdate(cmd.Id, c => c.UpdateLongName(LongName.Create(cmd.LongName)));
                    break;

                case InternalAssociates.V1.UpdateIsParent cmd:
                    await HandleUpdate(cmd.Id, c => c.UpdateIsParent(cmd.IsParent));
                    break;

                case InternalAssociates.V1.UpdateStatus cmd:
                    await HandleUpdate(cmd.Id, c => c.UpdateStatus(cmd.Status));
                    break;

                case InternalAssociates.V1.UpdateShortName cmd:
                    await HandleUpdate(cmd.Id, c => c.UpdateShortName(ShortName.Create(cmd.ShortName)));
                    break;

                default:
                    throw new InvalidOperationException($"Command type {command.GetType().FullName} is unknown");
            }
        }

#pragma warning disable 1998
        private async Task HandleUpdate(long internalAssociateId, Action<InternalAssociate> operation)
#pragma warning restore 1998
        {
            var internalAssociate = _repository.Load(internalAssociateId);

            if (internalAssociate == null)
                throw new InvalidOperationException($"Entity with id {internalAssociateId} cannot be found");

            operation(internalAssociate);

            //await _unitOfWork.Commit();
        }
    }
}