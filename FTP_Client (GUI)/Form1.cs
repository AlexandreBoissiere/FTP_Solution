using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using static Total_library.Network.Com;

namespace FTP_Client_GUI
{
    public partial class Form1 : Form
    {
        private Client client;
        private string serverIP = null;
        private int initialCount;
        private bool waitResponse = false;
        private bool connected = false;

        Thread TVisualManager_contentInput;
        Thread TVisualManager_informationsGroupBox;
        Thread TVisualManager_modesGroupBox;
        Thread TErrorsManager;
        Thread TConnectionManager;
        Thread TVisualManager_ErrorsOutput;
        Thread TVisualManager_ActionsOutput;

        delegate void VoidDelegateInvokeTextBox();
        VoidDelegateInvokeTextBox ContentTextBoxManager;
        VoidDelegateInvokeTextBox InformationsGroupBoxManager;
        VoidDelegateInvokeTextBox ModesGroupBoxManager;
        VoidDelegateInvokeTextBox ErrorsTextBoxManager;
        VoidDelegateInvokeTextBox ConnectionManagerDelegate;
        VoidDelegateInvokeTextBox ResponseManagerDelegate;
        VoidDelegateInvokeTextBox ErrorsOutputAutoScroll;
        VoidDelegateInvokeTextBox ActionsOutputAutoScroll;

        public Form1()
        {
            InitializeComponent();

            client = new Client();
            initialCount = client.got.Count;

            InformationsGroupBox.Enabled = false;

            TVisualManager_contentInput = new Thread(new ThreadStart(VisualManagerThread_contentInput));
            TVisualManager_informationsGroupBox = new Thread(new ThreadStart(VisualManagerThread_informationsGroupBox));
            TVisualManager_modesGroupBox = new Thread(new ThreadStart(VisualManagerThread_modesGroupBox));
            TErrorsManager = new Thread(new ThreadStart(ErrorsManagerThread));
            TConnectionManager = new Thread(new ThreadStart(ConnectionManagerThread));
            TVisualManager_ErrorsOutput = new Thread(new ThreadStart(VisualManagerThread_ErrorsOutput));
            TVisualManager_ActionsOutput = new Thread(new ThreadStart(VisualManagerThread_ActionsOutput));

            StartThreads();
        }

        private void StartThreads()
        {
            TVisualManager_contentInput.Start();
            TVisualManager_informationsGroupBox.Start();
            TVisualManager_modesGroupBox.Start();
            TErrorsManager.Start();
            TConnectionManager.Start();
            TVisualManager_ErrorsOutput.Start();
            TVisualManager_ActionsOutput.Start();
        }

        private void StopThreads()
        {
            TVisualManager_contentInput.Abort();
            TVisualManager_informationsGroupBox.Abort();
            TVisualManager_modesGroupBox.Abort();
            TErrorsManager.Abort();
            TConnectionManager.Abort();
            TVisualManager_ErrorsOutput.Abort();
            TVisualManager_ActionsOutput.Abort();
        }

        private void SendButton_Click(object sender, EventArgs e)
        {
            if (ReadRadio.Checked)
            {
                string filename = FilenameInput.Text;
                string mode = "R";

                string sent = $"{mode}{filename}";

                client.Send(sent, serverIP);

                waitResponse = true;
                ActionsOutput.Text += Environment.NewLine + $"You have read {filename}";

                new Thread(new ThreadStart(ResponseManagerThread)).Start();
            }
            else if (WriteRadio.Checked)
            {
                string filename = FilenameInput.Text;
                string content = ContentInput.Text;
                string mode = "W";

                string sent = $"{mode}{filename}#{content}";

                client.Send(sent, serverIP);
                ActionsOutput.Text += Environment.NewLine + $"You have written in {filename} : {content}";
            }
            else if (AppendRadio.Checked)
            {
                string filename = FilenameInput.Text;
                string content = ContentInput.Text;
                string mode = "A";

                string sent = $"{mode}{filename}#{content}";

                client.Send(sent, serverIP);
                ActionsOutput.Text += Environment.NewLine + $"You have appended in {filename} : {content}";
            }
        }

        private void ConnectButton_Click(object sender, EventArgs e)
        {
            serverIP = ConnectedServerInput.Text;
            InformationsGroupBox.Enabled = true;
            connected = true;
        }

        private void ResponseManager()
        {
            while (waitResponse)
            {
                Thread.Sleep(200);

                if (client.got.Count > initialCount)
                {
                    string content = Encoding.ASCII.GetString(client.got[0].Data);
                    if (content.Contains("READCONTENT_"))
                    {
                        content = content.Remove(0, 12);
                        ReadContentTextBox.Text = content;
                        waitResponse = false;
                        client.got.RemoveAt(0);
                    }
                    else
                    {
                        ReadContentTextBox.Text = $"{content} => This error appears because the file may not exist.";
                        waitResponse = false;
                        continue;
                    }
                    break;
                }
                else
                {
                    continue;
                }
            }
        }
        private void ResponseManagerThread()
        {
            ResponseManagerDelegate = new VoidDelegateInvokeTextBox(ResponseManager);
            if (ReadContentTextBox.InvokeRequired)
            {
                ReadContentTextBox.Invoke(ResponseManagerDelegate);
            }
            else
            {
                ResponseManager();
            }
        }

