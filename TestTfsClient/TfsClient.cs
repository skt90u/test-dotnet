using Microsoft.TeamFoundation.Client;
using Microsoft.TeamFoundation.VersionControl.Client;
using System;

namespace TestTfsClient
{
    public class TfsClient
    {
        public static void Test()
        {
            // https://github.com/microsoft/azure-devops-dotnet-samples

            Uri uri = new Uri("http://localhost:7777");

            TfsTeamProjectCollection tpc = new TfsTeamProjectCollection(uri);

            VersionControlServer vcs = tpc.GetService<VersionControlServer>();

            // Workstation.Current.EnsureUpdateWorkspaceInfoCache(vcs, vcs.AuthorizedUser);

            var ss = vcs.QueryWorkspaces("$/test-tfs", Environment.UserName, "");

            var w = vcs.GetWorkspace(@"D:\Projects\test-tfs\");

            var a = 0;

        }
    }
}
