using Educational_Api.Controllers;
using Educational_Api.Models.Context;
using Educational_Api.Models.UI;
using Moq;
using Xunit;

namespace Educational_Api_Tests.Controllers
{
	public class ClassesControllerTests
	{
		private MockRepository mockRepository;

		private Mock<EducationalContext> mockEducationalContext;

		public ClassesControllerTests()
		{
			this.mockRepository = new MockRepository(MockBehavior.Strict);

			this.mockEducationalContext = this.mockRepository.Create<EducationalContext>();
		}

		private ClassesController CreateClassesController()
		{
			return new ClassesController(
				this.mockEducationalContext.Object);
		}

		[Fact]
		public async Task GetClasses_StateUnderTest_ExpectedBehavior()
		{
			// Arrange
			var classesController = this.CreateClassesController();

			// Act
			var result = await classesController.GetClasses();

			// Assert
			Assert.True(false);
			this.mockRepository.VerifyAll();
		}

		[Fact]
		public async Task GetClass_StateUnderTest_ExpectedBehavior()
		{
			// Arrange
			var classesController = this.CreateClassesController();
			int id = 0;

			// Act
			var result = await classesController.GetClass(
				id);

			// Assert
			Assert.True(false);
			this.mockRepository.VerifyAll();
		}

		[Fact]
		public async Task PutClass_StateUnderTest_ExpectedBehavior()
		{
			// Arrange
			var classesController = this.CreateClassesController();
			int id = 0;
			Class @class = null;

			// Act
			var result = await classesController.PutClass(
				id,
				@class);

			// Assert
			Assert.True(false);
			this.mockRepository.VerifyAll();
		}

		[Fact]
		public async Task PostClass_StateUnderTest_ExpectedBehavior()
		{
			// Arrange
			var classesController = this.CreateClassesController();
			Class @class = null;

			// Act
			var result = await classesController.PostClass(
				@class);

			// Assert
			Assert.True(false);
			this.mockRepository.VerifyAll();
		}

		[Fact]
		public async Task DeleteClass_StateUnderTest_ExpectedBehavior()
		{
			// Arrange
			var classesController = this.CreateClassesController();
			int id = 0;

			// Act
			var result = await classesController.DeleteClass(
				id);

			// Assert
			Assert.True(false);
			this.mockRepository.VerifyAll();
		}
	}
}