        private void ErrorsManager()
        {
            if (client.got.Count > initialCount)
            {
                string content = Encoding.ASCII.GetString(client.got[0].Data);
                char[] chars = new char[5] { content[0], content[1], content[2], content[3], content[4] };
                string temp = new string(chars);
                if (temp == "Error")
                {
                    ErrorsOutput.Text += Environment.NewLine + content;
                    client.got.RemoveAt(0);
                }
            }
        }
        private void ErrorsManagerThread()
        {
            while (true)
            {
                ErrorsTextBoxManager = new VoidDelegateInvokeTextBox(ErrorsManager);
                if (ErrorsOutput.InvokeRequired)
                {
                    ErrorsOutput.Invoke(ErrorsTextBoxManager);
                }
                else
                {
                    ErrorsManager();
                }

                Thread.Sleep(500);
            }
        }

        private void ConnectionManager()
        {
            if (!connected)
            {
                InformationsGroupBox.Enabled = false;
            }
            else
            {
                InformationsGroupBox.Enabled = true;
            }
        }
        private void ConnectionManagerThread()
        {
            while (true)
            {
                ConnectionManagerDelegate = new VoidDelegateInvokeTextBox(ConnectionManager);
                if (InformationsGroupBox.InvokeRequired)
                {
                    InformationsGroupBox.Invoke(ConnectionManagerDelegate);
                }
                else
                {
                    ConnectionManager();
                }

                Thread.Sleep(500);
            }
        }

        private void VisualManager_contentInput()
        {
            if (ReadRadio.Checked)
            {
                ContentInput.Enabled = false;
            }
            else
            {
                if (connected)
                {
                    ContentInput.Enabled = true;
                }
            }
        }
        private void VisualManagerThread_contentInput()
        {
            while (true)
            {
                ContentTextBoxManager = new VoidDelegateInvokeTextBox(VisualManager_contentInput);
                if (ContentInput.InvokeRequired)
                {
                    ContentInput.Invoke(ContentTextBoxManager);
                }
                else
                {
                    VisualManager_contentInput();
                }

                Thread.Sleep(500);
            }
        }

        private void VisualManager_informationsGroupBox()
        {
            if (waitResponse)
            {
                InformationsGroupBox.Enabled = false;
            }
            else
            {
                if (connected)
                {
                    InformationsGroupBox.Enabled = true;
                }
            }
        }
        private void VisualManagerThread_informationsGroupBox()
        {
            while (true)
            {
                InformationsGroupBoxManager = new VoidDelegateInvokeTextBox(VisualManager_informationsGroupBox);
                if (InformationsGroupBox.InvokeRequired)
                {
                    InformationsGroupBox.Invoke(InformationsGroupBoxManager);
                }
                else
                {
                    VisualManager_informationsGroupBox();
                }

                Thread.Sleep(500);
            }
        }

        private void VisualManager_modesGroupBox()
        {
            if (waitResponse)
            {
                ModesGroupBox.Enabled = false;
            }
            else
            {
                ModesGroupBox.Enabled = true;
            }
        }
        private void VisualManagerThread_modesGroupBox()
        {
            while (true)
            {
                ModesGroupBoxManager = new VoidDelegateInvokeTextBox(VisualManager_modesGroupBox);
                if (ModesGroupBox.InvokeRequired)
                {
                    ModesGroupBox.Invoke(ModesGroupBoxManager);
                }
                else
                {
                    VisualManager_modesGroupBox();
                }

                Thread.Sleep(500);
            }
        }

        private void VisualManager_ErrorsOutput()
        {
            ErrorsOutput.SelectionStart = ErrorsOutput.TextLength;
            ErrorsOutput.ScrollToCaret();
        }
        private void VisualManagerThread_ErrorsOutput()
        {
            while (true)
            {
                ErrorsOutputAutoScroll = new VoidDelegateInvokeTextBox(VisualManager_ErrorsOutput);
                if (ErrorsOutput.InvokeRequired)
                {
                    ErrorsOutput.Invoke(ErrorsOutputAutoScroll);
                }
                else
                {
                    VisualManager_ErrorsOutput();
                }

                Thread.Sleep(500);
            }
        }

        private void VisualManager_ActionsOutput()
        {
            ActionsOutput.SelectionStart = ActionsOutput.TextLength;
            ActionsOutput.ScrollToCaret();
        }
        private void VisualManagerThread_ActionsOutput()
        {
            while (true)
            {
                ActionsOutputAutoScroll = new VoidDelegateInvokeTextBox(VisualManager_ActionsOutput);
                if (ActionsOutput.InvokeRequired)
                {
                    ActionsOutput.Invoke(ActionsOutputAutoScroll);
                }
                else
                {
                    VisualManager_ActionsOutput();
                }

                Thread.Sleep(500);
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            StopThreads();
        }
    }
}
