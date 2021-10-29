using System;
using System.Reflection;

namespace PasswordManager.Client.Core
{
    public static class This
    {
        public static Assembly Assembly => typeof(This).Assembly;
    }
}
