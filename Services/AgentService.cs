using System.Collections.Concurrent;
using System.IO;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using OrchestratorServer.Models;

namespace OrchestratorServer.Services;
{
    public class AgentService : IAgentService
    {
        private readonly string _url = "http://localhost:8080/";
        private ConcurrentDictionary<string, string> _executionState;
        private ConcurrentDictionary<string, object> _variables;

        public AgentService()
        {
            _executionState = new ConcurrentDictionary<string, string>();
            _variables = new ConcurrentDictionary<string, object>();
        }

        public void UpdateAgentStatus(UpdateAgentStatusRequest request)
        {
            // Implement logic to update agent status
        }

        public Activity GetActivity()
        {
            // Implement logic to get activity from the agent
            return new Activity();
        }

        public void NotifyAgentActivityLog(NotifyAgentActivityLogRequest request)
        {
            // Implement logic to notify agent activity log
        }

        public void SendLoggedInSessionInfo(SendLoggedInSessionInfoRequest request)
        {
            // Implement logic to send logged-in session info
        }

        public void NotifyAgentFinished(NotifyAgentFinishedRequest request)
        {
            // Implement logic to notify agent finished
        }

        public void NotifyUninstallActionFromAgentClient(NotifyUninstallActionFromAgentClientRequest request)
        {
            // Implement logic to notify uninstall action from agent client
        }

        public string GetServiceAgentInstallerUrl()
        {
            // Implement logic to get service agent installer URL
            return "https://example.com/installer";
        }

        public void ResponseToRetrieveActivityInstances(ResponseToRetrieveActivityInstancesRequest request)
        {
            // Implement logic to respond to retrieve activity instances
        }

        // Function to execute PowerShell scripts
        public async Task<PowerShellExecutionResult> ExecutePowerShellScriptAsync(string script, Dictionary<string, object> parameters)
        {
            // Serialize the parameters to JSON
            string jsonParameters = JsonSerializer.Serialize(parameters);

            // Create a command to execute the script
            string command = "ExecuteScript";
            string arguments = $"\"{script}\" \"{jsonParameters}\"";

            // Execute the command and get the result
            string result = await ExecuteAgentCommandAsync(command, arguments);

            // Deserialize the result to PowerShellExecutionResult
            return JsonSerializer.Deserialize<PowerShellExecutionResult>(result);
        }

        // Example of how to start a process and communicate with it asynchronously
        private async Task<string> ExecuteAgentCommandAsync(string command, string arguments)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(_url);
            request.Method = "POST";
            request.ContentType = "application/json";

            using (StreamWriter writer = new StreamWriter(request.GetRequestStream()))
            {
                string json = JsonSerializer.Serialize(new { command, arguments });
                await writer.WriteAsync(json);
                await writer.FlushAsync();
            }

            using (HttpWebResponse response = (HttpWebResponse)await request.GetResponseAsync())
            using (StreamReader reader = new StreamReader(response.GetResponseStream()))
            {
                string result = await reader.ReadToEndAsync();
                return result;
            }
        }
    }
}