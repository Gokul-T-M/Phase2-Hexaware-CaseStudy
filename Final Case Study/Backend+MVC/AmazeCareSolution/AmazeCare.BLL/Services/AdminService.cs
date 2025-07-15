using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AmazeCare.BLL.Interfaces;
using AmazeCare.DAL.Entities;
using AmazeCare.DAL.Interfaces;

namespace AmazeCare.BLL.Services
{
    public class AdminService : IAdminService
    {
        private readonly IAdminRepository _adminRepository;

        public AdminService(IAdminRepository adminRepository)
        {
            _adminRepository = adminRepository;
        }

        public async Task<IEnumerable<Admin>> GetAllAdminsAsync()
        {
            return await _adminRepository.GetAllAsync();
        }

        public async Task<Admin?> GetAdminByIdAsync(int id)
        {
            return await _adminRepository.GetByIdAsync(id);
        }

        public async Task AddAdminAsync(Admin admin)
        {
            await _adminRepository.AddAsync(admin);
            await _adminRepository.SaveAsync();
        }

        public async Task UpdateAdminAsync(Admin admin)
        {
            _adminRepository.Update(admin);
            await _adminRepository.SaveAsync();
        }

        public async Task DeleteAdminAsync(int id)
        {
            var admin = await _adminRepository.GetByIdAsync(id);
            if (admin != null)
            {
                _adminRepository.Delete(admin);
                await _adminRepository.SaveAsync();
            }
        }
    }
}
