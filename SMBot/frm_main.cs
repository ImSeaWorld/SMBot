using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.IO;
using System.Net;
using System.Web;
using FormEssentials;
using System.Threading;
using System.Collections.Specialized;
using System.Diagnostics;

using WebSocketSharp;
using WebSocketSharp.Net;
using System.Text.RegularExpressions;

namespace SMBot
{
    public partial class frm_main : Form
    {
        private Random rnd = new Random();
        private HTTP http = new HTTP();
        private int accountsCreated = 0, accountsError = 0, fb_follows = 0, fb_unfollows = 0, SleepTimer = 500;
        [ThreadStatic] private CookieContainer mainCont = new CookieContainer();
        private Thread t_Verify, t_Create, t_Follow;
        private Color cDebug = Color.Orange, cError = Color.Red, cSuccess = Color.Green, cBlue = Color.Blue;
        private string[] Accounts;
        private string EmailDomain = "";
        private bool SlowYourRoll = false;

        public frm_main()
        {
            InitializeComponent();
        }

        private Color cType(string type)
        {
            switch (type) {
                case "debug": return cDebug;
                case "error": return cError;
                case "success": return cSuccess;
                case "blue": return cBlue;
                default: return Color.Black;
            }
        }

        private void WriteSettings(string Property, object Value) { Properties.Settings.Default[Property] = Value; Properties.Settings.Default.Save(); }
        private object ReadSetting(string Property) { return Properties.Settings.Default[Property]; }

        private void Write(string Type, string input, params object[] args)
        {
            Color Corrah = cType(Type);
            rtb_debug.AppendText("[");
            rtb_debug.SelectionStart = rtb_debug.TextLength;
            rtb_debug.SelectionLength = 0;
            rtb_debug.SelectionColor = Corrah;
            rtb_debug.AppendText(Type.ToUpper());
            rtb_debug.SelectionColor = rtb_debug.ForeColor;
            rtb_debug.AppendText(String.Format("] "+input+Environment.NewLine, args));
            rtb_debug.ScrollToCaret();
        }


        private void UpdateListView(string Type, string item, string text, params object[] args)
        {
            Color Corrah = cType(Type);
            lv_accounts.Items[lv_accounts.Search(item)].UseItemStyleForSubItems = false;
            lv_accounts.Items[lv_accounts.Search(item)].SubItems[1].ForeColor = Corrah;
            lv_accounts.Items[lv_accounts.Search(item)].SubItems[1].Text = String.Format(text, args);
        }

        private string RandomName(int length = 7)
        {
            string Chars = "abcdefghijklmnopqrstuvwxyz", res = "";
            for (int i = 0; i < length; i++) res += Chars.ToCharArray()[rnd.Next(0, 23)];
            for (int i = 0; i < 4; i++) res += rnd.Next(0, 9).ToString();
            return res;
        }

        private void CreateAccount()
        {
            int num = 0;
            string Username = RandomName();
            string[] Args = new string[] { "username", "displayName", "password", "email", "month", "day", "year" };
            string[] Params = new string[] { Username, Username, "kkk123", Username + EmailDomain, rnd.Next(1, 12).ToString(), rnd.Next(1, 28).ToString(), rnd.Next(1975, 1999).ToString() };
            NameValueCollection Create = new NameValueCollection() { { "username", "" }, { "displayName", "" }, { "password", "" }, { "email", "" }, { "month", "" }, { "day", "" }, { "year", "" } };
            foreach (string arg in Args)
                Create.Set(arg, Params[num++]);
            string response = http.Post("https://www.stream.me/embed/register", Create);
            if (response.Contains("user\":{},\"errors\":[{\"")) {
                Invoke(new MethodInvoker(delegate {
                    string errorMessage = Misc.getStrBetween(response, "{\"device\":null,\"user\":{},\"errors\":[{\"message\":\"", "\",\"code\":");
                    Write("error", errorMessage);
                    lbl_acc_errors.Text = (++accountsError).ToString();
                    if (errorMessage.Contains("#RateLimitHammer"))
                        this.SlowYourRoll = true;
                })); return;
            } else if (response.Contains("\":\"register_success\",\"message\":\"")){
                Invoke(new MethodInvoker(delegate {
                    Write("success", "Account \"{0}\" created!", Username);
                    lv_accounts.AddMore(Username, Misc.getStrBetween(response, "\":\"register_success\",\"message\":\"", "\",\"level\":\"success\""));
                    lbl_acc_created.Text = (++accountsCreated).ToString();
                })); VerifyAccount(Username);
            }
        }

