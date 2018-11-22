/*
    Form Essentials, Complicated Functions With Little Work
    Copyright (C) 2016 SeaWorld

    This program is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    This program is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with this program.  If not, see <http://www.gnu.org/licenses/>.
*/

using System;
using System.Collections.Generic;
using System.Text;

using System.IO;
using System.Linq;
using System.Diagnostics;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Runtime.InteropServices;

namespace FormEssentials
{
    public static class Forms
    {
        public static bool isFormOpen(Form nigform)
        {
            return Application.OpenForms[nigform.Name] as Form != null;
        }
    }

    public static class TextBoxes
    {
        /// <summary>
        ///     Grabs all textboxes within a parent by number. textbox1, textbox2, etc.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="control"></param>
        /// <param name="dec"></param>
        /// <returns>
        ///     (List<TextBox>)Returns all textboxes affiliated within the parent control.
        /// </returns>
        public static List<TextBox> GetTextBoxesByNum(string name, Control control, bool dec = false)
        {
            List<TextBox> tb = new List<TextBox>();
            foreach (Control con in control.Controls)
                if (con.Name.Contains(name))
                    tb.Add(con as TextBox);
            return dec ? tb.OrderByDescending(x => int.Parse(x.Name.Replace(name, ""))).AsEnumerable().ToList() : tb.OrderByDescending(x => int.Parse(x.Name.Replace(name, ""))).AsEnumerable().Reverse().ToList();
        }
    }

    public static class ListViews
    {
        /// <summary>
        ///     Extension of ListView to add more items in one line.
        /// </summary>
        /// <param name="LeListView"></param>
        /// <param name="item"></param>
        /// <param name="moreItems"></param>
        public static void AddMore(this ListView LeListView, string item, params object[] moreItems)
        {
            ListViewItem lv_item = new ListViewItem(item);
            if (moreItems.Length > 0)
                for (int i = 0; i < moreItems.Length; i++)
                    lv_item.SubItems.Add(moreItems[i].ToString());
            LeListView.Items.Add(lv_item);
        }

        public static bool doesItemExistLV(this ListView LeListView, string search, bool checkSubItems = false)
        {
            foreach (ListViewItem lv_item in LeListView.Items)
            {
                if (checkSubItems)
                {
                    for (int i = 0; i < lv_item.SubItems.Count; i++)
                    {
                        if (lv_item.SubItems[i].Text.ToLower() == search.ToLower())
                            return true;
                    }
                }
                else
                {
                    if (lv_item.Text.ToLower() == search.ToLower())
                        return true;
                }
            }
            return false;
        }

        public static bool doesItemContain(this ListView LeListView, string search, int loc)
        {
            foreach (ListViewItem lv_item in LeListView.Items)
                return lv_item.SubItems[loc].Text.ToLower().Contains(search.ToLower());
            return false;
        }

        public static bool doesItemContain2(this ListViewItem Item, string search, int loc)
        {
            return Item.SubItems[loc].Text.ToLower().Contains(search.ToLower());
        }

        /// <summary>
        ///     This will search through the listview and return the location.
        /// </summary>
        /// <param name="lv"></param>
        /// <param name="search"></param>
        /// <returns>
        ///     (int)Location of found object.
        /// </returns>
        public static int Search(this ListView lv, string search)
        {
            if (lv.Items.Count > 0)
                for (int x = 0; x < lv.Items.Count; x++)
                    if (lv.Items[x].Text == search)
                        return x;
            return -1;
        }

        /// <summary>
        ///     Removed any sort of duplicates within a listview.
        /// </summary>
        /// <param name="lv"></param>
        public static void removeDupes(this ListView lv)
        {
            if (lv.Items.Count > 0)
                for (int x = 0; x < lv.Items.Count; x++)
                    for (int y = 1; y < lv.Items.Count; y++)
                        if (x != y)
                            if (lv.Items[x].Text == lv.Items[y].Text)
                                lv.Items[y].Remove();
        }

        public static int checkDupes(this ListView lv)
        {
            int ret = 0;
            if (lv.Items.Count > 0)
                for (int x = 0; x < lv.Items.Count; x++)
                    for (int y = 1; y < lv.Items.Count; y++)
                        if (x != y)
                            if (lv.Items[x].Text == lv.Items[y].Text)
                                ret++;
            return ret;
        }
    }

    public static class Encodings
    {
        /// <summary>
        ///     Encodes string with Base64 and has the capabilities of decoding as well.
        /// </summary>
        /// <param name="input"></param>
        /// <param name="encode"></param>
        /// <returns>
        ///     (string)Base64 encoded or decoded.
        /// </returns>
        public static string Base64(string input, bool encode = true)
        {
            return encode ? Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(input)) : System.Text.Encoding.UTF8.GetString(System.Convert.FromBase64String(input));
        }

