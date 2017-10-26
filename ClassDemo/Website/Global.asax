<%@ Application Language="C#" %>
<%@ Import Namespace="Website" %>
<%@ Import Namespace="System.Web.Optimization" %>
<%@ Import Namespace="System.Web.Routing" %>
<%@ Import Namespace="ChinookSystem.BLL.Security" %>

<script runat="server">

    void Application_Start(object sender, EventArgs e)
    {
        var roleManager = new RoleManager();
        var userManager = new UserManager();

        RouteConfig.RegisterRoutes(RouteTable.Routes);
        BundleConfig.RegisterBundles(BundleTable.Bundles);

        roleManager.AddDefaultRoles();
        userManager.AddWebMaster();
        userManager.AddEmployees();
    }

</script>
