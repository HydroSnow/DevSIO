using System.Windows.Forms;

namespace cs_pictionary
{
    public class Program
    {
        private static void Main()
        {
            Program program = new Program();
        }

        private Program()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Fenetre fenetre = new Fenetre();
            Application.Run(fenetre);
        }
    }
}