        /// <summary>
        ///     Extenstion of (string). This also encodes/decodes strings/base64.
        /// </summary>
        /// <param name="input"></param>
        /// <param name="encode"></param>
        /// <returns>
        ///     (string)Base64 encoded or decoded.
        /// </returns>
        public static string Base64_2(this string input, bool encode = true)
        {
            return encode ? Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(input)) : System.Text.Encoding.UTF8.GetString(System.Convert.FromBase64String(input));
        }
    }

    public static class Hashing
    {
        public static string MD5(string arg)
        {
            string result = "";
            MD5CryptoServiceProvider _MD5 = new MD5CryptoServiceProvider();
            _MD5.ComputeHash(Encoding.ASCII.GetBytes(arg));
            for (int i = 0; i < _MD5.Hash.Length; i++)
            {
                result += _MD5.Hash[i].ToString("x2");
            } return result;
        }

        public static string MD5(byte[] arg)
        {
            string result = "";
            MD5CryptoServiceProvider _MD5 = new MD5CryptoServiceProvider();
            _MD5.ComputeHash(arg);
            for (int i = 0; i < _MD5.Hash.Length; i++)
            {
                result += _MD5.Hash[i].ToString("x2");
            } return result;
        }

        public static string MD5(FileStream arg) { return MD5(arg); }
    }

    public static class Conversion
    {
        public static string BytesToHexString(byte[] Buffer)
        {
            string str = "";
            for (int i = 0; i < Buffer.Length; i++)
                str = str + Buffer[i].ToString("X2");
            return str;
        }

        public static string ConvertStringToHex(string asciiString)
        {
            string hex = "";
            foreach (char c in asciiString)
                hex += String.Format("{0:x2}", (uint)System.Convert.ToUInt32(c));
            return hex;
        }
    }

    public static class SelfHashing
    {
        public static string GetExecutingFileHash()
        {
            return MD5(GetSelfBytes());
        }

        private static string MD5(byte[] input)
        {
            return MD5(ASCIIEncoding.ASCII.GetString(input));
        }

        private static string MD5(string input)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            byte[] originalBytes = ASCIIEncoding.Default.GetBytes(input);
            byte[] encodedBytes = md5.ComputeHash(originalBytes);
            return BitConverter.ToString(encodedBytes).Replace("-", "");
        }

        private static byte[] GetSelfBytes()
        {
            string path = Application.ExecutablePath;
            FileStream running = File.OpenRead(path);
            byte[] exeBytes = new byte[running.Length];
            running.Read(exeBytes, 0, exeBytes.Length);
            running.Close();
            return exeBytes;
        }
    }

    public class IniFile
    {
        public string path;

        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section,
            string key, string val, string filePath);
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section,
                 string key, string def, StringBuilder retVal,
            int size, string filePath);

        public IniFile(string INIPath) { path = INIPath; }

        public void IniWriteValue(string Section, string Key, string Value)
        { WritePrivateProfileString(Section, Key, Value, path); }

        public string IniReadValue(string Section, string Key)
        {
            StringBuilder temp = new StringBuilder(255);
            int i = GetPrivateProfileString(Section, Key, "", temp, 255, path);
            return temp.ToString();
        }
    }

    public static class Bytes
    {
        public static byte[] ReverseBytes(byte[] input) { return input.Reverse().ToArray(); }
        public static byte[] ReverseBytes(string input) { return Encoding.UTF8.GetBytes(input).Reverse().ToArray(); }

        public static bool isEmpty(byte[] input) { return input.Length <= 0; }

        public static bool ComapaireBytes(byte[] input1, byte[] input2)
        {
            if (input1.Length != input2.Length)
                return false;
            for (int i = 0; i < input1.Length; i++)
                if (input1[i] != input2[i])
                    return false;
            return true;
        }
    }

    public static class DateTimes
    {
        public static string TimeElapsed(DateTime date1, DateTime date2)
        {
            TimeSpan ts = (date1 - date2);
            return String.Format("{0} Year(s), {1} Month(s), {2} Day(s), {3} Hour(s), {4} Minute(s), {5} Second(s)", Math.Truncate(ts.TotalDays / 365), Math.Truncate(ts.TotalDays % 365) / 30, Math.Truncate(ts.TotalDays % 365) % 30, ts.Hours, ts.Minutes, ts.Seconds);
        }

        public static string DateTimeToUnix_s(DateTime time)
        { return time.Subtract(new DateTime(1970, 1, 1)).TotalSeconds.ToString(); }
        public static int DateTimeToUnix(DateTime time)
        { return (Int32)time.Subtract(new DateTime(1970, 1, 1)).TotalSeconds; }

        public static string DateTimeToJava_s(DateTime time)
        { return time.Subtract(new DateTime(1970, 1, 1)).TotalMilliseconds.ToString(); }
        public static int DateTimeToJava(DateTime time)
        { return (Int32)time.Subtract(new DateTime(1970, 1, 1)).TotalMilliseconds; }

        public static DateTime UnixToDateTime(int unix)
        { return new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc).AddSeconds(unix).ToLocalTime(); }
        public static DateTime UnixToDateTime(string unix)
        { return UnixToDateTime(Convert.ToInt32(unix)); }

        public static DateTime JavaToDateTime(int JavaTimeStamp)
        { return new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc).AddMilliseconds(Convert.ToInt32(JavaTimeStamp)).ToLocalTime(); }
        public static DateTime JavaToDateTime(string JavaTimeStamp)
        { return JavaToDateTime(Convert.ToInt32(JavaTimeStamp)); }
    }

    public static class WindowsConsole
    {
        public static bool ExecConsole(string cmd, bool runas = false, ProcessWindowStyle style = ProcessWindowStyle.Hidden)
        {
            try
            {
                Process proc = new Process();
                ProcessStartInfo procStartInfo = new ProcessStartInfo();
                procStartInfo.WindowStyle = style;
                procStartInfo.Verb = runas ? "runas" : "";
                procStartInfo.FileName = "cmd.exe";
                procStartInfo.Arguments = cmd;
                proc.StartInfo = procStartInfo;
                proc.Start();
                return true;
            }
            catch { return false; }
        }
    }
}