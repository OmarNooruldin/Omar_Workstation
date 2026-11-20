using HospitalApplication.Application.Abstractions.Repositories.Base;
using HospitalApplication.Application.Dtos;
using HospitalApplication.Domain.Models;
using HospitalApplication.Service.Base;

namespace HospitalApplication.Infrastructure.Persistences.Services
{
    public class BillingService : IBillingService
    {
        private readonly IUnitOfWork _unitOfWork;

        public BillingService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void CreateBill(BillingCreateDto billing)
        {
            var bill = new Billing
            {
                TotalAmount = billing.TotalAmount,
                InsuranceProvider = billing?.InsuranceProvider,
                AppointmentId = billing.AppointmentId,
                PatientId = billing?.PatientId,
            };
            _unitOfWork.Billings.Add(bill);
        }

        public void DeleteBill(int Id)
        {
            var bill = _unitOfWork.Billings.GetById(Id);
            if (bill == null)
            {
                throw new KeyNotFoundException("Not Found");
            }
            _unitOfWork.Billings.Delete(bill);
        }

        public IEnumerable<AppointmentListDto> GetAllAppointments()
        {
            var appointments = _unitOfWork.Appointments.GetAll();
            return appointments.Select(a => new AppointmentListDto
            {
                Id = a.Id,
                AppointmentDate = a.AppointmentDate,
                ReasonForVisit = a.ReasonForVisit,
                Status = a.Status,
            });
        }

        public IEnumerable<BillingListDto> GetAllBills()
        {
            var bill = _unitOfWork.Billings.GetAll();
            return bill.Select(b => new BillingListDto
            {
                Id = b.Id,
                TotalAmount = b.TotalAmount,
                InsuranceProvider = b?.InsuranceProvider,
                AppointmentId = b.AppointmentId,
                PatientId = b?.PatientId,
            });
        }

        public BillingListDto GetBillById(int Id)
        {
            var bill = _unitOfWork.Billings.GetById(Id);
            if (bill == null)
            {
                throw new KeyNotFoundException("Not Found");
            }
            return new BillingListDto
            {
                Id = bill.Id,
                TotalAmount = bill.TotalAmount,
                InsuranceProvider = bill?.InsuranceProvider,
                AppointmentId = bill.AppointmentId,
                PatientId= bill?.PatientId,
            };
        }

        public void SaveBill()
        {
            _unitOfWork.Save();
        }

        public void UpdateBill(BillingListDto billing)
        {
            var bill = _unitOfWork.Billings.GetById(billing.Id);    
            if (bill == null)
            {
                throw new KeyNotFoundException("Not Found");
            }
            bill.TotalAmount = billing.TotalAmount;
            bill.InsuranceProvider = billing?.InsuranceProvider;
            bill.AppointmentId = billing.AppointmentId;
            bill.PatientId = billing?.PatientId;

            _unitOfWork.Billings.Update(bill);
        }
    }
}
