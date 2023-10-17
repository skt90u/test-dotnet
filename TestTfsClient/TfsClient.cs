using Microsoft.TeamFoundation.Client;
using Microsoft.TeamFoundation.VersionControl.Client;
using System;

namespace TestTfsClient
{
    public class TfsClient
    {
        public static readonly string DefaultWorkspaceName = Environment.MachineName;

        public static void Test()
        {
            // https://github.com/microsoft/azure-devops-dotnet-samples

            var url = "http://localhost:7777/DefaultCollection/";
            var uri = new Uri(url);
            var tpc = TfsTeamProjectCollectionFactory.GetTeamProjectCollection(uri);
            var vcs = tpc.GetService<VersionControlServer>();

            
            // Workstation.Current.EnsureUpdateWorkspaceInfoCache(vcs, vcs.AuthorizedUser);

            #region QueryWorkspaces

            // > tf vc workspaces

            var workspace0 = vcs.QueryWorkspaces(workspaceName: null, 
                                                 workspaceOwner: null, 
                                                 computer: null);

            var workspace1 = vcs.QueryWorkspaces(workspaceName: "LAPTOP-HR8BQ31U",
                                                 workspaceOwner: null, 
                                                 computer: null);

            var workspace2 = vcs.QueryWorkspaces(workspaceName: "LAPTOP-HR8BQ31U(AutoDeploy)",
                                                 workspaceOwner: null, 
                                                 computer: null);

            var workspace3 = vcs.QueryWorkspaces(workspaceName: null,
                                                 workspaceOwner: Environment.UserName, 
                                                 computer: null);

            var workspace4 = vcs.QueryWorkspaces(workspaceName: null,
                                                 workspaceOwner: null, 
                                                 computer: Environment.MachineName);

            #endregion

            #region GetWorkspace

            // > tf vc workfold /workspace:LAPTOP-HR8BQ31U
            // > tf vc workfold /workspace:LAPTOP-HR8BQ31U(AutoDeploy)

            var workspace10 = vcs.GetWorkspace(@"D:\Projects\SampleProjectsWs1");
            var workspace11 = vcs.GetWorkspace(@"D:\TEMP\AutoDeploySrc\SampleProjects\SampleConsoleApp");
            var workspace12 = vcs.GetWorkspace(@"D:\TEMP\AutoDeploySrc\SampleProjects\SampleWcfService");
            var workspace13 = vcs.GetWorkspace(@"D:\TEMP\AutoDeploySrc\SampleProjects\SampleWebApi");
            var workspace14 = vcs.GetWorkspace(@"D:\TEMP\AutoDeploySrc\SampleProjects\SampleWebApplication");
            var workspace15 = vcs.GetWorkspace(@"D:\TEMP\AutoDeploySrc\SampleProjects\SampleWebSite");

            #endregion

            #region QueryHistory

            #endregion

            var a = 0;
        }
    }
}
