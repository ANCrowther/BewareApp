using System;

namespace Beware {
    public static class Program {
        [STAThread]
        static void Main() {
            using (var game = new BewareGame())
                game.Run();
        }
    }
}
