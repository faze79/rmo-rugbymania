using System;

namespace My
{
    public class FFMPEG
    {
        public string ERROR = "";
        public string Source = ".\ffmpeg.exe";
        public FFMPEG(string path)
        {
            Source = path;
        }

        public bool WriteFrame(string file, TimeSpan time, string image)
        {
            bool result = false;
            //MS_MamLite.Forms.Frame d = new MS_MamLite.Forms.Frame();
            //d.Show();
            try
            {
                TimeSpan tx = time;
                System.Diagnostics.Process p = new System.Diagnostics.Process();
                p.StartInfo.FileName = Source;
                string args = "-y -i \"$1\" -ss $2 -t 00:00:01 -f image2 \"$3\"";
                args = args.Replace("$1", file);
                args = args.Replace("$3", image);
                if (tx >  new TimeSpan(0, 0, 0, 0, 40)) tx = tx - new TimeSpan(0, 0, 0, 0, 40);
                args = args.Replace("$2", My.Time.GetHHMMSSFF(tx));
                p.StartInfo.Arguments = args;
                p.StartInfo.CreateNoWindow = true;
                p.StartInfo.UseShellExecute = false;
                p.StartInfo.RedirectStandardOutput = true;
                p.StartInfo.RedirectStandardError = true;
                p.Start();
                //while (p.HasExited || d.Annullare) System.Threading.Thread.Sleep(100);
                DateTime start = DateTime.Now;
                while (!p.HasExited)
                {
                    if ((DateTime.Now - start) > TimeSpan.FromSeconds(3)) break;
                    System.Threading.Thread.Sleep(50);
                }
                //p.WaitForExit();
                string output = p.StandardOutput.ReadToEnd();
                output += p.StandardError.ReadToEnd();
                //d.Hide();
                result = true;
            }
            catch (Exception ex)
            { ERROR = ex.Message; }
            //d.Dispose();
            //d = null;
            return result;
        }

        private My.Process.ProcessCaller processCaller = null;
        public bool Execute(string args, System.ComponentModel.ISynchronizeInvoke form)
        {
            try
            {
                processCaller = new Process.ProcessCaller(form);
                processCaller.FileName = Source;
                processCaller.Arguments = args;
                processCaller.StdErrReceived += new My.Process.DataReceivedHandler(writeStreamInfo);
                processCaller.StdOutReceived += new My.Process.DataReceivedHandler(writeStreamInfo);
                processCaller.Completed += new EventHandler(processCompletedOrCanceled);
                processCaller.Cancelled += new EventHandler(processCompletedOrCanceled);
                processCaller.Start();
                return true;
            }
            catch { }
            return false;
        }

        public bool ExecuteAndWait(string args, System.ComponentModel.ISynchronizeInvoke form)
        {
            bool val = Execute(args, form);
            while (!processCaller.IsDone) System.Threading.Thread.Sleep(10);
            return val;
        }

        private double Duration = 100;
        private double Time = 1;
        public event EventHandler OnError;
        public event EventHandler OnFinished;
        public event EventHandler OnProgress;
        public event EventHandler OnOutput;
        private void writeStreamInfo(object sender, My.Process.DataReceivedEventArgs e)
        {
            try
            {
                if(OnOutput!=null) OnOutput(this, new My.Event.MessageArgs(e.Text));
                //this.textOutput.AppendText(e.Text + Environment.NewLine);
                int sd = e.Text.IndexOf("Duration: ");
                int st = e.Text.IndexOf("time=");
                if (sd != -1) Duration = TimeSpan.Parse(e.Text.Substring(sd + 10, 10)).TotalSeconds;
                if (st != -1)
                {
                    string tt = e.Text.Substring(st + 5, e.Text.Length - (st + 5));
                    string[] ttt = tt.Split(' ');
                    Time = System.Convert.ToDouble(ttt[0].Replace(" ", "").Replace(".", 
                        System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyDecimalSeparator));
                    //textOutput.AppendText("[" + Time.ToString() + "]\r\n");
                }
                if (OnProgress != null)
                {
                    int v = System.Convert.ToInt32((Time / Duration) * 100);
                    int m = 100;
                    if (v > m) m = v;
                    OnProgress(this, new My.Event.ProgressArgs(v, m));
                }
            }
#if(DEBUG)
            catch (Exception ex) { My.Box.Errore(ex.Message); }
#else 
            catch{}
#endif
        }

