using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using IlyasCovidMovieMadness.Context;
using IlyasCovidMovieMadness.Services;
using System.Web.Http;
using System.Web.Mvc;

namespace IlyasCovidMovieMadness.App_Start
{
    public class ContainerConfig
    {
        internal static void RegisterContainer(HttpConfiguration httpConfiguration)
        {
            var builder = new ContainerBuilder();
            //tar hand om dependecy injection
            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            builder.RegisterType<SqlMovieData>()
                .As<IMovieData>()
                .InstancePerRequest();

            builder.RegisterType<SqlPostData>()
                .As<IPostData>()
                .InstancePerRequest();

            builder.RegisterType<SqlCommentData>()
                .As<ICommentData>()
                .InstancePerRequest();

            builder.RegisterType<cmmDbContext>().InstancePerRequest();

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            httpConfiguration.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}