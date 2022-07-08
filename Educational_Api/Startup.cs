using Educational_Api.Models.Context;
using Educational_Api.Services;
using Educational_Api.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

namespace Educational_Api
{
	public class Startup
	{

		#region Private Fields

		private const string DATABASE_CONNECTION_NAME = "EducationalDb";
		
		#endregion

		#region Public Fields

		public IConfiguration Configuration { get; }

		#endregion

		#region Public Constructors

		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		#endregion

		#region Public Methods
		// This method gets called by the runtime.
		public void ConfigureServices(IServiceCollection services)
		{
			// Controllers configuration
			services.AddControllers()
				.AddJsonOptions(x => x.JsonSerializerOptions
				.ReferenceHandler = ReferenceHandler.IgnoreCycles);

			services.AddRouting(options => options.LowercaseUrls = true);

			// Services configuration
			services.AddDbContext<EducationalContext>(opt =>
				opt.UseLazyLoadingProxies()
				.UseSqlServer(Configuration.GetConnectionString(DATABASE_CONNECTION_NAME)));

			services.AddScoped<IClassService, ClassService>();
			services.AddScoped<IStudentService, StudentService>();

			// Swagger
			services.AddSwaggerGen();
		}

		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseSwagger()
			   .UseSwaggerUI();

			app.UseHttpsRedirection()
			   .UseAuthentication()
			   .UseRouting()
			   .UseAuthorization()
			   .UseEndpoints(endpoints =>
			   {
				   endpoints.MapControllers();
			   });
		}

		#endregion
	}
}
