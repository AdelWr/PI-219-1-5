using BLL.Logic;
using DAL.Models;
using DAL.Repository;
using DAL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using BLL.DTO;
using System;

namespace Unit_Tests
{
    [TestClass]
    public class ResumeServiceTests
    {
        private IResumeService _resumeService;

        private Mock<UnitOfWork> _unitOfWork;

        private Mock<IGenericRepository<Resume>> _resumeRepository;

        private List<Resume> resumes;

        [TestInitialize]
        public void Initialize()
        {
            _resumeRepository = new Mock<IGenericRepository<Resume>>();
            var userRepository = new Mock<IGenericRepository<User>>();
            var vacansyRepository = new Mock<IGenericRepository<Vacansy>>();
            var context = new Mock<DatabaseContext>();

            _unitOfWork = new Mock<UnitOfWork>(context.Object,  userRepository.Object, _resumeRepository.Object, vacansyRepository.Object);

            _resumeService = new ResumeService(_unitOfWork.Object);
        }

        [TestMethod]
        public void GetResumes_ReturnsCorrectNumberOfResumes()
        {
            //Arrange
            resumes = new List<Resume>
            {
                new Resume(){ResumeTitile ="First"},
                 new Resume(){ResumeTitile ="Second"},
                  new Resume(){ResumeTitile ="Third"},

            };

            _resumeRepository.Setup(x => x.Get()).Returns(resumes);

            //Act
            var result = _resumeService.Get();

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(3, result.Count);
        }

        [TestMethod]
        public void AddResume_CalledCreateMethod()
        {
            //Arrange
            _resumeRepository.Setup(x => x.Create(It.IsAny<Resume>()));

            //Act
            _resumeService.AddResume(new ResumeDTO());

            //Assert
            _resumeRepository.Verify(x => x.Create(It.IsAny<Resume>()), Times.Once);
        }

        [TestMethod]
        public void UpdateResume_CalledUpdateMethod()
        {
            //Arrange
            _resumeRepository.Setup(x => x.GetOne(It.IsAny<Func<Resume, bool>>()))
                .Returns(new Resume() { });

            _resumeRepository.Setup(x => x.Update(It.IsAny<Resume>()));

            //Act
            _resumeService.UpdateResume(1, new ResumeDTO());

            //Assert
            _resumeRepository.Verify(x => x.Update(It.IsAny<Resume>()), Times.Once);
        }

        /// <summary>
        /// Tests that GetServiceByID() returns correct service
        /// </summary>
        [TestMethod]
        public void GetResumeByID_ReturnsCorrectResume()
        {
            //Arrange
            var expectedResume = new Resume() { ResumeId = 1, ResumeTitile = "Title" };
            _resumeRepository.Setup(x => x.GetOne(It.IsAny<Func<Resume, bool>>()))
               .Returns(expectedResume);

            //Act
            var result = _resumeService.GetResumeByID(1);

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(expectedResume.ResumeId, result.ResumeId);
            Assert.AreEqual(expectedResume.ResumeTitile, result.ResumeTitile);
        }

        [TestMethod]
        public void RemoveServiceByID_CallsRemove()
        {
            //Arrange
            var expectedService = new Resume() { ResumeId = 1, ResumeTitile = "Title" };
            _resumeRepository.Setup(x => x.Remove(expectedService));

            //Act
            _resumeService.RemoveResumeByID(1);

            //Assert
            _resumeRepository.Verify(x => x.Remove(It.IsAny<Resume>()), Times.Once);
        }

    }
}
