using Microsoft.Deployment.WindowsInstaller;

namespace InstallSummaryCA
{
    public class CustomActions
    {
        [CustomAction]
        public static ActionResult ShowInstallSummary(Session session)
        {
            session.Log("Begin ShowInstallSummary");
            
            AndroidAppSetup androidAppSetup = new AndroidAppSetup(session);
            androidAppSetup.ShowDialog();

            return ActionResult.Success;
        }
    }
}
