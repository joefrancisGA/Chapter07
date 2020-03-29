using System;
using System.Threading.Tasks;
using AutoMapper;
using EGMS.BusinessAssociates.Domain;
using EGMS.BusinessAssociates.Domain.Enums;
using EGMS.BusinessAssociates.Domain.Repositories;
using EGMS.BusinessAssociates.Domain.ValueObjects;
using EGMS.BusinessAssociates.Framework;
using EGMS.BusinessAssociates.Query.ReadModels;


namespace EGMS.BusinessAssociates.Command
{
    // The application service is only used by the command API at the moment, but it can be used 
    public class AssociatesApplicationService : IApplicationService
    {
        private readonly IAssociateRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AssociatesApplicationService(IAssociateRepository repository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

#pragma warning disable 1998
        public async Task<object> Handle(object command)
#pragma warning restore 1998
        {
            object retVal = null;

            switch (command)
            {
                // TO DO:  Are we throwing an event here?
                case Commands.V1.Associate.Create cmd:

                    if (_repository.Exists(cmd.DUNSNumber))
                        throw new InvalidOperationException($"Entity with DUNSNumber {cmd.DUNSNumber} already exists");

                    Associate associate = new Associate(cmd.DUNSNumber, cmd.LongName, cmd.ShortName, cmd.IsParent, cmd.AssociateType, cmd.Status);

                    _repository.Add(associate);
                    await _unitOfWork.Commit();
                    break;


                case Commands.V1.Associate.UpdateDUNSNumber cmd:
                    
                    HandleUpdate(cmd.Id, ia => ia.UpdateDUNSNumber(DUNSNumber.Create(cmd.DUNSNumber)));
                    await _unitOfWork.Commit();
                    break;

                case Commands.V1.Associate.UpdateAssociateType cmd:
                    HandleUpdate(cmd.Id, ia => ia.UpdateAssociateType(cmd.AssociateType));
                    await _unitOfWork.Commit();
                    break;

                case Commands.V1.Associate.UpdateLongName cmd:
                    HandleUpdate(cmd.Id, ia => ia.UpdateLongName(LongName.Create(cmd.LongName)));
                    await _unitOfWork.Commit();
                    break;

                case Commands.V1.Associate.UpdateIsParent cmd:
                    HandleUpdate(cmd.Id, ia => ia.UpdateIsParent(cmd.IsParent));
                    await _unitOfWork.Commit();
                    break;

                case Commands.V1.Associate.UpdateStatus cmd:
                    HandleUpdate(cmd.Id, ia => ia.UpdateStatus(cmd.Status));
                    await _unitOfWork.Commit();
                    break;

                case Commands.V1.Associate.UpdateShortName cmd:
                    HandleUpdate(cmd.Id, ia => ia.UpdateShortName(ShortName.Create(cmd.ShortName)));
                    await _unitOfWork.Commit();
                    break;

                case Commands.V1.OperatingContext.Create cmd:
                    try
                    {
                        retVal = await HandleAddOperatingContext(cmd);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                        throw;
                    }

                    break;

                default:
                    throw new InvalidOperationException($"Commands type {command.GetType().FullName} is unknown");
            }

            return retVal;
        }

#pragma warning disable 1998
        private async void HandleUpdate(int associateId, Action<Associate> operation)
#pragma warning restore 1998
        {
            Associate associate = _repository.Load(associateId).Result;

            if (associate == null)
                throw new InvalidOperationException($"Entity with id {associateId} cannot be found");

            operation(associate);

            await _unitOfWork.Commit();
        }

        private async Task<OperatingContextRM> HandleAddOperatingContext(Commands.V1.OperatingContext.Create cmd)
        {
            Associate associate = await _repository.Load(AssociateId.FromInt(cmd.AssociateId));

            if (associate == null)
                throw new InvalidOperationException($"Associate with id {cmd.AssociateId} cannot be found");

            OperatingContext operatingContext = new OperatingContext((OperatingContextType)cmd.OperatingContextType, cmd.FacilityId,
                cmd.ThirdPartySupplierId, (AssociateType)cmd.ActingBATypeID, cmd.CertificationId, cmd.IsDeactivating,
                cmd.LegacyId, cmd.PrimaryAddressId, cmd.PrimaryEmailId, cmd.PrimaryPhoneId,
                cmd.ProviderType, cmd.StartDate, (Status)cmd.Status);

            _repository.AddOperatingContext(associate, operatingContext);

            associate.OperatingContexts.Add(operatingContext);

            return _mapper.Map<OperatingContextRM>(operatingContext);
        }

        private async Task<AssociateRM> HandleCreate(Commands.V1.Associate.Create cmd)
        {
            var associate = Associate.Create(
                ShortName.FromString(cmd.ShortName),
                LongName.FromString(cmd.LongName), cmd.AssociateType, cmd.IsParent, cmd.Status);

            _repository.Add(associate);
            await _unitOfWork.Commit();

            // TODO:  Dispatch Events.

            return _mapper.Map<AssociateRM>(associate);
        }

    }
}