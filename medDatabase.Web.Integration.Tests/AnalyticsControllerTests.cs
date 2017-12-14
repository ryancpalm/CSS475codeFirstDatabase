using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using medDatabase.Web.Contexts;
using medDatabase.Web.Controllers;
using medDatabase.Web.Models;
using NUnit.Framework;

namespace medDatabase.Web.Integration.Tests
{
    [TestFixture]
    public class AnalyticsControllerTests
    {
        private MedicalDatabaseContext _dbContext;

        [OneTimeSetUp]
        public void BeforeAll()
        {
            _dbContext = new MedicalDatabaseContext();
        }

        [Test]
        public void StayPeriodForInvalidIllnessReturnsInvalidIllnessView()
        {
            // Arrange
            var analyticsController = new AnalyticsController();
            var stayPeriodInputViewModel = new StayPeriodInputViewModel("invalid-illness-name", null);

            // Act
            var view = analyticsController.StayPeriodVisualization(stayPeriodInputViewModel.IllnessName) as ViewResult;

            // Assert
            Assert.That(view, Is.Not.Null);
            Assert.That(view.ViewName, Is.EqualTo("InvalidIllness"));
        }

        [Test]
        public void StayPeriodForValidIllnessReturnsStayPeriodView()
        {
            // Arrange
            var analyticsController = new AnalyticsController();
            var stayPeriodInputViewModel = CreateStayPeriodInputViewModel();

            // Act
            var view = analyticsController.StayPeriodVisualization(stayPeriodInputViewModel.IllnessName) as ViewResult;

            // Assert
            Assert.That(view, Is.Not.Null);
            Assert.That(view.ViewName, Is.EqualTo("StayPeriodVisualization"));
        }

        [Test]
        public void StayPeriodForValidIllnessReturnsStayPeriodViewModel()
        {
            // Arrange
            var dbContext = new MedicalDatabaseContext();
            var analyticsController = new AnalyticsController();
            var stayPeriodInputViewModel = CreateStayPeriodInputViewModel();

            // Act
            var view = analyticsController.StayPeriodVisualization(stayPeriodInputViewModel.IllnessName) as ViewResult;

            // Assert
            Assert.That(view, Is.Not.Null);
            Assert.That(view.Model.GetType(), Is.EqualTo(typeof(StayPeriodVisualizationViewModel)));
            var viewModel = (StayPeriodVisualizationViewModel) view.Model;
            Assert.That(viewModel.Illness.Name, Is.EqualTo(stayPeriodInputViewModel.IllnessName));
            Assert.That(viewModel.StayPeriodsInDays, Is.Not.Null);
        }

        [Test]
        [Ignore("Deprecated")]
        public void DoctorPerformanceReturnsNonemptyStayPeriods()
        {
            // Arrange
            var analyticsController = new AnalyticsController();

            // Act
            var view = analyticsController.DoctorPerformance() as ViewResult;

            // Assert
            Assert.That(view, Is.Not.Null);
            Assert.That(view.Model, Is.Not.Null);
            var viewModel = (IEnumerable<DoctorPerformanceViewModel>) view.Model;
            viewModel = viewModel.ToList();
            foreach (var doctorPerformanceVm in viewModel)
            {
                Assert.That(doctorPerformanceVm.PatientStayPeriods, Is.Not.Empty);
            }
        }

        private StayPeriodInputViewModel CreateStayPeriodInputViewModel()
        {
            const string illnessName = "Salmonella pneumonia";
            var illnesses = _dbContext.Illnesses.ToList();
            var stayPeriodInputViewModel = new StayPeriodInputViewModel(illnessName, illnesses);
            return stayPeriodInputViewModel;
        }
    }
}
