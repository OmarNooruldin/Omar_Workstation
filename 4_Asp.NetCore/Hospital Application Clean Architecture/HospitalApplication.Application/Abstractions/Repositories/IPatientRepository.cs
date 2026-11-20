using HospitalApplication.Application.Abstractions.Repositories.Base;
using HospitalApplication.Domain.Models;

namespace HospitalApplication.Application.Abstractions.Repositories
{
    public interface IPatientRepository : IRepository<Patient>
    {
    }
}
