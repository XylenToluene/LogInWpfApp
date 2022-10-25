using System.Windows.Controls.Primitives;

namespace WpfApp3.DB
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public Status Status { get; set; }

    }
}