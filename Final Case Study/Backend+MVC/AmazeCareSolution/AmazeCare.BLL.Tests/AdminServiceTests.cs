using NUnit.Framework;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using AmazeCare.BLL.Services;
using AmazeCare.DAL.Entities;
using AmazeCare.DAL.Interfaces;

namespace AmazeCare.BLL.Tests
{
    [TestFixture]
    public class AdminServiceTests
    {
        private Mock<IAdminRepository> _adminRepositoryMock;
        private AdminService _adminService;

        [SetUp]
        public void Setup()
        {
            _adminRepositoryMock = new Mock<IAdminRepository>();
            _adminService = new AdminService(_adminRepositoryMock.Object);
        }

        // Test methods will go here
        [Test]
        public async Task GetAllAdminsAsync_ReturnsAllAdmins()
        {
            // Arrange
            var admins = new List<Admin>
            {
               new Admin { AdminId = 1, Name = "Alice" },
               new Admin { AdminId = 2, Name = "Bob" }
            };
            _adminRepositoryMock.Setup(repo => repo.GetAllAsync()).ReturnsAsync(admins);

            // Act
            var result = await _adminService.GetAllAdminsAsync();

            // Assert
            Assert.That(result, Is.EqualTo(admins));
            _adminRepositoryMock.Verify(repo => repo.GetAllAsync(), Times.Once);
        }

        [Test]
        public async Task AddAdminAsync_CallsAddAndSave()
        {
            // Arrange
            var admin = new Admin { AdminId = 3, Name = "Charlie" };

            // Act
            await _adminService.AddAdminAsync(admin);

            // Assert
            _adminRepositoryMock.Verify(repo => repo.AddAsync(admin), Times.Once);
            _adminRepositoryMock.Verify(repo => repo.SaveAsync(), Times.Once);
        }


        [Test]
        public async Task DeleteAdminAsync_AdminExists_DeletesAndSaves()
        {
            // Arrange
            var admin = new Admin { AdminId = 4, Name = "David" };
            _adminRepositoryMock.Setup(repo => repo.GetByIdAsync(4)).ReturnsAsync(admin);

            // Act
            await _adminService.DeleteAdminAsync(4);

            // Assert
            _adminRepositoryMock.Verify(repo => repo.Delete(admin), Times.Once);
            _adminRepositoryMock.Verify(repo => repo.SaveAsync(), Times.Once);
        }

        [Test]
        public async Task DeleteAdminAsync_AdminDoesNotExist_DoesNothing()
        {
            // Arrange
            _adminRepositoryMock.Setup(repo => repo.GetByIdAsync(5)).ReturnsAsync((Admin)null);

            // Act
            await _adminService.DeleteAdminAsync(5);

            // Assert
            _adminRepositoryMock.Verify(repo => repo.Delete(It.IsAny<Admin>()), Times.Never);
            _adminRepositoryMock.Verify(repo => repo.SaveAsync(), Times.Never);
        }


        [Test]
        public async Task UpdateAdminAsync_CallsUpdateAndSave()
        {
            // Arrange
            var admin = new Admin { AdminId = 1, Name = "Updated Admin" };

            // Act
            await _adminService.UpdateAdminAsync(admin);

            // Assert
            _adminRepositoryMock.Verify(repo => repo.Update(admin), Times.Once);
            _adminRepositoryMock.Verify(repo => repo.SaveAsync(), Times.Once);
        }


        [Test]
        public async Task GetAdminByIdAsync_ReturnsAdmin_WhenAdminExists()
        {
            // Arrange
            var admin = new Admin { AdminId = 1, Name = "Test Admin" };
            _adminRepositoryMock.Setup(repo => repo.GetByIdAsync(1)).ReturnsAsync(admin);

            // Act
            var result = await _adminService.GetAdminByIdAsync(1);

            // Assert
            Assert.That(result, Is.EqualTo(admin));
            _adminRepositoryMock.Verify(repo => repo.GetByIdAsync(1), Times.Once);
        }


        [Test]
        public async Task GetAdminByIdAsync_ReturnsNull_WhenAdminDoesNotExist()
        {
            // Arrange
            _adminRepositoryMock.Setup(repo => repo.GetByIdAsync(99)).ReturnsAsync((Admin?)null);

            // Act
            var result = await _adminService.GetAdminByIdAsync(99);

            // Assert
            Assert.That(result, Is.Null);
            _adminRepositoryMock.Verify(repo => repo.GetByIdAsync(99), Times.Once);
        }



    }
}