        private string Unix() { return ((DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds).ToString().Replace(".", ""); }

        private void Login(string username, string password)
        {
            try {
                using (WebClientEx wc = new WebClientEx(mainCont)) {
                    wc.Headers.Set("Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8");
                    wc.Headers.Set("Accept-Encoding", "gzip, deflate, br");
                    wc.Headers.Set("Accept-Language", "en-US,en;q=0.8");
                    wc.Headers.Set("Cache-Control", "max-age=0");
                    wc.Headers.Set("User-Agent", "Mozilla/5.0 (Windows NT 6.2; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/56.0.2924.87 Safari/537.36");
                    wc.Headers.Set("Referer", "https://www.stream.me/embed/login");
                    wc.Headers.Set("Content-Type", "application/x-www-form-urlencoded");
                    wc.UploadString("https://www.stream.me/embed/login", "POST", String.Format("username={0}&password={1}", username, password));
                } Invoke(new MethodInvoker(delegate { Write("success", "Logged into: {0}", username); UpdateListView("success", username, "Logged In"); }));
            } catch { Invoke(new MethodInvoker(delegate { Write("error", "Error logging into: {0}", username); })); Thread.Sleep(1500); Login(username, password); }
        }

        private void VerifyAccount(string username)
        {
            t_Verify = new Thread(new ThreadStart(delegate {
                string shit = "";
                long nig = 1490979782538;
                NameValueCollection cookies = new NameValueCollection() { { "mail", username + EmailDomain }, { "lp_30309", "https://temp-mail.org/en/" } };
                for (; ; ) {
                    try {
                        shit = http.Get("https://temp-mail.org/en/option/check/?_=" + (nig++).ToString(), true, cookies);
                        if (shit.Contains("304")) { Thread.Sleep(1500); }
                        else {
                            string verifyLink = "https://www.stream.me/settings/verify/" + Misc.getStrBetween(http.Get(Misc.getStrBetween(shit, "<td><a href=\"", "\">")), "https://www.stream.me/settings/verify/", "</a>");
                            using (StreamWriter sw = new StreamWriter("accounts.txt", true)) sw.WriteLine("{0}:kkk123", username);
                            Process.Start("chrome.exe", verifyLink + " --incognito");
                            Invoke(new MethodInvoker(delegate {
                                UpdateListView("success", username, "Verified!");
                                Write("success", "Account {0} verified!", username);
                            })); 
                            break;
                        }
                    } catch { }
                }
            })); t_Verify.Start();
        }

        private void Follow(string acc, string pass, string stream, bool unfollow = false)
        {
            try {
                Login(acc, pass);
                using (WebClientEx wc = new WebClientEx(mainCont)) {
                    wc.Headers.Set("Accept", "application/json, text/plain, */*");
                    wc.Headers.Set("Accept-Encoding", "gzip, deflate, sdch, br");
                    wc.Headers.Set("Accept-Language", "en-US,en;q=0.8");
                    wc.Headers.Set("User-Agent", "Mozilla/5.0 (Windows NT 6.2; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/56.0.2924.87 Safari/537.36");
                    wc.Headers.Set("Referer", "https://www.stream.me/" + stream);
                    //wc.Headers.Set("Content-Length", "2");
                    wc.Headers.Set("Content-Type", "application/json;charset=UTF-8");
                    string resp = wc.UploadString(String.Format("https://www.stream.me/api-user/v1/{0}/follow/{1}", acc, stream), (unfollow ? "DELETE" : "PUT"), "");
                    Invoke(new MethodInvoker(delegate {
                        UpdateListView("success", acc, "{0} {1}.", (unfollow ? "Unfollowed" : "Followed"), stream);
                        Write("success", "{0} {1} {2}!", acc, (unfollow ? "Unfollowed" : "Followed"), stream);
                        if (!unfollow) lbl_fb_followed.Text = fb_follows++.ToString();
                        else lbl_fb_unfollow.Text = fb_unfollows++.ToString();
                    }));
                }               
            } catch (WebException ex) { Console.WriteLine("Ex: {0}", ex.Message); }
            catch { Invoke(new MethodInvoker(delegate { Write("error", "{0} had an issue.", acc); })); Thread.Sleep(1500); Follow(acc, pass, stream, unfollow); }
        }

        private void FollowThread(bool unfollow = false)
        {
            int lewp = 0;
            if (unfollow) fb_unfollows = 1;
            else fb_follows = 1;
            tb_fb_stream.Enabled = false;
            lbl_fb_current.Text = String.Format("{0} \"{1}\"...", (unfollow ? "Unfollowing" : "Following"), tb_fb_stream.Text);
            Accounts = File.ReadAllText("accounts.txt").Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
            t_Follow = new Thread(new ThreadStart(delegate {
                foreach (string acc in Accounts) {
                    if (lewp++ >= nud_fb_follows.Value && nud_fb_follows.Value > 0 && nud_fb_follows.Enabled) break;
                    if (acc != "") {
                        Thread follow = new Thread(new ThreadStart(delegate {
                            Follow(acc.Split(':')[0], acc.Split(':')[1], tb_fb_stream.Text, unfollow);
                        })); follow.Start();
                    } Thread.Sleep(SleepTimer);
                } Invoke(new MethodInvoker(delegate { lbl_fb_current.Text = "Nothing anymore... I'm bored."; tb_fb_stream.Enabled = true; }));
            })); t_Follow.Start();
        }

        private void LoadAccounts()
        {
            lv_accounts.Items.Clear();
            Accounts = File.ReadAllText("accounts.txt").Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
            lbl_fb_bots.Text = Accounts.Count().ToString();
            foreach (string account in Accounts)
                if (account != "") lv_accounts.AddMore(account.Split(':')[0], "Nothing yet.");
        }

        private void LoadSettings()
        {
            // Colors
            cDebug = (Color)ReadSetting("Debug");
            cError = (Color)ReadSetting("Error");
            cSuccess = (Color)ReadSetting("Success");
            // Misc
            SleepTimer = (int)ReadSetting("Sleep");

            // Update Elements
            tb_fb_stream.Text = (string)ReadSetting("LastStream");
            tb_successColor.ForeColor = cSuccess;
            tb_errorColor.ForeColor = cError;
            tb_debugColor.ForeColor = cDebug;
            nud_sleepTime.Value = SleepTimer;
        }

        private void LoadEmails()
        {
            string[] getEmails = Misc.getStrBetween(http.Get("https://temp-mail.org/en/option/change/"), "<select name=\"domain\" class=\"form-control\" id=\"domain\">", "</select>").Split('\n');
            if (getEmails.Length == 0) { MessageBox.Show("No emails found!"); return; }
            foreach (string email in getEmails) {
                if (Regex.Replace(email, @"\s+", "") != "") {
                    cb_email.Items.Add(Regex.Replace(Regex.Replace(email, @"\s+", ""), "<.*?>", ""));
                }
            }
        }

        private void frm_main_Load(object sender, EventArgs e)
        {
            //tc_main.TabPages.RemoveAt(1);
            LoadAccounts();
            LoadSettings();
            LoadEmails();
        }

        private void DebugColor(object sender, EventArgs e) { if (cd_main.ShowDialog() == DialogResult.OK) tb_debugColor.ForeColor = cd_main.Color; }
        private void ErrorColor(object sender, EventArgs e) { if (cd_main.ShowDialog() == DialogResult.OK) tb_errorColor.ForeColor = cd_main.Color; }
        private void SuccessColor(object sender, EventArgs e) { if (cd_main.ShowDialog() == DialogResult.OK) tb_successColor.ForeColor = cd_main.Color; }
        private void SetColors(object sender, EventArgs e) 
        { 
            cDebug = tb_debugColor.ForeColor; 
            cError = tb_errorColor.ForeColor; 
            cSuccess = tb_successColor.ForeColor;
            WriteSettings("Debug", tb_debugColor.ForeColor);
            WriteSettings("Error", tb_errorColor.ForeColor);
            WriteSettings("Success", tb_successColor.ForeColor);
        }

        private void cb_fb_follows_CheckedChanged(object sender, EventArgs e) { nud_fb_follows.Enabled = cb_fb_follows.Checked; }

        private void btn_acc_start_Click(object sender, EventArgs e)
        {
            if (cb_email.SelectedIndex == -1) {
                MessageBox.Show("Please select a proper email!");
                return;
            } else EmailDomain = cb_email.SelectedItem.ToString();

            t_Create = new Thread(new ThreadStart(delegate {
                for (int i = 0; i < nud_acc_accounts.Value; i++) {
                    if (this.SlowYourRoll) break;
                    Thread n = new Thread(new ThreadStart(delegate { CreateAccount(); }));
                    n.Start(); Thread.Sleep(2000);
                } this.SlowYourRoll = false;
            })); t_Create.Start();
        }

        private void btn_fb_followStart_Click(object sender, EventArgs e)
        {
            FollowThread();
        }

        private byte[] Slice(byte[] source, int length)
        {
            byte[] destfoo = new byte[length];
            Array.Copy(source, 0, destfoo, 0, length);
            return destfoo;
        }

        public byte[] HexStringToBytes(string HexString)
        {
            byte[] buffer = new byte[HexString.Length / 2];
            for (int i = 0; i < HexString.Length; i += 2)
            {
                try { buffer[i / 2] = Convert.ToByte(HexString.Substring(i, 2), 0x10); }
                catch { buffer[i / 2] = 0; }
            } return buffer;
        }

        public string BytesToHexString(byte[] Buffer)
        {
            string str = "";
            for (int i = 0; i < Buffer.Length; i++)
                str = str + Buffer[i].ToString("X2");
            return str;
        }

        private void btn_fb_unfollowStart_Click(object sender, EventArgs e)
        {
            FollowThread(true);
        }

        private void btn_msg_start_Click(object sender, EventArgs e)
        {
            MessageThread();
        }

        private string GetRollofle()
        {
            return http.Get("http://rolloffle.churchburning.org/troll_me_text.php");
        }

        private void MessageThread()
        {
            Random rnd = new Random();
            int lewp = 0;
            string RoomID = GetRoomID(tb_msg_stream.Text), message = rtb_msg_speak.Text;

            lbl_fb_current.Text = String.Format("Spamming \"{0}\"...", tb_msg_stream.Text);
            
            //new Thread(new ThreadStart(delegate {
                List<string> Rollofle = new List<string>();

                if (message == "%rand") {
                    for (int i = 0; i < nud_fb_follows.Value; i++) {
                        string Tits = GetRollofle();
                        for(; ; ) {
                            if (Tits.Length <= 200)
                                break;
                            Tits = GetRollofle();
                        } Rollofle.Add(Tits);
                    }

                    if (Rollofle.ToArray().Length <= 0) {
                        Invoke(new MethodInvoker(delegate { Write("error", "Rollofle array is empty!"); }));
                        return;
                    }

                    foreach (string MSG in Rollofle)
                    {
                        if (lewp >= nud_fb_follows.Value && nud_fb_follows.Value > 0) break;
                        new Thread(new ThreadStart(delegate {
                            sendMessage(Accounts[lewp].Split(':')[0], Accounts[lewp++].Split(':')[1], RoomID, MSG);
                        })).Start();
                        Thread.Sleep(SleepTimer);
                    }
                } else {
                    foreach (string acc in Accounts) {
                        if (lewp++ >= nud_fb_follows.Value && nud_fb_follows.Value > 0) break;
                        new Thread(new ThreadStart(delegate {
                            sendMessage(acc.Split(':')[0], acc.Split(':')[1], RoomID, message);
                        })).Start();
                        Thread.Sleep(SleepTimer);
                    }
                }
                Invoke(new MethodInvoker(delegate { lbl_fb_current.Text = "Nothing anymore... I'm bored."; Write("success", "Queue is clear!"); }));
            //})).Start();
        }

        private void sendMessage(string user, string pass, string RoomID, string Message)
        {
            try {
                Login(user, pass);
                using (WebClientEx wc = new WebClientEx(mainCont)) {
                    wc.Headers.Add("Accept", "application/json");
                    wc.Headers.Add("Accept-Encoding", "gzip, deflate, br");
                    wc.Headers.Add("Accept-Language", "en-US,en;q=0.9");
                    wc.Headers.Add("User-Agent", "Mozilla/5.0 (Windows NT 6.2; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/56.0.2924.87 Safari/537.36");
                    wc.Headers.Add("Content-Type", "application/json");
                    wc.Headers.Add("Referer", "https://www.stream.me/stream-embed/user:" + RoomID + ":web/chat-only?showPopout=true&hideMetaHeader=true");
                    wc.Headers.Add("Origin", "https://stream.me");
                    wc.Headers.Add("Host", "www.stream.me");
                    string Resp = wc.UploadString("https://www.stream.me/api-commands/v1/room/user:" + RoomID + ":web/command/say?requestedLocale=en", "POST", "{\"message\":\"" + Message + "\"}");
                    //MessageBox.Show(Resp);
                    Invoke(new MethodInvoker(delegate {
                        if (Resp.Contains("\"banned\"")) { UpdateListView("error", user, "Banned"); Write("error", "\"{0}\" has been banned :(", user); }
                        else { UpdateListView("blue", user, "Message Sent!"); Write("success", "Message Sent From \"{0}\" to \"{1}\"", user, RoomID); }
                    }));
                }
            } catch (WebException wex) { Invoke(new MethodInvoker(delegate { UpdateListView("error", user, "ERROR"); })); Console.WriteLine("Error! Account: {0}\n{1}", user, wex.Message); }
        }

        private string GetRoomID(string user)
        {
            return Misc.getStrBetween(http.Get("https://www.stream.me/" + user), "<meta property=\"og:image\" content=\"https://thumb.creekcdn.com/mediasvc/v1/app/web/thumb/live/v/", ".jpg\" />").Split('/').Last();
            //return Misc.getStrBetween(http.Get("https://www.stream.me/" + user), "\"userPublicId\":\"", "\"");
        }

        private void SMWebSockets()
        {
            //using (var ws = new WebSocket("wss://www.stream.me/api-rooms/v3/ws"))
            //{
            Invoke(new MethodInvoker(delegate
            {
                var ws = new WebSocket("wss://www.stream.me/api-rooms/v3/ws");
                ws.OnOpen += (ssender, ee) => Console.WriteLine("WebSocket Open.");
                ws.OnMessage += (ssender, ee) => Console.WriteLine("OnMessage Triggered: {0}", ee.Data);
                ws.OnError += (Sender, E) => Console.WriteLine("OnError Triggered: {0}", E.Message);
                ws.OnClose += (Sender, E) => Console.WriteLine("OnClose Event Triggered: {0}", E.Reason);
                ws.Origin = "https://www.stream.me";
                ws.SetCredentials("eqiourw0015", "kkk123", true);
                ws.SetCookie(new WebSocketSharp.Net.Cookie("__cfduid", "d54cbf245a6c9ee35aaa480beccda439d1490763687"));
                ws.SetCookie(new WebSocketSharp.Net.Cookie("psessid", "09583f3d-12e5-4599-b3cb-284c0b65aaa9"));
                ws.SetCookie(new WebSocketSharp.Net.Cookie("pat", "5847d61ae0fd87657560a3d43b8994db5a98c97a"));
                ws.Connect();
                ws.Send("chat {\"action\": \"join\", \"room\": \"user:28c8ed27-5a37-46ff-8c73-7e743d4a927e:web\"}");
                ws.Send("chat message {\"room\":\"user:28c8ed27-5a37-46ff-8c73-7e743d4a927e:web\",\"type\":\"chat\",\"data\":[\"v1\",\"1492488169422579385\",\"skrr\",[\"web\",\"SeaWorld\",\"seaworld\",\"user\",\"#666666\",[],[\"av\",0,[\"2\",\"23e6a1a9-a1e4-4861-99d1-1371d57f37c2\"]],\"23e6a1a9-a1e4-4861-99d1-1371d57f37c2\"],[],[],[],[],1492488169,null]}");
            }));
            //}
        }

        private void frm_main_FormClosing(object sender, FormClosingEventArgs e)
        {
            WriteSettings("LastStream", tb_fb_stream.Text);
            Environment.Exit(0);
        }

        private void SetSleepTime(object sender, EventArgs e) { WriteSettings("Sleep", Convert.ToInt32(nud_sleepTime.Value)); SleepTimer = Convert.ToInt32(nud_sleepTime.Value); }

        private void ReloadAccounts(object sender, EventArgs e)
        {
            LoadAccounts();
        }

        private void DupeChecker(object sender, EventArgs e)
        {
            int dupes = lv_accounts.checkDupes();
            MessageBox.Show(String.Format("You had {0} duplicates.", dupes), dupes == 0 ? "Yay!" : "Well Shit...");
        }
    }
}
