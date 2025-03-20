using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace contiCasterLevelTwoServer
{
	// Token: 0x0200000A RID: 10
	internal static class Program
	{
		// Token: 0x06000052 RID: 82 RVA: 0x00015993 File Offset: 0x00013B93
		[STAThread]
		private static void Main()
		{

			bool createNew;
			Mutex monly = new Mutex(true, Application.ProductName, out createNew);
			if (createNew)
			{
				monly.ReleaseMutex();
				Application.EnableVisualStyles();
				Application.SetCompatibleTextRenderingDefault(false);
				Application.Run(new IntelligentBilletProduction());
			}
			else
			{
				Process.Start(Application.StartupPath + "\\ExitApplication.exe");
			}

			//bool createNew;
			//Mutex monly = new Mutex(true, Application.ProductName, out createNew);
			//if (createNew)
			//{
			//monly.ReleaseMutex();
			//Application.EnableVisualStyles();
			//Application.SetCompatibleTextRenderingDefault(false);
			//Application.Run(new IntelligentBilletProduction());
			//}
			//else
			//{
			//	Process.Start(Application.StartupPath + "\\ExitApplication.exe");
			//}
		}
	}
}
