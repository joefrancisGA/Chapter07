using System;
using System.Threading.Tasks;
using BusinessAssociates.Domain;
using BusinessAssociates.Domain.Repositories;
using BusinessAssociates.Domain.ValueObjects;
using BusinessAssociates.Framework;
using EGMS.BusinessAssociates.API.Contracts;

namespace EGMS.BusinessAssociates.API.Api
{
    // The application service is only used by the command API at the moment, but it can be used 
    public class AssociatesApplicationService : IApplicationService
    {
        private readonly IAssociateRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public AssociatesApplicationService(IAssociateRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

#pragma warning disable 1998
        public async Task Handle(object command)
#pragma warning restore 1998
        {
            switch (command)
            {
                // TO DO:  Are we throwing an event here?
                case Associates.V1.Create cmd:

                    if (_repository.Exists(cmd.DUNSNumber))
                        throw new InvalidOperationException($"Entity with DUNSNumber {cmd.DUNSNumber} already exists");

                    Associate associate = new Associate(new AssociateId(cmd.DUNSNumber), cmd.LongName, cmd.ShortName, cmd.IsParent, cmd.AssociateType, cmd.Status);

                    _repository.Add(associate);

                    // We don't need a unit of work pattern until we move to entity framework
                    //await _unitOfWork.Commit();
                    break;


                case Associates.V1.Delete cmd:
                    _repository.Delete(new Associate(new AssociateId(cmd.Id)));
                    break;


                case Associates.V1.UpdateDUNSNumber cmd:
                    _repository.UpdateDUNSNumber(HandleUpdate(cmd.Id, ia => ia.UpdateDUNSNumber(DUNSNumber.Create(cmd.DUNSNumber))).Result);
                    break;

                case Associates.V1.UpdateAssociateType cmd:
                    _repository.UpdateAssociateType(HandleUpdate(cmd.Id, ia => ia.UpdateAssociateType(cmd.AssociateType)).Result);
                    break;

                case Associates.V1.UpdateLongName cmd:
                    _repository.UpdateLongName(HandleUpdate(cmd.Id, ia => ia.UpdateLongName(LongName.Create(cmd.LongName))).Result);
                    break;

                case Associates.V1.UpdateIsParent cmd:
                    _repository.UpdateIsParent(HandleUpdate(cmd.Id, ia => ia.UpdateIsParent(cmd.IsParent)).Result);
                    break;

                case Associates.V1.UpdateStatus cmd:
                    _repository.UpdateStatus(HandleUpdate(cmd.Id, ia => ia.UpdateStatus(cmd.Status)).Result);
                    break;

                case Associates.V1.UpdateShortName cmd:
                    _repository.UpdateShortName(HandleUpdate(cmd.Id, ia => ia.UpdateShortName(ShortName.Create(cmd.ShortName))).Result);
                    break;

                default:
                    throw new InvalidOperationException($"Command type {command.GetType().FullName} is unknown");
            }
        }

#pragma warning disable 1998
        private async Task<Associate> HandleUpdate(int associateId, Action<Associate> operation)
#pragma warning restore 1998
        {
            Associate associate = _repository.Load(associateId);

            if (associate == null)
                throw new InvalidOperationException($"Entity with id {associateId} cannot be found");

            operation(associate);

            return associate;

            //await _unitOfWork.Commit();
        }
    }
}