using System.Windows.Forms;

namespace cs_pictionary
{
    public class Program
    {
        private static Program program;

        private static Program getProgram()
        {
            return program;
        }

        private static void Main()
        {
            program = new Program();
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
