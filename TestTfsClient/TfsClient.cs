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

            Uri uri = new Uri("http://localhost:7777/DefaultCollection/");

            // http://laptop-hr8bq31u:7777/DefaultCollection/
            TfsTeamProjectCollection tpc = TfsTeamProjectCollectionFactory.GetTeamProjectCollection(uri);
            // TfsTeamProjectCollection tpc = new TfsTeamProjectCollection(uri);

            VersionControlServer vcs = tpc.GetService<VersionControlServer>();

            // Workstation.Current.EnsureUpdateWorkspaceInfoCache(vcs, vcs.AuthorizedUser);

            var ss = vcs.QueryWorkspaces(DefaultWorkspaceName, null, null);

            var w = vcs.GetWorkspace(@"D:\Projects\SampleProjectsWs1\");

            var a = 0;

        }
    }
}
