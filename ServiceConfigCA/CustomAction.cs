using Microsoft.Deployment.WindowsInstaller;
using System.Windows.Forms;

namespace ServiceConfigCA
{
    public class CustomActions
    {
        [CustomAction]
        public static ActionResult ConfigService(Session session)
        {
            session.Log("Begin ConfigService");

            ConfigService configService = new ConfigService(session);
            if (configService.ShowDialog() == DialogResult.Cancel)
                return ActionResult.UserExit;

            return ActionResult.Success;
        }
    }
}
