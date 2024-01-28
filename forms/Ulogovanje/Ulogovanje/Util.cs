using System.Reflection;
using System.Text.Json;
using Newtonsoft.Json;
using Ulogovanje;

namespace Util
{
    public class User
    {
        private String _username;
        private String _password;
        private String _email;
        private String _first_name;
        private String _last_name;
        private int _age;

        public String username { get { return _username; } }
        public String password { get { return _password; } }
        public String email { get { return _email; } }
        public String first_name { get { return _first_name; } }
        public String last_name { get { return _last_name; } }
        public int age { get { return _age; } }

        public User(string username, string password, string email, string first_name, string last_name, int age)
        {
            _username = username;
            _password = password;
            _email = email;
            _first_name = first_name;
            _last_name = last_name;
            _age = age;
        }
    }

    static class Auth
    {
        private static User loggedUser;
        private static List<User> _users;
        private static String _path = "E:\\Programiranje\\Codes\\Ulogovanje\\Ulogovanje\\users.json";

        public static List<User> users { get { return _users; } }


        public static void loadUsers()
        {
            using (StreamReader r = new StreamReader(_path))
            {
                String json = r.ReadToEnd();
                List<User> deserialized = JsonConvert.DeserializeObject<List<User>>(json);
                _users = deserialized;
            }
        }

        public static void Login(String username, String password)
        {
            String[] usernames = _users.ToList().Select(u => u.username).ToArray();

            User crrUsr = _users.ToList().Where(u => u.username == username).FirstOrDefault();
            if (!usernames.Contains(username))
                MessageBox.Show("Korisnik sa ovim imenom ne postoji!");
            else
            {
                if (crrUsr.password != password)
                    MessageBox.Show("Lozinka je pogresna!");
                for (int i = 0; i < _users.Count; i++)
                    if (crrUsr.username == username && crrUsr.password == password)
                    {
                        loggedUser = crrUsr;
                        Form2 f = new Form2(loggedUser);
                        f.Show();
                        break;
                    }
            }
        }

        public static void Register(String username, String password)
        {

        }
    }

    enum AuthType
    {
        Login,
        Register,
        Null,
    }
}
