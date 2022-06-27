using Educational_Api.Controllers;
using Educational_Api.Models;
using Educational_Api.Models.Context;
using Moq;
using Xunit;

namespace Educational_Api_Tests.Controllers
{
	public class StudentsControllerTests
	{
		private MockRepository mockRepository;

		private Mock<EducationalContext> mockEducationalContext;

		public StudentsControllerTests()
		{
			this.mockRepository = new MockRepository(MockBehavior.Strict);

			this.mockEducationalContext = this.mockRepository.Create<EducationalContext>();
		}

		private StudentsController CreateStudentsController()
		{
			return new StudentsController(
				this.mockEducationalContext.Object);
		}

		[Fact]
		public async Task GetStudents_StateUnderTest_ExpectedBehavior()
		{
			// Arrange
			var studentsController = this.CreateStudentsController();

			// Act
			var result = await studentsController.GetStudents();

			// Assert
			Assert.True(false);
			this.mockRepository.VerifyAll();
		}

		[Fact]
		public async Task GetStudent_StateUnderTest_ExpectedBehavior()
		{
			// Arrange
			var studentsController = this.CreateStudentsController();
			int id = 0;

			// Act
			var result = await studentsController.GetStudent(
				id);

			// Assert
			Assert.True(false);
			this.mockRepository.VerifyAll();
		}

		[Fact]
		public async Task PutStudent_StateUnderTest_ExpectedBehavior()
		{
			// Arrange
			var studentsController = this.CreateStudentsController();
			int id = 0;
			Student student = null;

			// Act
			var result = await studentsController.PutStudent(
				id,
				student);

			// Assert
			Assert.True(false);
			this.mockRepository.VerifyAll();
		}

		[Fact]
		public async Task PostStudent_StateUnderTest_ExpectedBehavior()
		{
			// Arrange
			var studentsController = this.CreateStudentsController();
			Student student = null;

			// Act
			var result = await studentsController.PostStudent(
				student);

			// Assert
			Assert.True(false);
			this.mockRepository.VerifyAll();
		}

		[Fact]
		public async Task DeleteStudent_StateUnderTest_ExpectedBehavior()
		{
			// Arrange
			var studentsController = this.CreateStudentsController();
			int id = 0;

			// Act
			var result = await studentsController.DeleteStudent(
				id);

			// Assert
			Assert.True(false);
			this.mockRepository.VerifyAll();
		}
	}
}
