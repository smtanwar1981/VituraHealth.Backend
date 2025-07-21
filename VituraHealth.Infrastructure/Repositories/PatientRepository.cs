using Microsoft.EntityFrameworkCore;
using VituraHealth.Domain.Entities;
using VituraHealth.Domain.Repositories;
using VituraHealth.Infrastructure.Data;

namespace VituraHealth.Infrastructure.Repositories;

public class PatientRepository(VituraHealthDbContext _context) : IPatientRespository
{
    /// <inheritdoc />
    public async Task<IEnumerable<Patient>> GetAllPatientsAsync()
    {
        return await _context.Patients.AsNoTracking().ToListAsync();
    }
}
