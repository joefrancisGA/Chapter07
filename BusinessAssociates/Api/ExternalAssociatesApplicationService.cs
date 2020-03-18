using System;
using System.Threading.Tasks;
using BusinessAssociates.Contracts;
using BusinessAssociates.Domain;
using BusinessAssociates.Domain.Repositories;
using BusinessAssociates.Domain.ValueObjects;
using BusinessAssociates.Framework;

namespace BusinessAssociates.Api
{
    // The application service is only used by the command API at the moment, but it can be used 
    public class ExternalAssociatesApplicationService : IApplicationService
    {
        private readonly IExternalAssociateRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public ExternalAssociatesApplicationService(IExternalAssociateRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(object command)
        {
            switch (command)
            {

                // TO DO:  Are we throwing an event here?
                case ExternalAssociates.V1.Create cmd:

                    if (_repository.Exists(cmd.DUNSNumber))
                        throw new InvalidOperationException($"Entity with DUNSNumber {cmd.DUNSNumber} already exists");

                    ExternalAssociate externalAssociate = new ExternalAssociate(new AssociateId(cmd.DUNSNumber), cmd.LongName, cmd.ShortName, cmd.IsParent, cmd.ExternalAssociateType, cmd.Status);

                    _repository.Add(externalAssociate);

                    // We don't need a unit of work pattern until we move to entity framework
                    //await _unitOfWork.Commit();
                    break;

                case ExternalAssociates.V1.UpdateDUNSNumber cmd:
                    _repository.UpdateDUNSNumber(HandleUpdate(cmd.Id, ia => ia.UpdateDUNSNumber(DUNSNumber.Create(cmd.DUNSNumber))).Result);
                    break;

                case ExternalAssociates.V1.UpdateExternalAssociateType cmd:
                    _repository.UpdateInternalAssociateType(HandleUpdate(cmd.Id, ia => ia.UpdateExternalAssociateType(cmd.ExternalAssociateType)).Result);
                    break;

                case ExternalAssociates.V1.UpdateLongName cmd:
                    _repository.UpdateLongName(HandleUpdate(cmd.Id, ia => ia.UpdateLongName(LongName.Create(cmd.LongName))).Result);
                    break;

                case ExternalAssociates.V1.UpdateIsParent cmd:
                    _repository.UpdateIsParent(HandleUpdate(cmd.Id, ia => ia.UpdateIsParent(cmd.IsParent)).Result);
                    break;

                case ExternalAssociates.V1.UpdateStatus cmd:
                    _repository.UpdateStatus(HandleUpdate(cmd.Id, ia => ia.UpdateStatus(cmd.Status)).Result);
                    break;

                case ExternalAssociates.V1.UpdateShortName cmd:
                    _repository.UpdateShortName(HandleUpdate(cmd.Id, ia => ia.UpdateShortName(ShortName.Create(cmd.ShortName))).Result);
                    break;

                default:
                    throw new InvalidOperationException($"Command type {command.GetType().FullName} is unknown");
            }
        }

#pragma warning disable 1998
        private async Task<ExternalAssociate> HandleUpdate(int externalAssociateId, Action<ExternalAssociate> operation)
#pragma warning restore 1998
        {
            ExternalAssociate externalAssociate = _repository.Load(new AssociateId(externalAssociateId));

            if (externalAssociate == null)
                throw new InvalidOperationException($"Entity with id {externalAssociateId} cannot be found");

            operation(externalAssociate);

            return externalAssociate;

            //await _unitOfWork.Commit();
        }
    }
}