        private void processCompletedOrCanceled(object sender, EventArgs e)
        {
            //this.textOutput.AppendText("Fine della conversione");
            if (OnFinished != null) OnFinished(this, EventArgs.Empty);
        }

        private string GetInfo(string file)
        {
            try
            {
                System.Diagnostics.Process p = new System.Diagnostics.Process();
                p.StartInfo.FileName = Source;
                p.StartInfo.Arguments = "-i \"" + file + "\"";
                p.StartInfo.CreateNoWindow = true;
                p.StartInfo.UseShellExecute = false;
                p.StartInfo.RedirectStandardOutput = true;
                p.StartInfo.RedirectStandardError = true;
                p.Start();
                p.WaitForExit();
                string output = p.StandardOutput.ReadToEnd();
                output += p.StandardError.ReadToEnd();
                return output;
            }
#if(DEBUG)
            catch (Exception ex) { My.Box.Errore(ex.Message); }
#else
            catch {}
#endif
            return "";
        }

        public VideoInfo GetVideoInfo(string file)
        {
            string info = GetInfo(file);
            return VideoInfo.GetVideoInfo(info);
        }

        public class VideoInfo
        {
            public int Width = 0;
            public int Height = 0;
            public string AudioCompression = "";
            public string VideoCompression = "";
            public bool Is169 = false;
            public TimeSpan Duration = new TimeSpan(0, 0, 0);

            public static VideoInfo GetVideoInfo(string output)
            {
                VideoInfo result = new VideoInfo();
                try
                {
                    output = output.Replace("\r", "");
                    string[] lines = output.Split('\n');
                    foreach (string line in lines)
                    {
                        string[] token;
                        if (line.IndexOf("Duration:") != -1)
                        {
                            try
                            {
                                token = line.Split(',');
                                token[0] = token[0].Replace("Duration:","");
                                result.Duration = TimeSpan.Parse(token[0].Trim());
                            }
                            catch { }
                        }
                        if (line.IndexOf("Video:") != -1)
                        {
                            try
                            {
                                result.Is169 = line.Contains("16:9");
                                token = line.Split(':');
                                token = token[2].Split(',');
                                result.VideoCompression = token[0].Trim();
                                string[] dim = new string[1];
                                if (token.Length == 3) dim = token[1].Trim().Split('x');
                                else if (token.Length > 3) dim = token[2].Trim().Split('x');
                                if (dim.Length == 2)
                                {
                                    result.Width = System.Convert.ToInt32(dim[0]);
                                    result.Height = System.Convert.ToInt32(dim[1]);
                                }
                            }
                            catch { }
                        }
                        if (line.IndexOf("Audio:") != -1)
                        {
                            try
                            {
                                token = line.Split(':');
                                token = token[2].Split(',');
                                result.AudioCompression = token[0].Trim();
                            }
                            catch { }
                        }
                    }
                }
                catch (Exception ex)
                {
#if(DEBUG)
                     My.Box.Errore(output+"\r\n"+ex.Message);
#endif
                }
                return result;
            }

            public override string ToString()
            {
                string result = "";
                result += "Compressione Video: " + VideoCompression + "\r\n";
                result += "Compressione Audio: " + AudioCompression + "\r\n";
                result += "Dimensioni Video: " + Width.ToString() + "x" + Height.ToString() + "\r\n";
                result += "Durata: " + My.Time.GetTC(Duration) + "\r\n";
                return result;
            }
        }
    }
}
