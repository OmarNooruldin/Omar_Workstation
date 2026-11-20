using HospitalApplication.Application.Dtos;

namespace HospitalApplication.Service.Base
{
    public interface IBillingService
    {
        IEnumerable<BillingListDto> GetAllBills();
        IEnumerable<AppointmentListDto> GetAllAppointments();
        void CreateBill(BillingCreateDto billing);
        void UpdateBill(BillingListDto billing);
        void DeleteBill(int  Id);

        BillingListDto GetBillById(int Id);

        void SaveBill();
    }
}
