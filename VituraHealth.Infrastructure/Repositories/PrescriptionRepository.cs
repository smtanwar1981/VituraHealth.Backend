using Microsoft.EntityFrameworkCore;
using VituraHealth.Domain.Entities;
using VituraHealth.Domain.Repositories;
using VituraHealth.Infrastructure.Data;

namespace VituraHealth.Infrastructure.Repositories;

public class PrescriptionRepository(VituraHealthDbContext _context) : IPrescriptionRepository
{
    /// <inheritdoc />
    public async Task AddPrescriptionAsync(Prescription prescription)
    {
        await _context.Prescriptions.AddAsync(prescription);
        await _context.SaveChangesAsync();
    }

    /// <inheritdoc />
    public async Task<IEnumerable<Prescription>> GetAllPrescriptionsAsync()
    {
        return await _context.Prescriptions.AsNoTracking().ToListAsync();
    }
}
