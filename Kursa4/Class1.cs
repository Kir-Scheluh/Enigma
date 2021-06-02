using System;


namespace Kursa4
{
    public class Reflector
    {
        static char[] enc_alphabet;
        static char[] alphabet = "abcdefghijklmnopqrstuvwxyz".ToCharArray();
        public Reflector(string let = "a")
        {
            int num = Array.IndexOf(alphabet, Convert.ToChar(let.ToLower()));
            switch (num)
            {
                case 0:
                    enc_alphabet = "EJMZALYXVBWFCRQUONTSPIKHGD".ToLower().ToCharArray();
                    break;
                case 1:
                    enc_alphabet = "YRUHQSLDPXNGOKMIEBFZCWVJAT".ToLower().ToCharArray();
                    break;
                case 2:
                    enc_alphabet = "FVPJIAOYEDRZXWGCTKUQSBNMHL".ToLower().ToCharArray();
                    break;
            }
        }
        public char transition(Rotor r, ref char let)
        {
            int rotor_pos = r.rotor_position;
            if ((Array.IndexOf(alphabet, let) - rotor_pos < 0)) { let = alphabet[(Array.IndexOf(alphabet, let) - rotor_pos + 26) % 26]; }
            else { let = alphabet[(Array.IndexOf(alphabet, let) - rotor_pos) % 26]; }
            let = enc_alphabet[Array.IndexOf(alphabet, let)];
            if (Array.IndexOf(alphabet, let) + rotor_pos < 0) { let = alphabet[(Array.IndexOf(alphabet, let) + rotor_pos + 26) % 26]; }
            else { let = alphabet[(Array.IndexOf(alphabet, let) + rotor_pos) % 26]; }
            return let;
        }
    }
    public class Rotor
    {
        public static char[] alph = "abcdefghijklmnopqrstuvwxyz".ToCharArray();
        public static char[] alphabet = "abcdefghijklmnopqrstuvwxyz".ToCharArray();
        public int step, rotor_position;
        public int number = 0; // Справа налево
        char[] enc_alphabet;
        public Rotor(string num = "1", string start_position = "a")
        {
            rotor_position = Array.IndexOf(alphabet, Convert.ToChar(start_position));
            switch (Convert.ToInt32(num))
            {
                case 1:
                    enc_alphabet = "EKMFLGDQVZNTOWYHXUSPAIBRCJ".ToLower().ToCharArray();
                    step = Array.IndexOf<char>(alphabet, 'r');
                    break;
                case 2:
                    enc_alphabet = "AJDKSIRUXBLHWTMCQGZNPYFVOE".ToLower().ToCharArray();
                    step = Array.IndexOf<char>(alphabet, 'f');
                    break;
                case 3:
                    enc_alphabet = "BDFHJLCPRTXVZNYEIWGAKMUSQO".ToLower().ToCharArray();
                    step = Array.IndexOf<char>(alphabet, 'w');
                    break;
                case 4:
                    enc_alphabet = "ESOVPZJAYQUIRHXLNFTGKDCMWB".ToLower().ToCharArray();
                    step = Array.IndexOf<char>(alphabet, 'j');
                    break;
                case 5:
                    enc_alphabet = "VZBRGITYUPSDNHLXAWMJQOFECK".ToLower().ToCharArray();
                    step = Array.IndexOf<char>(alphabet, 'z');
                    break;
            }            
        }
        public static void stepping(Rotor r1, Rotor r2, Rotor r3)
        {
            r1.rotor_position = (r1.rotor_position + 1) % 26;
            if (r1.rotor_position == r1.step)
            {
                r2.rotor_position = (r2.rotor_position + 1) % 26;
            }
            if (r2.rotor_position == r2.step)
            {
                r3.rotor_position = (r3.rotor_position + 1) % 26;
            }
        }
        public char change_letter(Rotor r, char let)
        {
            int index = Array.IndexOf<char>(alphabet, let);
            return enc_alphabet[index];
        }
        public char revers_change_letter(Rotor r, char let) 
        {
            int index = Array.IndexOf<char>(enc_alphabet, let);
            return alphabet[index];
        }
        public static char transition(Rotor rot1, Rotor rot2, char letter) // rot1 - начальный, rot2 - выходной
        {
            int ind = Array.IndexOf(alphabet, letter);
            if (rot1.number < rot2.number)
            {
                ind = (ind + (rot2.rotor_position - rot1.rotor_position)) % 26;
                if (ind < 0) ind += 26;
                return alphabet[ind];
            }
            else
            {
                ind = (ind - (rot1.rotor_position - rot2.rotor_position)) % 26;
                if (ind < 0) ind += 26;
                return alphabet[ind];
            }
        }
    }
}
