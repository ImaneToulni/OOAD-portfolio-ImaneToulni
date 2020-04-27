using System;
using System.Collections.Generic;
using System.Text;

namespace WPFEscapeRoom
{
    // =====================
    // 3 soorten berichten 
    // =====================
    public enum MessageType { locked, wrongKey, incorrect};

    // =========================================
    // Random text genereren, per soort bericht 
    // =========================================
    static class RandomMessageGenerator
    {
        private static Random rnd = new Random();
        private static readonly string[] locked = new string[]
        {
            "It is locked",
            "It doesn't open",
            "Can't move it. Try again!"
        };


        private static readonly string[] wrongKey = new string[]
        {
            "the key doesn't fit in the door",
            "hmmm... it's seems like a wrong key",
            "wrong key. Try again!"
        };

        private static readonly string[] incorrect = new string[]
        {
            "It doesn't fit",
            "Can't use it",
            "Wrong key"
        };

        public static string GetRandomLockedText()
        {
            int i = rnd.Next(0, locked.Length);
            return locked[i];
        }

        public static string RandomMessage(MessageType m)
        {
            switch (m)
            {
                case MessageType.locked:
                    return locked[rnd.Next(0, locked.Length)];
                case MessageType.wrongKey:
                    return wrongKey[rnd.Next(0, locked.Length)];
                case MessageType.incorrect:
                    return incorrect[rnd.Next(0, locked.Length)];
            }
            return null;
        }
    }
}
