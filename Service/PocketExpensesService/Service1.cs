using System.ServiceProcess;
using System.Web.Http.SelfHost;
using System.Web.Http;

namespace PocketExpensesService
{
    public partial class Service1 : ServiceBase
    {
       // private ServiceHost _host;
        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            var config = new HttpSelfHostConfiguration("http://localhost:6002/");

            config.Routes.MapHttpRoute(
                name: "API",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
                );

            HttpSelfHostServer server = new HttpSelfHostServer(config);
            server.OpenAsync().Wait();
        }

        protected override void OnStop()
        {
            
        }
    }
}
