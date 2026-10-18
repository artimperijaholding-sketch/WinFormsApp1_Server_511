using System.Collections.Concurrent;
using System.Diagnostics;
using System.IO.Pipes;
using System.Text;

namespace WinFormsApp1Server
{
    public partial class FormServer : Form
    {
        private ConcurrentBag<NamedPipeServerStream> allServers = new();
        private ConcurrentDictionary<NamedPipeServerStream, string> clientNames = new();
        private System.Windows.Forms.Timer pingTimer;
        public FormServer()
        {
            InitializeComponent();
            pingTimer = new System.Windows.Forms.Timer();
            pingTimer.Interval = 5000;
            pingTimer.Tick += PingTimer_Tick;

        }

        private void PingTimer_Tick(object? sender, EventArgs e)
        {
            Task.Run(() => SendPingToAll());
        }
        private void SendPingToAll()
        {

            byte[] bytes = Encoding.UTF8.GetBytes("Ping");
            foreach (var server in allServers)
            {
                try
                {
                    if (server.IsConnected)
                    {
                        server.Write(bytes, 0, bytes.Length);
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine($"Error sending ping: {ex.Message}");
                }
            }
        }
        private void buttonPing_Click(object sender, EventArgs e)
        {
            if (pingTimer.Enabled)
            {
                pingTimer.Stop();
                buttonPing.Text = "Start Ping (5s)";
            }
            else
            {
                pingTimer.Start();
                buttonPing.Text = "Stop Ping (5s)";
                SendPingToAll();
            }
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            //StartPipeServer();
            //Task+Run->delegate->Equals to controled Thread

            //Task.Run(delegate () { StartPipeServer(); });
            Task.Run(() => StartPipeServer());//StartPipeServer started in different thread
        }

        private void buttonSend_Click(object sender, EventArgs e)
        {
            if (listBoxClients.SelectedItems.Count > 0)
            {

                foreach (var item in listBoxClients.SelectedItems)
                {                
                    string clientName = item.ToString();
                    var targetClient = clientNames.FirstOrDefault(c => c.Value == clientName);
                    if (targetClient.Key != null && targetClient.Key.IsConnected)
                    {
                        byte[] bytes = Encoding.UTF8.GetBytes(textBoxOutput.Text);
                        targetClient.Key.Write(bytes, 0, bytes.Length);
                    }
                }
            }
            else
            {
                SendToAll();
            }
            textBoxOutput.Clear();
            listBoxClients.ClearSelected();

        }
        private void StartPipeServer()
        {
            while (true)
            {
                var server = new NamedPipeServerStream("Server511", PipeDirection.InOut,
                   NamedPipeServerStream.MaxAllowedServerInstances, PipeTransmissionMode.Byte,
                   PipeOptions.Asynchronous);
                server.WaitForConnection();
                //
                allServers.Add(server);
                Task.Run(() => HandleClient(server));
            }
        }
        private void HandleClient(NamedPipeServerStream server)
        {
            string clientName = "Unknown";
            bool isRegistered = false;
            try
            {

                while (server.IsConnected)
                {
                    Debug.WriteLine($"Server is waiting for data.");

                    byte[] buffer = new byte[256];
                    int bytesRead = server.Read(buffer, 0, buffer.Length);
                    string message = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                    if (!isRegistered)
                    {
                        if (message.StartsWith("REG:"))
                        {
                            clientName = message.Substring(4);
                            isRegistered = true;
                            Debug.WriteLine($"Client registered: {clientName}");
                        }
                        clientNames[server] = clientName;
                        UpdateClientsListBox();
                        continue;
                    }


                    Debug.WriteLine($"Client: {message}" + Environment.NewLine);

                    textBoxInput.Invoke(new Action(() =>
                    {
                        textBoxInput.Text += $"{clientName}: {message}" + Environment.NewLine; // we should handle client name OR Id
                        textBoxInput.SelectionStart = textBoxInput.Text.Length;
                        textBoxInput.ScrollToCaret();
                    }));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error while connecting: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                clientNames.TryRemove(server, out _);
                allServers.TryTake(out server!);
                server?.Dispose();
                UpdateClientsListBox();
            }
        }
        private void UpdateClientsListBox()
        {
            listBoxClients.Invoke(new Action(() =>
            {
                listBoxClients.Items.Clear();
                foreach (var clientName in clientNames.Values)
                {
                    listBoxClients.Items.Add(clientName);
                }
            }));
        }
        private void SendToAll()
        {
            // Parallel.ForEach(allServers, s => Send(s));

            foreach (NamedPipeServerStream server in allServers)
            {
                Send(server);
            }
        }
        private void Send(NamedPipeServerStream server)
        {
            string message = textBoxOutput.Text;

            if (!string.IsNullOrEmpty(message))
            {
                byte[] bytes = Encoding.UTF8.GetBytes(message);
                server.Write(bytes, 0, bytes.Length);
            }
        }

        private void listBoxClients_MouseDown(object sender, MouseEventArgs e)
        {
            if(listBoxClients.IndexFromPoint(e.Location)==ListBox.NoMatches)
            {
                listBoxClients.ClearSelected();
            }
        }
    }
}
